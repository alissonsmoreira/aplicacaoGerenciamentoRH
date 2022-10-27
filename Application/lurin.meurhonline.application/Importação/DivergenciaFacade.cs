using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.domain.model.enumerator;
using System.Linq;

namespace lurin.meurhonline.application
{
    public class DivergenciaFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _domainDivergencia;
        private static dynamic _repoDivergencia;
        private static dynamic _repoDivergenciaCustom;
        private static dynamic _repoDivergenciaDetalheCustom;
        private static dynamic _repoDivergenciaLog;
        private static dynamic _repoDivergenciaDetalhe;

        private int _empresaId;

        public DivergenciaFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainDivergencia = DomainFactory.CreateDomain<DivergenciaModel, DivergenciaDomain>(_unitOfWork);

            _repoDivergencia = RepositoryFactory.CreateRepository<DivergenciaModel, Repository<DivergenciaModel>>(_unitOfWork);
            _repoDivergenciaCustom = RepositoryFactory.CreateRepositoryCustom<DivergenciaModel, DivergenciaRepository>(_unitOfWork);
            _repoDivergenciaDetalheCustom = RepositoryFactory.CreateRepositoryCustom<DivergenciaDetalheModel, DivergenciaDetalheRepository>(_unitOfWork);
            _repoDivergenciaLog = RepositoryFactory.CreateRepository<DivergenciaLogModel, Repository<DivergenciaLogModel>>(_unitOfWork);
            _repoDivergenciaDetalhe = RepositoryFactory.CreateRepository<DivergenciaDetalheModel, Repository<DivergenciaDetalheModel>>(_unitOfWork);
        }

        public dynamic ImportarDivergencia(DivergenciaModel Divergencia)
        {
            List<DivergenciaLogModel> divergenciasLogs = new List<DivergenciaLogModel>();
            
            try
            {
                var validacaodocumento = ValidacaoDocumento(Divergencia);
                if (validacaodocumento.Codigo == 0)
                {
                    IList<DivergenciaModel> divergencias = _domainDivergencia.ImportarDivergencia(Divergencia);
                    ApagarDivergenciaLog();
                    foreach (DivergenciaModel div in divergencias)
                    {
                        div.EmpresaId = _empresaId;
                        var ret = AdicionarDivergencia(div);

                        if ((ret as DivergenciaLogModel != null))
                        {
                            DivergenciaLogModel log = ret;
                            if (!String.IsNullOrEmpty(log.LogErro))
                            {
                                divergenciasLogs.Add(log);
                            }
                        }
                    }
                    return divergenciasLogs;
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

        public dynamic BuscarDivergenciaPorColaboradorIdData(int? colaboradorId, string dataInicio, string dataFim)
        {
            List<DivergenciaModel> divergencias = new List<DivergenciaModel>();
            DivergenciaModel div = new DivergenciaModel();

            DateTime inicio = new DateTime();
            DateTime fim = new DateTime();
            try
            {
                inicio = Convert.ToDateTime(dataInicio);
                fim = Convert.ToDateTime(dataFim);
            }
            catch
            {
                div = new DivergenciaModel()
                {
                    Erro = new ErrorModel()
                    {
                        Codigo = 600,
                        Descricao = "Datas de Início e Fim em formato inválido (dd/MM/yyyy)"
                    }
                };
            }

            if (div.Erro == null)
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

                if (colaboradorId.HasValue)
                {
                    var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId.Value);
                    
                    if (colaborador == null)
                    {
                        div = new DivergenciaModel()
                        {
                            Erro = new ErrorModel()
                            {
                                Codigo = 600,
                                Descricao = "Colaborador não existe"
                            }
                        };

                        divergencias.Add(div);
                    }
                    else
                    {

                        divergencias = _repoDivergenciaCustom.GetDivergenciaByColaboradorIdData(colaborador.Id, inicio, fim);
                    }
                }
                else
                {
                    divergencias = _repoDivergenciaCustom.GetDivergenciaByColaboradorIdData(null, inicio, fim);
                }
            }

            else
            {
                divergencias.Add(div);
            }

            return divergencias;
        }

        public dynamic BuscarDivergenciaPorId(int id)
        {
            DivergenciaModel result = _repoDivergenciaCustom.GetDivergenciaById(id);
            result.Detalhes = result.Detalhes.Where(item => item.SolicitacaoStatusId != (int)SolicitacaoStatusEnum.APROVADO).ToList();
           
            return result;
        }

        public dynamic BuscarDivergenciaNaoJustificadaPorId(int id)
        {
            DivergenciaModel result = _repoDivergenciaCustom.GetDivergenciaById(id);
            result.Detalhes = result.Detalhes.Where(item => !item.JustificativaDivergenciaId.HasValue && item.SolicitacaoStatusId != (int)SolicitacaoStatusEnum.APROVADO).ToList();

            return result;
        }

        public dynamic BuscarDivergenciaPorGestorId(int id)
        {
            var result = new List<DivergenciaModel>();

            try
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var colaboradorGestor = colaboradorFacade.BuscarColaboradorPorGestorId(id);

                foreach (var colaborador in colaboradorGestor)
                {
                    List<DivergenciaModel> resultRepo = _repoDivergenciaCustom.GetDivergenciaByColaboradorId(colaborador.Id);

                    foreach (var resultfor in resultRepo)
                    {
                        foreach (var resultDetalhe in resultfor.Detalhes)
                        {
                            var solicitacaoStatusModel = new SolicitacaoStatusModel();
                            solicitacaoStatusModel.Id = resultDetalhe.SolicitacaoStatusId;
                            solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultDetalhe.SolicitacaoStatusId);
                            resultDetalhe.SolicitacaoStatus = solicitacaoStatusModel;
                        }
                        result.Add(resultfor);
                    }
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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic BuscarDivergenciaPorColaboradorId(int? id)
        {
            var result = new List<DivergenciaModel>();

            try
            {
                List<DivergenciaModel> resultRepo = _repoDivergenciaCustom.GetDivergenciaByColaboradorId(id);

                foreach (var resultfor in resultRepo)
                {
                    foreach (var resultDetalhe in resultfor.Detalhes)
                    {
                        var solicitacaoStatusModel = new SolicitacaoStatusModel();
                        solicitacaoStatusModel.Id = resultDetalhe.SolicitacaoStatusId;
                        solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultDetalhe.SolicitacaoStatusId);
                        resultDetalhe.SolicitacaoStatus = solicitacaoStatusModel;
                    }
                    result.Add(resultfor);
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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public dynamic AdicionarDivergencia(DivergenciaModel divergencia)
        {
            var result = new DivergenciaLogModel();
            try
            {
                DivergenciaLogModel log = new DivergenciaLogModel();
                var validacaoEntrada = ValidacaoEntrada(divergencia);

                if (validacaoEntrada.Codigo == 0)
                {
                    divergencia.DataCadastro = DateTime.Now;
                    _repoDivergencia.Add(divergencia);
                }
                else
                {
                    result.Matricula = divergencia.Matricula;
                    result.LogErro = validacaoEntrada.Descricao;
                    result.DataCadastro = DateTime.Now;

                    _repoDivergenciaLog.Add(result);
                }

                _unitOfWork.Commit();
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

        private void ApagarDivergenciaLog()
        {
            var logs = _repoDivergenciaLog.GetAll();
            _repoDivergenciaLog.Delete(logs);
            _unitOfWork.Commit();
        }

        public dynamic AprovarDivergencia(DivergenciaDetalheModel divergenciaDetalhe)
        {
            dynamic result;

            try
            {
                DivergenciaDetalheModel divergenciaResult = _repoDivergenciaDetalheCustom.GetDivergenciaDetalheById(divergenciaDetalhe.Id);

                if (divergenciaResult != null)
                {
                    if (divergenciaResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {

                        divergenciaResult.MotivoAprovacao = divergenciaDetalhe.MotivoAprovacao;
                        divergenciaResult.JustificativaDivergenciaId = divergenciaDetalhe.JustificativaDivergenciaId;

                        _unitOfWork.Commit();

                        result = _repoDivergenciaDetalheCustom.GetDivergenciaDetalheById(divergenciaResult.Id);

                        var DesligamentoStatusModel = new SolicitacaoStatusModel();
                        DesligamentoStatusModel.Id = result.SolicitacaoStatusId;
                        DesligamentoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = DesligamentoStatusModel;

                    }
                    else
                        result = "Registro não pode ser alterado";
                }
                else
                    result = "Registro não encontrado";

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        public bool SalvarJustificativaDivergencia(int id)
        {
            var result = true;

            try
            {
                DivergenciaDetalheModel divergenciaDetalheModel = _repoDivergenciaDetalheCustom.GetDivergenciaDetalheById(id);

                if (divergenciaDetalheModel != null)
                {

                    divergenciaDetalheModel.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                    divergenciaDetalheModel.DataConclusao = DateTime.Now;

                    _unitOfWork.Commit();
                }
                else
                    result = false;

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
            finally
            {
                _unitOfWork.CloseConn();
            }
        }

        private ErrorModel ValidacaoDocumento(DivergenciaModel divergencia)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(divergencia.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Inválido";
            } 
            else if (string.IsNullOrEmpty(divergencia.EmpresaId.ToString()))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Id da Empresa não informado";
            }
            else
            {
                EmpresaFacade empresaFacade = new EmpresaFacade();
                var empresa = empresaFacade.BuscarEmpresaPorId(divergencia.EmpresaId.Value);
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

        private ErrorModel ValidacaoEntrada(DivergenciaModel divergencia)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(divergencia.Matricula))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Matrícula não informada";
            }
            else
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var colaborador = colaboradorFacade.BuscarColaboradorPorMatricula(divergencia.Matricula);
                
                if (colaborador == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Matrícula não encontrada";
                }
                else
                {
                    divergencia.ColaboradorId = colaborador.Id;
                }
            }
            return erroModel;
        }
    }
}
