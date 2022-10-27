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
    public class MarmitexFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultMarmitex;
        private static dynamic _repoCustomMarmitex;

        public MarmitexFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultMarmitex = RepositoryFactory.CreateRepository<MarmitexModel, Repository<MarmitexModel>>(_unitOfWork);
            _repoCustomMarmitex = RepositoryFactory.CreateRepositoryCustom<MarmitexModel, MarmitexRepository>(_unitOfWork);
        }

        public dynamic BuscarMarmitex(MarmitexModel marmitex)
        {
            try
            {
                var result = _repoCustomMarmitex.GetMarmitex(marmitex);

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

        public dynamic AdicionarMarmitex(MarmitexModel marmitex)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(marmitex);
                if (validacaoEntrada.Codigo == 0)
                {
                    marmitex.DataCadastro = DateTime.Now;
                    _repoDefaultMarmitex.Add(marmitex);
                    _unitOfWork.Commit();

                    var result = _repoCustomMarmitex.GetMarmitexbyId(marmitex.Id);

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

        public dynamic EditarMarmitex(MarmitexModel marmitex)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(marmitex);
                if (validacaoEntrada.Codigo == 0)
                {
                    var marmitexResult = _repoCustomMarmitex.GetMarmitexbyId(marmitex.Id);

                    if (marmitexResult != null)
                    {
                        marmitexResult.Tipo = marmitex.Tipo;

                        _unitOfWork.Commit();

                        result = _repoCustomMarmitex.GetMarmitexbyId(marmitexResult.Id);
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

        public dynamic ExcluirMarmitex(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomMarmitex.GetMarmitexbyId(id);
                if (result != null)
                {

                    _repoDefaultMarmitex.Delete(result);
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
        private ErrorModel ValidacaoEntrada(MarmitexModel marmitex)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(marmitex.Tipo))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Tipo";
            }
            else
            {
                var result = _repoCustomMarmitex.GetMarmitexValidation(marmitex);
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
