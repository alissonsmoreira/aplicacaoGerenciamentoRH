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
    public class BeneficioColaboradorFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultBeneficioColaborador;
        private static dynamic _repoCustomBeneficioColaborador;

        public BeneficioColaboradorFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultBeneficioColaborador = RepositoryFactory.CreateRepository<BeneficioColaboradorModel, Repository<BeneficioColaboradorModel>>(_unitOfWork);
            _repoCustomBeneficioColaborador = RepositoryFactory.CreateRepositoryCustom<BeneficioColaboradorModel, BeneficioColaboradorRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoBeneficioColaborador(BeneficioColaboradorModel beneficioColaborador)
        {
            try
            {
                var resultRepo = _repoCustomBeneficioColaborador.GetBeneficioColaborador(beneficioColaborador);

                var result = new List<BeneficioColaboradorModel>();
                foreach (var resultFor in resultRepo)
                {
                    var solicitacaoStatusModel = new SolicitacaoStatusModel();
                    solicitacaoStatusModel.Id = resultFor.SolicitacaoStatusId;
                    solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
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

        public dynamic BuscarTudoBeneficioColaboradorPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = new List<BeneficioColaboradorModel>();

                BeneficioFacade beneficioFacade = new BeneficioFacade();
                var resultBeneficio = beneficioFacade.BuscarTudoBeneficio();
                                
                foreach (var resultFor in resultBeneficio)
                {

                    var resultRepo = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyBeneficioId(colaboradorId, resultFor.Id);

                    if (resultRepo != null)
                    {
                        var beneficioColaboradorStatusModel = new SolicitacaoStatusModel();
                        beneficioColaboradorStatusModel.Id = resultRepo.SolicitacaoStatusId;
                        beneficioColaboradorStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultRepo.SolicitacaoStatusId);
                        resultRepo.SolicitacaoStatus = beneficioColaboradorStatusModel;
                        result.Add(resultRepo);
                    }
                    else
                    {
                        BeneficioColaboradorModel beneficioColaborador = new BeneficioColaboradorModel();
                        beneficioColaborador.ColaboradorId = colaboradorId;
                        beneficioColaborador.BeneficioId = resultFor.Id;
                        beneficioColaborador.Beneficio = resultFor;
                        result.Add(beneficioColaborador);
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

        public dynamic SolicitarBeneficioColaborador(BeneficioColaboradorModel beneficioColaborador)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(beneficioColaborador);
                if (validacaoEntrada.Codigo == 0)
                {
                    beneficioColaborador.DataSolicitacao = DateTime.Now;
                    beneficioColaborador.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultBeneficioColaborador.Add(beneficioColaborador);
                    _unitOfWork.Commit();

                    AdicionarBeneficioColaboradorNotificacao(beneficioColaborador.ColaboradorId);

                    var result = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(beneficioColaborador.Id);

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

        public dynamic AprovarSolicitacaoBeneficioColaborador(int beneficioColaboradorId)
        {
            dynamic result;

            try
            {
                var beneficioColaboradorResult = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(beneficioColaboradorId);

                if (beneficioColaboradorResult != null)
                {
                    if (beneficioColaboradorResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {

                        beneficioColaboradorResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        beneficioColaboradorResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(beneficioColaboradorResult.Id);

                        var BeneficioColaboradorStatusModel = new SolicitacaoStatusModel();
                        BeneficioColaboradorStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioColaboradorStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioColaboradorStatusModel;

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

        public dynamic ReprovarSolicitacaoBeneficioColaborador(int beneficioColaboradorId)
        {
            dynamic result;

            try
            {
                var beneficioColaboradorResult = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(beneficioColaboradorId);

                if (beneficioColaboradorResult != null)
                {
                    if (beneficioColaboradorResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        beneficioColaboradorResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        beneficioColaboradorResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(beneficioColaboradorResult.Id);

                        var BeneficioColaboradorStatusModel = new SolicitacaoStatusModel();
                        BeneficioColaboradorStatusModel.Id = result.SolicitacaoStatusId;
                        BeneficioColaboradorStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = BeneficioColaboradorStatusModel;

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

        private static void AdicionarBeneficioColaboradorNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 5; //Solicitação de Benefício
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        public dynamic ExcluirBeneficioColaborador(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomBeneficioColaborador.GetBeneficioColaboradorbyId(id);

                if (result != null)
                {
                    _repoDefaultBeneficioColaborador.Delete(result);
                    _unitOfWork.Commit();
                }
                else
                {
                    result = "Registro não encontrado";
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

        private ErrorModel ValidacaoEntrada(BeneficioColaboradorModel beneficioColaborador)
        {
            var erroModel = new ErrorModel();

            if (beneficioColaborador.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else if (beneficioColaborador.BeneficioId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Benefício";
            }
            else
            {
                var result = _repoCustomBeneficioColaborador.GetBeneficioColaboradorValidation(beneficioColaborador);
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