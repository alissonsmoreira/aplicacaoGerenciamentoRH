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
    public class MotivoHoraExtraFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultMotivoHoraExtra;
        private static dynamic _repoCustomMotivoHoraExtra;

        public MotivoHoraExtraFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultMotivoHoraExtra = RepositoryFactory.CreateRepository<MotivoHoraExtraModel, Repository<MotivoHoraExtraModel>>(_unitOfWork);
            _repoCustomMotivoHoraExtra = RepositoryFactory.CreateRepositoryCustom<MotivoHoraExtraModel, MotivoHoraExtraRepository>(_unitOfWork);
        }

        public dynamic BuscarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            try
            {
                var result = _repoCustomMotivoHoraExtra.GetMotivoHoraExtra(motivoHoraExtra);

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

        public dynamic AdicionarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(motivoHoraExtra);
                if (validacaoEntrada.Codigo == 0)
                {
                    motivoHoraExtra.DataCadastro = DateTime.Now;
                    _repoDefaultMotivoHoraExtra.Add(motivoHoraExtra);
                    _unitOfWork.Commit();

                    var result = _repoCustomMotivoHoraExtra.GetMotivoHoraExtrabyId(motivoHoraExtra.Id);

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

        public dynamic EditarMotivoHoraExtra(MotivoHoraExtraModel motivoHoraExtra)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(motivoHoraExtra);
                if (validacaoEntrada.Codigo == 0)
                {
                    var motivoHoraExtraResult = _repoCustomMotivoHoraExtra.GetMotivoHoraExtrabyId(motivoHoraExtra.Id);
                    if (motivoHoraExtraResult != null)
                    {
                        motivoHoraExtraResult.Motivo = motivoHoraExtra.Motivo;

                        _unitOfWork.Commit();

                        result = _repoCustomMotivoHoraExtra.GetMotivoHoraExtrabyId(motivoHoraExtraResult.Id);
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

        public dynamic ExcluirMotivoHoraExtra(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomMotivoHoraExtra.GetMotivoHoraExtrabyId(id);

                if (result != null)
                {
                    _repoDefaultMotivoHoraExtra.Delete(result);
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
        private ErrorModel ValidacaoEntrada(MotivoHoraExtraModel motivoHoraExtra)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(motivoHoraExtra.Motivo))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Motivo Hora Extra";
            }
            else
            {
                var result = _repoCustomMotivoHoraExtra.GetMotivoHoraExtraValidation(motivoHoraExtra);
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
