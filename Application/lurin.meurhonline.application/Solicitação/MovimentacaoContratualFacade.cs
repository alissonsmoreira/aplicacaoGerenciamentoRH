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
using lurin.meurhonline.infrastructure.IO;

namespace lurin.meurhonline.application
{
    public class MovimentacaoContratualFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultMovimentacaoContratual;
        private static dynamic _repoCustomMovimentacaoContratual;

        public MovimentacaoContratualFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultMovimentacaoContratual = RepositoryFactory.CreateRepository<MovimentacaoContratualModel, Repository<MovimentacaoContratualModel>>(_unitOfWork);
            _repoCustomMovimentacaoContratual = RepositoryFactory.CreateRepositoryCustom<MovimentacaoContratualModel, MovimentacaoContratualRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoMovimentacaoContratual(MovimentacaoContratualModel MovimentacaoContratual)
        {
            try
            {
                var resultRepo = _repoCustomMovimentacaoContratual.GetMovimentacaoContratual(MovimentacaoContratual);

                var result = new List<MovimentacaoContratualModel>();
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

        public dynamic BuscarDadosPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = new MovimentacaoContratualModel();
                var resultColaborador = BuscarColaboradorDadoPrincipalPorColaboradorId(colaboradorId);
                var resultColaboradorEmpregador = BuscarColaboradorEmpregadorPorColaboradorId(colaboradorId);

                if (resultColaborador != null)
                {
                    result.ColaboradorId = resultColaborador.Id;
                    result.Colaborador = resultColaborador;
                    result.EmpresaId = resultColaborador.EmpresaId;
                    result.Empresa = resultColaborador.Empresa;
               }

                if (resultColaboradorEmpregador != null)
                {
                    result.LotacaoUnidadeId = resultColaboradorEmpregador.LotacaoUnidadeId;
                    result.LotacaoUnidade = resultColaboradorEmpregador.LotacaoUnidade;
                    result.CentroCustoUnidadeId = resultColaboradorEmpregador.CentroCustoUnidadeId;
                    result.CentroCustoUnidade = resultColaboradorEmpregador.CentroCustoUnidade;
                    result.CargoUnidadeId = resultColaboradorEmpregador.CargoUnidadeId;
                    result.CargoUnidade = resultColaboradorEmpregador.CargoUnidade;
                    result.TurnoId = resultColaboradorEmpregador.TurnoId;
                    result.Turno = resultColaboradorEmpregador.Turno;
                    result.UnidadeNegocioId = resultColaboradorEmpregador.UnidadeNegocioId;
                    result.UnidadeNegocio = resultColaboradorEmpregador.UnidadeNegocio;
                    result.NumeroCartaoPonto = resultColaboradorEmpregador.NumeroCartaoPonto;
                    result.TipoMaoObraId = resultColaboradorEmpregador.TipoMaoObraId;
                    result.TipoMaoObra = resultColaboradorEmpregador.TipoMaoObra;
                    result.Salario = resultColaboradorEmpregador.Salario;
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

        public dynamic BuscarSolicitacaoMovimentacaoContratualPorColaboradorId(int colaboradorId)
        {
            try
            {
                var resultRepo = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyColaboradorId(colaboradorId);

                var result = new List<MovimentacaoContratualModel>();
                foreach (var resultFor in resultRepo)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    resultFor.Colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.ColaboradorId);

                    ColaboradorFacade gestorFacade = new ColaboradorFacade();
                    resultFor.Gestor = gestorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.GestorId);

                    var MovimentacaoContratualStatusModel = new SolicitacaoStatusModel();
                    MovimentacaoContratualStatusModel.Id = resultFor.SolicitacaoStatusId;
                    MovimentacaoContratualStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = MovimentacaoContratualStatusModel;
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

        public dynamic SolicitarMovimentacaoContratual(MovimentacaoContratualModel movimentacaoContratual)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(movimentacaoContratual);
                if (validacaoEntrada.Codigo == 0)
                {
                    movimentacaoContratual.DataSolicitacao = DateTime.Now;
                    movimentacaoContratual.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultMovimentacaoContratual.Add(movimentacaoContratual);
                    _unitOfWork.Commit();

                    AdicionarMovimentacaoContratualNotificacao(movimentacaoContratual.ColaboradorId);

                    var result = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyId(movimentacaoContratual.Id);

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

        public dynamic AprovarSolicitacaoMovimentacaoContratual(int movimentacaoContratualId)
        {
            dynamic result;

            try
            {
                var MovimentacaoContratualResult = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyId(movimentacaoContratualId);

                if (MovimentacaoContratualResult != null)
                {
                    if (MovimentacaoContratualResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {

                        MovimentacaoContratualResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        MovimentacaoContratualResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyId(MovimentacaoContratualResult.Id);

                        var MovimentacaoContratualStatusModel = new SolicitacaoStatusModel();
                        MovimentacaoContratualStatusModel.Id = result.SolicitacaoStatusId;
                        MovimentacaoContratualStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = MovimentacaoContratualStatusModel;

                        AtualizarColaborador(result);

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

        public dynamic ReprovarSolicitacaoMovimentacaoContratual(int movimentacaoContratualId)
        {
            dynamic result;

            try
            {
                var MovimentacaoContratualResult = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyId(movimentacaoContratualId);

                if (MovimentacaoContratualResult != null)
                {
                    if (MovimentacaoContratualResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        MovimentacaoContratualResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        MovimentacaoContratualResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualbyId(MovimentacaoContratualResult.Id);

                        var MovimentacaoContratualStatusModel = new SolicitacaoStatusModel();
                        MovimentacaoContratualStatusModel.Id = result.SolicitacaoStatusId;
                        MovimentacaoContratualStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = MovimentacaoContratualStatusModel;

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

        private dynamic BuscarColaboradorDadoPrincipalPorColaboradorId(int colaboradorId)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            return colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId);
        }

        private dynamic BuscarColaboradorEmpregadorPorColaboradorId(int colaboradorId)
        {
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();
            return colaboradorEmpregadorFacade.BuscarColaboradorEmpregadorPorColaboradorId(colaboradorId);
        }

        private static void AdicionarMovimentacaoContratualNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 3; //Solicitação de Movimentação Contratual
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private void AtualizarColaborador(MovimentacaoContratualModel MovimentacaoContratual)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            ColaboradorEmpregadorFacade colaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();

            colaboradorFacade.MovimentacaoContratualColaboradorDadoPrincipal(MovimentacaoContratual);
            colaboradorEmpregadorFacade.MovimentacaoContratualColaboradorPagamento(MovimentacaoContratual);
        }



        private ErrorModel ValidacaoEntrada(MovimentacaoContratualModel MovimentacaoContratual)
        {
            var erroModel = new ErrorModel();

            if (MovimentacaoContratual.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else
            {
                var result = _repoCustomMovimentacaoContratual.GetMovimentacaoContratualValidation(MovimentacaoContratual);
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
