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
    public class TipoMaoObraFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultTipoMaoObra;
        private static dynamic _repoCustomTipoMaoObra;

        public TipoMaoObraFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultTipoMaoObra = RepositoryFactory.CreateRepository<TipoMaoObraModel, Repository<TipoMaoObraModel>>(_unitOfWork);
            _repoCustomTipoMaoObra = RepositoryFactory.CreateRepositoryCustom<TipoMaoObraModel, TipoMaoObraRepository>(_unitOfWork);
        }

        public dynamic BuscarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            try
            {
                var result = _repoCustomTipoMaoObra.GetTipoMaoObra(tipoMaoObra);

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

        public dynamic BuscarTudoTipoMaoObra()
        {
            try
            {
                var result = _repoDefaultTipoMaoObra.GetAll();

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

        public dynamic AdicionarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(tipoMaoObra);
                if (validacaoEntrada.Codigo == 0)
                {
                    tipoMaoObra.DataCadastro = DateTime.Now;
                    _repoDefaultTipoMaoObra.Add(tipoMaoObra);
                    _unitOfWork.Commit();

                    var result = _repoCustomTipoMaoObra.GetTipoMaoObrabyId(tipoMaoObra.Id);

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

        public dynamic EditarTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(tipoMaoObra);
                if (validacaoEntrada.Codigo == 0)
                {
                    var tipoMaoObraResult = _repoCustomTipoMaoObra.GetTipoMaoObrabyId(tipoMaoObra.Id);

                    if (tipoMaoObraResult != null)
                    {
                        tipoMaoObraResult.Codigo = tipoMaoObra.Codigo;
                        tipoMaoObraResult.Nome = tipoMaoObra.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomTipoMaoObra.GetTipoMaoObrabyId(tipoMaoObraResult.Id);
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

        public dynamic ExcluirTipoMaoObra(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomTipoMaoObra.GetTipoMaoObrabyId(id);
                
                if (result != null)
                {
                    _repoDefaultTipoMaoObra.Delete(result);
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
        private ErrorModel ValidacaoEntrada(TipoMaoObraModel tipoMaoObra)
        {
            var erroModel = new ErrorModel();

            if (tipoMaoObra.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código";
            }
            else if (string.IsNullOrEmpty(tipoMaoObra.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else
            {
                var result = _repoCustomTipoMaoObra.GetTipoMaoObraValidation(tipoMaoObra);
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
