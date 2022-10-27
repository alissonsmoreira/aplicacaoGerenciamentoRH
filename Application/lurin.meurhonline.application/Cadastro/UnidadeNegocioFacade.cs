using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class UnidadeNegocioFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultUnidadeNegocio;
        private static dynamic _repoCustomUnidadeNegocio;

        public UnidadeNegocioFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultUnidadeNegocio = RepositoryFactory.CreateRepository<UnidadeNegocioModel, Repository<UnidadeNegocioModel>>(_unitOfWork);
            _repoCustomUnidadeNegocio = RepositoryFactory.CreateRepositoryCustom<UnidadeNegocioModel, UnidadeNegocioRepository>(_unitOfWork);
        }

        public dynamic BuscarUnidadeNegocio(UnidadeNegocioModel unidadeNegocio)
        {
            try
            {
                var result = _repoCustomUnidadeNegocio.GetUnidadeNegocio(unidadeNegocio);

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

        public dynamic BuscarTudoUnidadeNegocio()
        {
            try
            {
                var result = _repoDefaultUnidadeNegocio.GetAll();

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


        public dynamic AdicionarUnidadeNegocio(UnidadeNegocioModel unidadeNegocio)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(unidadeNegocio);
                if (validacaoEntrada.Codigo == 0)
                {
                    unidadeNegocio.DataCadastro = DateTime.Now;
                    _repoDefaultUnidadeNegocio.Add(unidadeNegocio);
                    _unitOfWork.Commit();

                    var result = _repoCustomUnidadeNegocio.GetUnidadeNegociobyId(unidadeNegocio.Id);

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

        public dynamic EditarUnidadeNegocio(UnidadeNegocioModel unidadeNegocio)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(unidadeNegocio);
                if (validacaoEntrada.Codigo == 0)
                {
                    var UnidadeNegocioResult = _repoCustomUnidadeNegocio.GetUnidadeNegociobyId(unidadeNegocio.Id);

                    if (UnidadeNegocioResult != null)
                    {
                        UnidadeNegocioResult.Codigo = unidadeNegocio.Codigo;
                        UnidadeNegocioResult.Nome = unidadeNegocio.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomUnidadeNegocio.GetUnidadeNegociobyId(UnidadeNegocioResult.Id);
                    }
                    else
                    {
                        result = "Registro não encontrado";
                    }

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

        public dynamic ExcluirUnidadeNegocio(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomUnidadeNegocio.GetUnidadeNegociobyId(id);

                if (result != null)
                {
                    _repoDefaultUnidadeNegocio.Delete(result);
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
        private ErrorModel ValidacaoEntrada(UnidadeNegocioModel unidadeNegocio)
        {
            var erroModel = new ErrorModel();

            if (unidadeNegocio.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código";
            }
            else if (string.IsNullOrEmpty(unidadeNegocio.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else
            {
                var result = _repoCustomUnidadeNegocio.GetUnidadeNegocioValidation(unidadeNegocio);
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
