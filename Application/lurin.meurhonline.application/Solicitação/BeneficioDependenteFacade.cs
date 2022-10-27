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
using lurin.meurhonline.infrastructure.cache;

namespace lurin.meurhonline.application
{
    public class BeneficioDependenteFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultBeneficioDependente;
        private static dynamic _repoCustomBeneficioDependente;

        public BeneficioDependenteFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultBeneficioDependente = RepositoryFactory.CreateRepository<BeneficioDependenteModel, Repository<BeneficioDependenteModel>>(_unitOfWork);
            _repoCustomBeneficioDependente = RepositoryFactory.CreateRepositoryCustom<BeneficioDependenteModel, BeneficioDependenteRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoBeneficioDependente(BeneficioDependenteModel beneficioDependente)
        {
            try
            {
                var resultRepo = _repoCustomBeneficioDependente.GetBeneficioDependente(beneficioDependente);

                var result = new List<BeneficioDependenteModel>();
                foreach (var resultFor in resultRepo)
                {
                    var solicitacaoStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                    solicitacaoStatusModel.Id = resultFor.SolicitacaoStatusId;
                    solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = solicitacaoStatusModel;

                    result.Add(resultFor);
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

        public dynamic BuscarTudoBeneficioDependentePorDependenteId(int dependenteId)
        {
            try
            {
                var result = new List<BeneficioDependenteModel>();

                DependenteFacade dependenteFacade = new DependenteFacade();
                DependenteModel dependente = dependenteFacade.BuscarDependentePorId(dependenteId);

                BeneficioFacade beneficioFacade = new BeneficioFacade();
                var resultBeneficio = beneficioFacade.BuscarTudoBeneficio();

                foreach (var resultFor in resultBeneficio)
                {

                    BeneficioDependenteModel resultRepo = _repoCustomBeneficioDependente.GetBeneficioDependentebyBeneficioId(dependenteId, resultFor.Id);

                    if (resultRepo != null)
                    {
                        resultRepo.Dependente = dependente;
                        var beneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        beneficioDependenteStatusModel.Id = resultRepo.SolicitacaoStatusId;
                        beneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)resultRepo.SolicitacaoStatusId);
                        resultRepo.SolicitacaoStatus = beneficioDependenteStatusModel;
                        result.Add(resultRepo);
                    }
                    else
                    {
                        BeneficioDependenteModel beneficioDependente = new BeneficioDependenteModel();
                        beneficioDependente.DependenteId = dependenteId;
                        beneficioDependente.Dependente = dependente;
                        beneficioDependente.BeneficioId = resultFor.Id;
                        beneficioDependente.Beneficio = resultFor;
                        result.Add(beneficioDependente);
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

        public dynamic SolicitarBeneficioDependente(BeneficioDependenteModel beneficioDependente)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(beneficioDependente);
                if (validacaoEntrada.Codigo == 0)
                {
                    beneficioDependente.DataSolicitacao = DateTime.Now;
                    beneficioDependente.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultBeneficioDependente.Add(beneficioDependente);
                    _unitOfWork.Commit();

                    AdicionarBeneficioDependenteNotificacao(beneficioDependente.DependenteId);

                    var result = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependente.Id);

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

        public dynamic AprovarSolicitacaoBeneficioDependente(int beneficioDependenteId)
        {
            dynamic result;

            try
            {
                var beneficioDependenteResult = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteId);

                if (beneficioDependenteResult != null)
                {
                    if (beneficioDependenteResult.SolicitacaoStatusId == (int)SolicitacaoBeneficioDependenteStatusEnum.EM_ANALISE_APROVACAO)
                    {

                        beneficioDependenteResult.SolicitacaoStatusId = (int)SolicitacaoBeneficioDependenteStatusEnum.APROVADO;
                        beneficioDependenteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteResult.Id);

                        var BeneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        BeneficioDependenteStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioDependenteStatusModel;

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

        public dynamic ReprovarSolicitacaoBeneficioDependente(int beneficioDependenteId)
        {
            dynamic result;

            try
            {
                var beneficioDependenteResult = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteId);

                if (beneficioDependenteResult != null)
                {
                    if (beneficioDependenteResult.SolicitacaoStatusId == (int)SolicitacaoBeneficioDependenteStatusEnum.EM_ANALISE_APROVACAO)
                    {
                        beneficioDependenteResult.SolicitacaoStatusId = (int)SolicitacaoBeneficioDependenteStatusEnum.REPROVADO;
                        beneficioDependenteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteResult.Id);

                        var BeneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        BeneficioDependenteStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioDependenteStatusModel;

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

        public dynamic SolicitarCancelamentoBeneficioDependente(int beneficioDependenteId)
        {
            dynamic result;

            try
            {
                var beneficioDependenteResult = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteId);

                if (beneficioDependenteResult != null)
                {
                    if (beneficioDependenteResult.SolicitacaoStatusId == (int)SolicitacaoBeneficioDependenteStatusEnum.APROVADO)
                    {

                        beneficioDependenteResult.SolicitacaoStatusId = (int)SolicitacaoBeneficioDependenteStatusEnum.EM_ANALISE_CANCELAMENTO;
                        beneficioDependenteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteResult.Id);

                        var BeneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        BeneficioDependenteStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioDependenteStatusModel;

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

        public dynamic AprovarSolicitacaoCancelamentoBeneficioDependente(int beneficioDependenteId)
        {
            dynamic result;

            try
            {
                var beneficioDependenteResult = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteId);

                if (beneficioDependenteResult != null)
                {
                    if (beneficioDependenteResult.SolicitacaoStatusId == (int)SolicitacaoBeneficioDependenteStatusEnum.EM_ANALISE_CANCELAMENTO)
                    {

                        _repoDefaultBeneficioDependente.Delete(beneficioDependenteResult);
                        _unitOfWork.Commit();

                        result = beneficioDependenteResult;

                        var BeneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        BeneficioDependenteStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioDependenteStatusModel;

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

        public dynamic ReprovarSolicitacaoCancelamentoBeneficioDependente(int beneficioDependenteId)
        {
            dynamic result;

            try
            {
                var beneficioDependenteResult = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteId);

                if (beneficioDependenteResult != null)
                {
                    if (beneficioDependenteResult.SolicitacaoStatusId == (int)SolicitacaoBeneficioDependenteStatusEnum.EM_ANALISE_CANCELAMENTO)
                    {

                        beneficioDependenteResult.SolicitacaoStatusId = (int)SolicitacaoBeneficioDependenteStatusEnum.APROVADO;
                        beneficioDependenteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioDependente.GetBeneficioDependentebyId(beneficioDependenteResult.Id);

                        var BeneficioDependenteStatusModel = new SolicitacaoBeneficioDependenteStatusModel();
                        BeneficioDependenteStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioDependenteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoBeneficioDependenteStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioDependenteStatusModel;

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

        private static void AdicionarBeneficioDependenteNotificacao(int DependenteId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 9; //Soliictação de Benefício Dependente
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = DependenteId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private ErrorModel ValidacaoEntrada(BeneficioDependenteModel beneficioDependente)
        {
            var erroModel = new ErrorModel();

            if (beneficioDependente.DependenteId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Dependente";
            }
            else if (beneficioDependente.BeneficioId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Benefício";
            }
            else
            {
                var result = _repoCustomBeneficioDependente.GetBeneficioDependenteValidation(beneficioDependente);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Já existe uma solicitação Em Análise";
                }
            }

            return erroModel;
        }
    }
}