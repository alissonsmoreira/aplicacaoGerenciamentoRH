using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.common;

namespace lurin.meurhonline.application
{
    public class FeriasFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _domainFerias;
        private static dynamic _repoFerias;
        private static dynamic _repoFeriasCustom;
        private static dynamic _repoFeriasPeriodoCustom;
        private static dynamic _repoFeriasLog;

        private int _empresaId;

        public FeriasFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainFerias = DomainFactory.CreateDomain<FeriasModel, FeriasDomain>(_unitOfWork);

            _repoFerias = RepositoryFactory.CreateRepository<FeriasModel, Repository<FeriasModel>>(_unitOfWork);
            _repoFeriasCustom = RepositoryFactory.CreateRepositoryCustom<FeriasModel, FeriasRepository>(_unitOfWork);
            _repoFeriasPeriodoCustom = RepositoryFactory.CreateRepositoryCustom<FeriasPeriodoModel, FeriasPeriodoRepository>(_unitOfWork);
            _repoFeriasLog = RepositoryFactory.CreateRepository<FeriasLogModel, Repository<FeriasLogModel>>(_unitOfWork);
        }

        public dynamic ImportarFerias(FeriasModel ferias)
        {
            List<FeriasLogModel> feriasLogs = new List<FeriasLogModel>();

            try
            {
                var validacaodocumento = ValidacaoDocumento(ferias);
                if (validacaodocumento.Codigo == 0)
                {
                    IList<FeriasModel> listaFerias = _domainFerias.ImportarFerias(ferias);
                    ApagarFeriasLog();
                    foreach (FeriasModel fm in listaFerias)
                    {
                        fm.EmpresaId = _empresaId;
                        var ret = AdicionarFerias(fm);

                        if ((ret as FeriasLogModel != null))
                        {
                            FeriasLogModel log = ret;
                            if (!String.IsNullOrEmpty(log.LogErro))
                            {
                                feriasLogs.Add(log);
                            }
                        }
                    }

                    return feriasLogs;
                }
                else
                {
                    return validacaodocumento;
                }
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic BuscarFeriasPorEmpresaId(int empresaId)
        {
            List<FeriasModel> ferias = new List<FeriasModel>();

            EmpresaFacade empresaFacade = new EmpresaFacade();
            var empresa = empresaFacade.BuscarEmpresaPorId(empresaId);
            if (empresa == null)
            {
                FeriasModel fm = new FeriasModel()
                {
                    Erro = new ErrorModel()
                    {
                        Codigo = 600,
                        Descricao = "Empresa não existe"
                    }
                };
                ferias.Add(fm);
            }
            else
            {
                ferias = _repoFeriasCustom.GetFeriasByEmpresaId(empresaId);
            }
            
            return ferias;
        }

        public dynamic BuscarFeriasPorColaboradorId(int colaboradorId)
        {
            List<FeriasModel> ferias = new List<FeriasModel>();

            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId);

            if (colaborador == null)
            {
                FeriasModel fm = new FeriasModel()
                {
                    Erro = new ErrorModel()
                    {
                        Codigo = 600,
                        Descricao = "Colaborador não existe"
                    }
                };

                ferias.Add(fm);
            }
            else
            {
                var result = _repoFeriasCustom.GetFeriasByColaboradorId(colaborador.Id);
                if (result != null)
                {
                    ferias.AddRange(result);
                }
            }

            return ferias;
        }


        public dynamic BuscarFeriasPorId(int id)
        {
            var result = _repoFeriasCustom.GetFeriasById(id);

            return result;
        }

        public dynamic SolicitarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            try
            {
                FeriasPeriodoModel fp = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(feriasPeriodo.Id);
                
                var validacaoEntrada = ValidacaoSolicitacaoFerias(fp);
                if (validacaoEntrada.Codigo == 0)
                {
                    fp.Saldo = feriasPeriodo.Saldo;
                    fp.DataSolicitacao = DateTime.Now;
                    fp.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _unitOfWork.Commit();

                    AdicionarFeriasNotificacao(fp.Ferias.ColaboradorId.Value, 8); // Solicitação de Férias

                    var result = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(fp.Id);

                    var feriasPeriodoStatusModel = new SolicitacaoStatusModel();
                    feriasPeriodoStatusModel.Id = result.SolicitacaoStatusId;
                    feriasPeriodoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                    result.SolicitacaoStatus = feriasPeriodoStatusModel;

                    return result;
                }
                else
                    return validacaoEntrada;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic AprovarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            try
            {
                FeriasPeriodoModel fp = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(feriasPeriodo.Id);

                var validacaoEntrada = ValidacaoAprovacaoFerias(fp);
                if (validacaoEntrada.Codigo == 0)
                {
                    fp.DataConclusao = DateTime.Now;
                    fp.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;

                    _unitOfWork.Commit();

                    AdicionarFeriasNotificacao(fp.Ferias.ColaboradorId.Value, 11); //Aprovação de Férias

                    var result = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(fp.Id);

                    var feriasPeriodoStatusModel = new SolicitacaoStatusModel();
                    feriasPeriodoStatusModel.Id = result.SolicitacaoStatusId;
                    feriasPeriodoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                    result.SolicitacaoStatus = feriasPeriodoStatusModel;

                    return result;
                }
                else
                    return validacaoEntrada;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic ReprovarFerias(FeriasPeriodoModel feriasPeriodo)
        {
            try
            {
                FeriasPeriodoModel fp = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(feriasPeriodo.Id);

                var validacaoEntrada = ValidacaoAprovacaoFerias(fp);
                if (validacaoEntrada.Codigo == 0)
                {
                    fp.DataConclusao = DateTime.Now;
                    fp.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;

                    _unitOfWork.Commit();

                    AdicionarFeriasNotificacao(fp.Ferias.ColaboradorId.Value, 12); // Reprovação de Férias

                    var result = _repoFeriasPeriodoCustom.GetFeriasPeriodoById(fp.Id);

                    var feriasPeriodoStatusModel = new SolicitacaoStatusModel();
                    feriasPeriodoStatusModel.Id = result.SolicitacaoStatusId;
                    feriasPeriodoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                    result.SolicitacaoStatus = feriasPeriodoStatusModel;

                    return result;
                }
                else
                    return validacaoEntrada;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic AdicionarFerias(FeriasModel ferias)
        {
            var result = new FeriasLogModel();
            try
            {
                var validacaoEntrada = ValidacaoEntrada(ferias);

                if (validacaoEntrada.Codigo == 0)
                {
                    ferias.DataCadastro = DateTime.Now;
                    _repoFerias.Add(ferias);
                    _unitOfWork.Commit();
                }
                else
                {
                    result.Matricula = ferias.Matricula;
                    result.LogErro = validacaoEntrada.Descricao;
                    result.DataCadastro = DateTime.Now;

                    _repoFeriasLog.Add(result);
                    _unitOfWork.Commit();
                }

                return result;
            }
            catch (DbEntityValidationException ex)
            {
                var entityError = EntityValidationException.Validate(ex);
                Log.RecordError(ex, entityError.Item2.ToString());
                throw new DbEntityValidationException(entityError.Item1, entityError.Item2);
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }
        }

        private static void AdicionarFeriasNotificacao(int colaboradorId, int notificacaoDetalheId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = notificacaoDetalheId; //Solicitação de Férias
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private void ApagarFeriasLog()
        {
            var logs = _repoFeriasLog.GetAll();
            _repoFeriasLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private ErrorModel ValidacaoDocumento(FeriasModel ferias)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(ferias.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Invalido";
            }
            else if (string.IsNullOrEmpty(ferias.EmpresaId.ToString()))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Id da Empresa não informado";
            }
            else
            {
                EmpresaFacade empresaFacade = new EmpresaFacade();
                var empresa = empresaFacade.BuscarEmpresaPorId(ferias.EmpresaId.Value);
                if (empresa == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Empresa não encontrada";
                }
                else
                {
                    _empresaId = empresa.Id;
                }
            }
            return erroModel;
        }

        private ErrorModel ValidacaoEntrada(FeriasModel ferias)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(ferias.Matricula))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Matrícula não informada";
            }
            else
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var result = colaboradorFacade.BuscarColaboradorPorMatricula(ferias.Matricula);
                if (result == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Matrícula não encontrada";
                }
                else
                {
                    ferias.ColaboradorId = result.Id;
                    VerificaDuplicidade(ferias);
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoSolicitacaoFerias(FeriasPeriodoModel feriasPeriodo = null)
        {
            var erroModel = new ErrorModel();

            if (feriasPeriodo == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Registro não encontrado";
            }
            else
            {
                if (feriasPeriodo.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro não pode ser alterado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoAprovacaoFerias(FeriasPeriodoModel feriasPeriodo = null)
        {
            var erroModel = new ErrorModel();

            if (feriasPeriodo == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Ferias Periodo não encontrado";
            }
            else
            {
                if (feriasPeriodo.SolicitacaoStatusId != (int)SolicitacaoStatusEnum.EM_ANALISE)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Período de Férias não está em status de Análise";
                }
            }

            return erroModel;
        }

        private void VerificaDuplicidade(FeriasModel ferias)
        {
            List<FeriasModel> feriasExistentes = _repoFeriasCustom.GetFeriasByColaboradorId(ferias.ColaboradorId.Value);
            if (feriasExistentes != null)
            {
                _repoFerias.Delete(feriasExistentes);
            }
        }
    }
}
