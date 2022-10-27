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

namespace lurin.meurhonline.application
{
    public class OperadoraVTBandeiraCartaoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultOperadoraVTBandeiraCartao;
        private static dynamic _repoCustomOperadoraVTBandeiraCartao;

        public OperadoraVTBandeiraCartaoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultOperadoraVTBandeiraCartao = RepositoryFactory.CreateRepository<OperadoraVTBandeiraCartaoModel, Repository<OperadoraVTBandeiraCartaoModel>>(_unitOfWork);
            _repoCustomOperadoraVTBandeiraCartao = RepositoryFactory.CreateRepositoryCustom<OperadoraVTBandeiraCartaoModel, OperadoraVTBandeiraCartaoRepository>(_unitOfWork);
        }

        public dynamic BuscarOperadoraVTBandeiraCartao(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            try
            {
                var result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartao(operadoraVTBandeiraCartao);

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

        public dynamic BuscarOperadoraVTBandeiraCartaoPorId(int id)
        {
            try
            {
                var result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaobyId(id);
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


        public dynamic BuscarTudoOperadoraVTBandeiraCartao()
        {
            try
            {
                var result = Cache.Get<List<OperadoraVTBandeiraCartaoModel>>("OperadoraVTBandeiraCartao");
                if (result == null)
                {
                    result = _repoDefaultOperadoraVTBandeiraCartao.GetAll();

                    Cache.AddItem("OperadoraVTBandeiraCartao", result, 1);
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



        public dynamic AdicionarOperadoraVTBandeiraCartao(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(operadoraVTBandeiraCartao);
                if (validacaoEntrada.Codigo == 0)
                {
                    operadoraVTBandeiraCartao.DataCadastro = DateTime.Now;
                    _repoDefaultOperadoraVTBandeiraCartao.Add(operadoraVTBandeiraCartao);
                    _unitOfWork.Commit();

                    var result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaobyId(operadoraVTBandeiraCartao.Id);

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

        public dynamic EditarOperadoraVTBandeiraCartao(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(operadoraVTBandeiraCartao);
                if (validacaoEntrada.Codigo == 0)
                {
                    var OperadoraVTBandeiraCartaoResult = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaobyId(operadoraVTBandeiraCartao.Id);

                    if (OperadoraVTBandeiraCartaoResult != null)
                    {
                        OperadoraVTBandeiraCartaoResult.Nome = operadoraVTBandeiraCartao.Nome;
                        _unitOfWork.Commit();

                        result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaobyId(OperadoraVTBandeiraCartaoResult.Id);
                    }
                    else
                        result = "Registro não encontrado";

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

        public dynamic ExcluirOperadoraVTBandeiraCartao(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaobyId(id);

                if (result != null)
                {
                    _repoDefaultOperadoraVTBandeiraCartao.Delete(result);
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

        private ErrorModel ValidacaoEntrada(OperadoraVTBandeiraCartaoModel operadoraVTBandeiraCartao)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(operadoraVTBandeiraCartao.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else
            {
                var result = _repoCustomOperadoraVTBandeiraCartao.GetOperadoraVTBandeiraCartaoValidation(operadoraVTBandeiraCartao);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }
    }
}
