using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.domain.interfaces;
using System.Collections.ObjectModel;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.application
{
    public class CartaoPontoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultCartaoPonto;
        private static dynamic _repoDefaultCartaoPontoDetalhe;
        private static dynamic _repoDefaultCartaoPontoCabecalho;
        private static dynamic _repoDefaultCartaoPontoLog;

        private static dynamic _repoCustomColaboradorDadoPrincipal;
        private static dynamic _repoCustomCartaoPonto;
        private static dynamic _repoCustomCartaoPontoDetalhe;
        private static dynamic _repoCustomCartaoPontoCabecalho;

        private static dynamic _domainCartaoPonto;

        public CartaoPontoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCartaoPonto = RepositoryFactory.CreateRepository<CartaoPontoModel, Repository<CartaoPontoModel>>(_unitOfWork);
            _repoDefaultCartaoPontoDetalhe = RepositoryFactory.CreateRepository<CartaoPontoDetalheModel, Repository<CartaoPontoDetalheModel>>(_unitOfWork);
            _repoDefaultCartaoPontoCabecalho = RepositoryFactory.CreateRepository<CartaoPontoCabecalhoModel, Repository<CartaoPontoCabecalhoModel>>(_unitOfWork);
            _repoDefaultCartaoPontoLog = RepositoryFactory.CreateRepository<CartaoPontoLogModel, Repository<CartaoPontoLogModel>>(_unitOfWork);

            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
            _repoCustomCartaoPonto = RepositoryFactory.CreateRepositoryCustom<CartaoPontoModel, CartaoPontoRepository>(_unitOfWork);
            _repoCustomCartaoPontoDetalhe = RepositoryFactory.CreateRepositoryCustom<CartaoPontoDetalheModel, CartaoPontoDetalheRepository>(_unitOfWork);
            _repoCustomCartaoPontoCabecalho = RepositoryFactory.CreateRepositoryCustom<CartaoPontoCabecalhoModel, CartaoPontoCabecalhoRepository>(_unitOfWork);

            _domainCartaoPonto = DomainFactory.CreateDomain<CartaoPontoModel, CartaoPontoDomain>(_unitOfWork);
        }

        public dynamic BuscarCartaoPontoPorId(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCartaoPonto.GetCartaoPontoById(id);

                if (result == null)
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

        public dynamic BuscarCartaoPontoPorColaboradorIdMesAno(int colaboradorId, string mes, string ano)
        {
            List<CartaoPontoModel> cartoPontoResult = new List<CartaoPontoModel>();

            try
            {
                var colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorId);

                if (colaborador == null)
                {
                    CartaoPontoModel result = new CartaoPontoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Colaborador não existe"
                        }
                    };

                    cartoPontoResult.Add(result);
                }
                else
                {
                    cartoPontoResult = _repoCustomCartaoPonto.GetCartaoPontoByColaboradorIdMesAno(colaborador.Id, mes, ano);
                }

                return cartoPontoResult;
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

        public dynamic BuscarCartaoPontoPorColaboradorId(int colaboradorId)
        {
            List<CartaoPontoModel> cartaoPontoResult = new List<CartaoPontoModel>();

            try
            {
                var colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorId);

                if (colaborador == null)
                {
                    CartaoPontoModel result = new CartaoPontoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Colaborador não existe"
                        }
                    };

                    cartaoPontoResult.Add(result);
                }
                else
                {
                    var cartaoPontoRepo = _repoCustomCartaoPonto.GetCartaoPontoByColaboradorId(colaborador.Id);

                    foreach (var resultFor in cartaoPontoRepo)
                    {
                        var solicitacaoStatusModel = new SolicitacaoStatusModel();
                        solicitacaoStatusModel.Id = resultFor.SolicitacaoStatusId;
                        solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                        resultFor.SolicitacaoStatus = solicitacaoStatusModel;
                        cartaoPontoResult.Add(resultFor);
                    }

                }

                return cartaoPontoResult;
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

        public dynamic ExcluirCartaoPontoPorId(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCartaoPonto.GetCartaoPontoById(id);

                if (result != null)
                {
                    _repoDefaultCartaoPonto.Delete(result);
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

        public dynamic AdicionarCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            var validaCartaoPonto = new CartaoPontoModel();
            IList<CartaoPontoLogModel> resultList = new List<CartaoPontoLogModel>();
            CartaoPontoLogModel resultItem = new CartaoPontoLogModel();
            List<CartaoPontoModel> resultCartaoPonto = new List<CartaoPontoModel>();

            try
            {
                validaCartaoPonto = ValidacaoEntrada(cartaoPonto);
                if (validaCartaoPonto.Erro.Codigo == 0)
                {
                    if (_domainCartaoPonto.DecodeArquivoTxtCartaoPonto(cartaoPonto))
                    {
                        ApagarCartaoPontoLog();
                        cartaoPonto.DataCadastro = DateTime.Now;
                        cartaoPonto.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;
                        resultCartaoPonto = _domainCartaoPonto.AdicionarCartaoPonto(cartaoPonto);

                        foreach (var itemCartaoPonto in resultCartaoPonto)
                        {
                            var resultProcessamento = ValidacaoProcessamento(itemCartaoPonto);
                            if (resultProcessamento == null)
                            {
                                GravaCartaoPonto(itemCartaoPonto);
                            }
                            else
                            {
                                GravaCartaoPontoLog(resultProcessamento);
                                resultList.Add(resultProcessamento);
                            }
                        }
                    }
                    else
                    {
                        resultItem.DataCadastro = DateTime.Now;
                        resultItem.LogErro = "Erro na conversão do arquivo TXT.";
                        resultList.Add(resultItem);
                    }
                }
                else
                {
                    resultItem.DataCadastro = DateTime.Now;
                    resultItem.LogErro = validaCartaoPonto.Erro.Descricao;
                    resultItem.Matricula = resultItem.Matricula != null ? resultItem.Matricula : string.Empty;
                    resultList.Add(resultItem);
                }

                return resultList;
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

        private void GravaCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            _repoDefaultCartaoPonto.Add(cartaoPonto);
            _unitOfWork.Commit();
        }

        private void ApagarCartaoPontoLog()
        {
            var logs = _repoDefaultCartaoPontoLog.GetAll();
            _repoDefaultCartaoPontoLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private void GravaCartaoPontoLog(CartaoPontoLogModel cartaoPontoLog)
        {
            _repoDefaultCartaoPontoLog.Add(cartaoPontoLog);
            _unitOfWork.Commit();
        }

        public dynamic AprovarCartaoPonto(int id)
        {
            dynamic result;

            try
            {
                var cartaoPontoResult = _repoCustomCartaoPonto.GetCartaoPontoById(id);

                if (cartaoPontoResult != null)
                {
                    if (cartaoPontoResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        cartaoPontoResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        cartaoPontoResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomCartaoPonto.GetCartaoPontoById(cartaoPontoResult.Id);

                        var solicitacaoStatusModel = new SolicitacaoStatusModel();
                        solicitacaoStatusModel.Id = result.SolicitacaoStatusId;
                        solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = solicitacaoStatusModel;

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
        public dynamic ReprovarCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            dynamic result;

            try
            {
                var cartaoPontoResult = _repoCustomCartaoPonto.GetCartaoPontoById(cartaoPonto.Id);

                if (cartaoPontoResult != null)
                {
                    if (cartaoPontoResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        cartaoPontoResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        cartaoPontoResult.DataConclusao = DateTime.Now;
                        cartaoPontoResult.MotivoReprovacao = cartaoPonto.MotivoReprovacao;

                        _unitOfWork.Commit();

                        result = _repoCustomCartaoPonto.GetCartaoPontoById(cartaoPontoResult.Id);

                        var solicitacaoStatusModel = new SolicitacaoStatusModel();
                        solicitacaoStatusModel.Id = result.SolicitacaoStatusId;
                        solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = solicitacaoStatusModel;

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

        private CartaoPontoModel ValidacaoEntrada(CartaoPontoModel cartaoPonto)
        {
            cartaoPonto.Erro = new ErrorModel();

            if (string.IsNullOrEmpty(cartaoPonto.DocumentoBase64))
            {
                cartaoPonto.Erro.Codigo = 600;
                cartaoPonto.Erro.Descricao = "Arquivo Invalido";
            }
            else if (string.IsNullOrEmpty(cartaoPonto.Mes))
            {
                cartaoPonto.Erro.Codigo = 600;
                cartaoPonto.Erro.Descricao = "Mês não informado";
            }
            else if (string.IsNullOrEmpty(cartaoPonto.Ano))
            {
                cartaoPonto.Erro.Codigo = 600;
                cartaoPonto.Erro.Descricao = "Ano não informado";
            }

            return cartaoPonto;
        }

        private CartaoPontoLogModel ValidacaoProcessamento(CartaoPontoModel cartaoPonto)
        {
            CartaoPontoLogModel result = null;

            foreach (var item in cartaoPonto.CartaoPontoCabecalho)
            {
                cartaoPonto.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyMatricula(item.Matricula);


                if (cartaoPonto.Colaborador == null)
                {
                    result = new CartaoPontoLogModel();
                    result.DataCadastro = DateTime.Now;
                    result.Matricula = item.Matricula;
                    result.LogErro = "Matrícula não encontrada";
                }
                else
                {
                    var resultCustom = _repoCustomCartaoPonto.GetCartaoPontoByColaboradorIdMesAno(cartaoPonto.Colaborador.Id, cartaoPonto.Mes, cartaoPonto.Ano);

                    if (resultCustom?.Count > 0)
                    {
                        result = new CartaoPontoLogModel();
                        result.DataCadastro = DateTime.Now;
                        result.Matricula = item.Matricula;
                        result.LogErro = "Cartao de Ponto já importado";
                    }
                }
            }

            return result;
        }
    }
}