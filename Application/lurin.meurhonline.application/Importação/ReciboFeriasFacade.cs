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

namespace lurin.meurhonline.application
{
    public class ReciboFeriasFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _domainReciboFerias;
        private static dynamic _repoReciboFerias;
        private static dynamic _repoReciboFeriasCustom;
        private static dynamic _repoReciboFeriasLog;
        private static dynamic _repoReciboFeriasVencimento;
        private static dynamic _repoReciboFeriasDesconto;

        private string _ano;
        public ReciboFeriasFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainReciboFerias = DomainFactory.CreateDomain<ReciboFeriasModel, ReciboFeriasDomain>(_unitOfWork);

            _repoReciboFerias = RepositoryFactory.CreateRepository<ReciboFeriasModel, Repository<ReciboFeriasModel>>(_unitOfWork);
            _repoReciboFeriasCustom = RepositoryFactory.CreateRepositoryCustom<ReciboFeriasModel, ReciboFeriasRepository>(_unitOfWork);
            _repoReciboFeriasLog = RepositoryFactory.CreateRepository<ReciboFeriasLogModel, Repository<ReciboFeriasLogModel>>(_unitOfWork);
            _repoReciboFeriasVencimento = RepositoryFactory.CreateRepository<ReciboFeriasVencimentoModel, Repository<ReciboFeriasVencimentoModel>>(_unitOfWork);
            _repoReciboFeriasDesconto = RepositoryFactory.CreateRepository<ReciboFeriasDescontoModel, Repository<ReciboFeriasDescontoModel>>(_unitOfWork);
        }

        public dynamic ImportarReciboFerias(ReciboFeriasModel reciboFerias)
        {
            List<ReciboFeriasLogModel> recibosFeriasLogs = new List<ReciboFeriasLogModel>();
            
            try
            {
                var validacaodocumento = ValidacaoDocumento(reciboFerias);
                if (validacaodocumento.Codigo == 0)
                {
                    IList<ReciboFeriasModel> recibosFerias = _domainReciboFerias.ImportarReciboFerias(reciboFerias);
                    ApagarReciboFeriasLog();
                    foreach (ReciboFeriasModel ir in recibosFerias)
                    {
                        var ret = AdicionarReciboFerias(ir);

                        if ((ret as ReciboFeriasLogModel != null))
                        {
                            ReciboFeriasLogModel log = ret;
                            if (!String.IsNullOrEmpty(log.LogErro))
                            {
                                recibosFeriasLogs.Add(log);
                            }
                        }
                    }

                    return recibosFeriasLogs;
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

        public dynamic BuscarReciboFeriasPorAnoColaboradorId(string ano, int colaboradorId)
        {
            List<ReciboFeriasModel> reciboFerias = new List<ReciboFeriasModel>();

            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId);

            if (colaborador == null)
            {
                ReciboFeriasModel rf = new ReciboFeriasModel()
                {
                    Erro = new ErrorModel()
                    {
                        Codigo = 600,
                        Descricao = "Colaborador não existe"
                    }
                };

                reciboFerias.Add(rf);
            }
            else
            {
                reciboFerias = _repoReciboFeriasCustom.GetReciboFeriasAnoColaboradorById(ano, colaborador.Id);
            }

            return reciboFerias;
        }

        public dynamic BuscarReciboFeriasPorId(int id)
        {
            var result = _repoReciboFeriasCustom.GetReciboFeriasById(id);

            return result;
        }

        public dynamic AdicionarReciboFerias(ReciboFeriasModel reciboFerias)
        {
            var result = new ReciboFeriasLogModel();
            try
            {
                var validacaoEntrada = ValidacaoEntrada(reciboFerias);
                
                if (validacaoEntrada.Codigo == 0)
                {
                    reciboFerias.DataCadastro = DateTime.Now;
                    reciboFerias.Ano = _ano;
                    _repoReciboFerias.Add(reciboFerias);
                    _unitOfWork.Commit();
                }
                else
                {
                    result.CPF = reciboFerias.CPF;
                    result.LogErro = validacaoEntrada.Descricao;
                    result.DataCadastro = DateTime.Now;

                    _repoReciboFeriasLog.Add(result);
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

        private void ApagarReciboFeriasLog()
        {
            var logs = _repoReciboFeriasLog.GetAll();
            _repoReciboFeriasLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private ErrorModel ValidacaoDocumento(ReciboFeriasModel reciboFerias)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(reciboFerias.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Invalido";
            } 
            else if (string.IsNullOrEmpty(reciboFerias.Ano))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Ano não informado";
            }

            _ano = reciboFerias.Ano;
            return erroModel;
        }

        private ErrorModel ValidacaoEntrada(ReciboFeriasModel reciboFerias)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(reciboFerias.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "CPF não informado";
            }
            else
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                ColaboradorModel colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorCpf(reciboFerias.CPF);
                if (colaborador == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "CPF não encontrado";
                }
                else
                {
                    reciboFerias.ColaboradorId = colaborador.Id;
                    reciboFerias.EmpresaId = colaborador.EmpresaId;
                }
            }

            return erroModel;
        }
    }
}
