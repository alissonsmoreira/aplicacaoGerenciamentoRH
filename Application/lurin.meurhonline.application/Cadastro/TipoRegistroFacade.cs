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
    public class TipoRegistroFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultTipoRegistro;
        private static dynamic _repoCustomTipoRegistro;

        public TipoRegistroFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultTipoRegistro = RepositoryFactory.CreateRepository<TipoRegistroModel, Repository<TipoRegistroModel>>(_unitOfWork);
            _repoCustomTipoRegistro = RepositoryFactory.CreateRepositoryCustom<TipoRegistroModel, TipoRegistroRepository>(_unitOfWork);
        }

        public dynamic BuscarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            try
            {
                var result = _repoCustomTipoRegistro.GetTipoRegistro(tipoRegistro);

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

        public dynamic BuscarTudoTipoRegistro()
        {
            try
            {
                var result = _repoDefaultTipoRegistro.GetAll();

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
        public dynamic AdicionarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(tipoRegistro);
                if (validacaoEntrada.Codigo == 0)
                {
                    tipoRegistro.DataCadastro = DateTime.Now;
                    _repoDefaultTipoRegistro.Add(tipoRegistro);
                    _unitOfWork.Commit();

                    var result = _repoCustomTipoRegistro.GetTipoRegistrobyId(tipoRegistro.Id);

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

        public dynamic EditarTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(tipoRegistro);
                if (validacaoEntrada.Codigo == 0)
                {
                    var tipoRegistroResult = _repoCustomTipoRegistro.GetTipoRegistrobyId(tipoRegistro.Id);

                    if (tipoRegistroResult != null)
                    {
                        tipoRegistroResult.Nome = tipoRegistro.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomTipoRegistro.GetTipoRegistrobyId(tipoRegistroResult.Id);
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

        public dynamic ExcluirTipoRegistro(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomTipoRegistro.GetTipoRegistrobyId(id);

                if (result != null)
                {
                    _repoDefaultTipoRegistro.Delete(result);
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
        private ErrorModel ValidacaoEntrada(TipoRegistroModel tipoRegistro)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(tipoRegistro.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Tipo";
            }
            else
            {
                var result = _repoCustomTipoRegistro.GetTipoRegistroValidation(tipoRegistro);
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
