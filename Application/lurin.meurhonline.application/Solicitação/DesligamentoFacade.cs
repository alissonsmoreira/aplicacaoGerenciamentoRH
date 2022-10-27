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
    public class DesligamentoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultDesligamento;
        private static dynamic _repoDefaultDesligamentoTipo;

        private static dynamic _repoCustomDesligamento;

        public DesligamentoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultDesligamento = RepositoryFactory.CreateRepository<DesligamentoModel, Repository<DesligamentoModel>>(_unitOfWork);
            _repoDefaultDesligamentoTipo = RepositoryFactory.CreateRepository<DesligamentoTipoModel, Repository<DesligamentoTipoModel>>(_unitOfWork);

            _repoCustomDesligamento = RepositoryFactory.CreateRepositoryCustom<DesligamentoModel, DesligamentoRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoDesligamento(DesligamentoModel desligamento)
        {
            try
            {
                var resultRepo = _repoCustomDesligamento.GetDesligamento(desligamento);

                var result = new List<DesligamentoModel>();
                foreach (var resultFor in resultRepo)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    resultFor.Colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.ColaboradorId);

                    ColaboradorFacade gestorFacade = new ColaboradorFacade();
                    resultFor.Gestor = gestorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.GestorId);

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

        public dynamic BuscarSolicitacaoDesligamentoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var resultRepo = _repoCustomDesligamento.GetDesligamentobyColaboradorId(colaboradorId);

                var result = new List<DesligamentoModel>();
                foreach (var resultFor in resultRepo)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    resultFor.Colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.ColaboradorId);

                    ColaboradorFacade gestorFacade = new ColaboradorFacade();
                    resultFor.Gestor = gestorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.GestorId);

                    var DesligamentoStatusModel = new SolicitacaoStatusModel();
                    DesligamentoStatusModel.Id = resultFor.SolicitacaoStatusId;
                    DesligamentoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = DesligamentoStatusModel;
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

        public dynamic BuscarTudoDesligamentoTipo()
        {
            try
            {
                var result = Cache.Get<List<DesligamentoTipoModel>>("DesligamentoTipo");
                if (result == null)
                {
                    result = _repoDefaultDesligamentoTipo.GetAll();

                    Cache.AddItem("DesligamentoTipo", result, 1);
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

        public dynamic SolicitarDesligamento(DesligamentoModel desligamento)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(desligamento);
                if (validacaoEntrada.Codigo == 0)
                {
                    desligamento.DataSolicitacao = DateTime.Now;
                    desligamento.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultDesligamento.Add(desligamento);
                    _unitOfWork.Commit();

                    AdicionarDesligamentoNotificacao(desligamento.ColaboradorId);

                    var result = _repoCustomDesligamento.GetDesligamentobyId(desligamento.Id);

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

        public dynamic AprovarSolicitacaoDesligamento(DesligamentoModel desligamento)
        {
            dynamic result;

            try
            {
                var desligamentoResult = _repoCustomDesligamento.GetDesligamentobyId(desligamento.Id);

                if (desligamentoResult != null)
                {
                    if (desligamentoResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {

                        desligamentoResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        desligamentoResult.DataConclusao = DateTime.Now;
                        desligamentoResult.DataDesligamento = desligamento.DataDesligamento;

                        _unitOfWork.Commit();

                        result = _repoCustomDesligamento.GetDesligamentobyId(desligamentoResult.Id);

                        var DesligamentoStatusModel = new SolicitacaoStatusModel();
                        DesligamentoStatusModel.Id = result.SolicitacaoStatusId;
                        DesligamentoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = DesligamentoStatusModel;

                        AtualizarDesligamentoColaborador(desligamentoResult.ColaboradorId);

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

        public dynamic ReprovarSolicitacaoDesligamento(int desligamentoId)
        {
            dynamic result;

            try
            {
                var DesligamentoResult = _repoCustomDesligamento.GetDesligamentobyId(desligamentoId);

                if (DesligamentoResult != null)
                {
                    if (DesligamentoResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        DesligamentoResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        DesligamentoResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomDesligamento.GetDesligamentobyId(DesligamentoResult.Id);

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

        private static void AdicionarDesligamentoNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 2; //Solicitação de Desligamento
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private void AtualizarDesligamentoColaborador(int colaboradorId)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

            colaboradorFacade.AtualizarDesligamentoColaborador(colaboradorId);
        }



        private ErrorModel ValidacaoEntrada(DesligamentoModel desligamento)
        {
            var erroModel = new ErrorModel();

            if (desligamento.GestorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Gestor";
            }
            else if (desligamento.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else
            {
                var result = _repoCustomDesligamento.GetDesligamentoValidation(desligamento);
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