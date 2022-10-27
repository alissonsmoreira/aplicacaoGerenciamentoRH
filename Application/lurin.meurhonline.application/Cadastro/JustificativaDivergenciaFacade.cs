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
    public class JustificativaDivergenciaFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultJustificativa;
        private static dynamic _repoCustomJustificativa;

        public JustificativaDivergenciaFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultJustificativa = RepositoryFactory.CreateRepository<JustificativaDivergenciaModel, Repository<JustificativaDivergenciaModel>>(_unitOfWork);
            _repoCustomJustificativa = RepositoryFactory.CreateRepositoryCustom<JustificativaDivergenciaModel, JustificativaDivergenciaRepository>(_unitOfWork);
        }

        public dynamic BuscarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            try
            {
                var result = _repoCustomJustificativa.GetJustificativaDivergencia(justificativaDivergencia);

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


        public dynamic BuscarTodasJustificativasDivergencia()
        {
            try
            {
                var result = _repoCustomJustificativa.GetTodasJustificativasDivergencia();

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

        public dynamic AdicionarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(justificativaDivergencia);
                if (validacaoEntrada.Codigo == 0)
                {
                    justificativaDivergencia.DataCadastro = DateTime.Now;
                    _repoDefaultJustificativa.Add(justificativaDivergencia);
                    _unitOfWork.Commit();

                    var result = _repoCustomJustificativa.GetJustificativaDivergenciabyId(justificativaDivergencia.Id);

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

        public dynamic EditarJustificativaDivergencia(JustificativaDivergenciaModel justificativaDivergencia)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(justificativaDivergencia);
                if (validacaoEntrada.Codigo == 0)
                {
                    var justificativaDivergenciaResult = _repoCustomJustificativa.GetJustificativaDivergenciabyId(justificativaDivergencia.Id);

                    if (justificativaDivergenciaResult != null)
                    {
                        justificativaDivergenciaResult.Tipo = justificativaDivergencia.Tipo;

                        _unitOfWork.Commit();

                        result = _repoCustomJustificativa.GetJustificativaDivergenciabyId(justificativaDivergenciaResult.Id);
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

        public dynamic ExcluirJustificativaDivergencia(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomJustificativa.GetJustificativaDivergenciabyId(id);

                if (result != null)
                {
                    _repoDefaultJustificativa.Delete(result);
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
        private ErrorModel ValidacaoEntrada(JustificativaDivergenciaModel justificativaDivergencia)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(justificativaDivergencia.Tipo))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Tipo";
            }
            else
            {
                var result = _repoCustomJustificativa.GetJustificativaDivergenciaValidation(justificativaDivergencia);
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
