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
    public class CategoriaSalarialFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;        
        private static dynamic _repoDefaultCategoria;        
        private static dynamic _repoCustomCategoria;

        public CategoriaSalarialFacade()
        {
            _unitOfWork = new UnitOfWork();            

            _repoDefaultCategoria = RepositoryFactory.CreateRepository<CategoriaSalarialModel, Repository<CategoriaSalarialModel>>(_unitOfWork);
            _repoCustomCategoria = RepositoryFactory.CreateRepositoryCustom<CategoriaSalarialModel, CategoriaSalarialRepository>(_unitOfWork);
        }

        public dynamic BuscarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            try
            {
                var result = _repoCustomCategoria.GetCategoriaSalarial(categoriaSalarial);

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

        public dynamic AdicionarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(categoriaSalarial);
                if (validacaoEntrada.Codigo == 0)
                {
                    categoriaSalarial.DataCadastro = DateTime.Now;
                    _repoDefaultCategoria.Add(categoriaSalarial);
                    _unitOfWork.Commit();

                    var result = _repoCustomCategoria.GetCategoriaSalarialbyId(categoriaSalarial.Id);

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

        public dynamic EditarCategoriaSalarial(CategoriaSalarialModel categoriaSalarial)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(categoriaSalarial);
                if (validacaoEntrada.Codigo == 0)
                {
                    var categoriaResult = _repoCustomCategoria.GetCategoriaSalarialbyId(categoriaSalarial.Id);

                    if (categoriaResult != null)
                    {
                        categoriaResult.Nome = categoriaSalarial.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomCategoria.GetCategoriaSalarialbyId(categoriaResult.Id);
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

        public dynamic ExcluirCategoriaSalarial(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCategoria.GetCategoriaSalarialbyId(id);

                if (result != null)
                {
                    _repoDefaultCategoria.Delete(result);
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
        private ErrorModel ValidacaoEntrada(CategoriaSalarialModel categoriaSalarial)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(categoriaSalarial.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Categoria";
            }
            else
            {
                var result = _repoCustomCategoria.GetCategoriaSalarialValidation(categoriaSalarial);
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
