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
    public class SindicatoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultSindicato;
        private static dynamic _repoCustomSindicato;

        public SindicatoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultSindicato = RepositoryFactory.CreateRepository<SindicatoModel, Repository<SindicatoModel>>(_unitOfWork);
            _repoCustomSindicato = RepositoryFactory.CreateRepositoryCustom<SindicatoModel, SindicatoRepository>(_unitOfWork);
        }

        public dynamic BuscarSindicato(SindicatoModel sindicato)
        {
            try
            {
                var result = _repoCustomSindicato.GetSindicato(sindicato);

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

        public dynamic BuscarTudoSindicato()
        {
            try
            {
                var result = _repoDefaultSindicato.GetAll();

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

        public dynamic AdicionarSindicato(SindicatoModel sindicato)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(sindicato);
                if (validacaoEntrada.Codigo == 0)
                {
                    sindicato.DataCadastro = DateTime.Now;
                    _repoDefaultSindicato.Add(sindicato);
                    _unitOfWork.Commit();

                    var result = _repoCustomSindicato.GetSindicatobyId(sindicato.Id);

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

        public dynamic EditarSindicato(SindicatoModel sindicato)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(sindicato);
                if (validacaoEntrada.Codigo == 0)
                {
                    var SindicatoResult = _repoCustomSindicato.GetSindicatobyId(sindicato.Id);

                    if (SindicatoResult != null)
                    {
                        SindicatoResult.Nome = sindicato.Nome;
                        SindicatoResult.Cnpj = sindicato.Cnpj;
                        SindicatoResult.DataBaseMes = sindicato.DataBaseMes;
                        SindicatoResult.DataBaseAno = sindicato.DataBaseAno;
                        SindicatoResult.Representante = sindicato.Representante;
                        SindicatoResult.TelefoneComercial = sindicato.TelefoneComercial;
                        SindicatoResult.TelefoneCelular = sindicato.TelefoneCelular;

                        _unitOfWork.Commit();

                        result = _repoCustomSindicato.GetSindicatobyId(SindicatoResult.Id);
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

        public dynamic ExcluirSindicato(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomSindicato.GetSindicatobyId(id);

                if (result != null)
                {
                    _repoDefaultSindicato.Delete(result);
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
        private ErrorModel ValidacaoEntrada(SindicatoModel sindicato)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(sindicato.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else if (string.IsNullOrEmpty(sindicato.Cnpj))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Cnpj";
            }
            else if (string.IsNullOrEmpty(sindicato.DataBaseMes))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Data Base Mes";
            }
            else if (string.IsNullOrEmpty(sindicato.DataBaseAno))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Data Base Ano";
            }
            else
            {
                var result = _repoCustomSindicato.GetSindicatoValidation(sindicato);
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
