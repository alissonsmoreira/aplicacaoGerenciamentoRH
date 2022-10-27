using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class LinhaVTFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultLinhaVT;

        private static dynamic _repoCustomLinhaVT;

        public LinhaVTFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultLinhaVT = RepositoryFactory.CreateRepository<LinhaVTModel, Repository<LinhaVTModel>>(_unitOfWork);
            _repoCustomLinhaVT = RepositoryFactory.CreateRepositoryCustom<LinhaVTModel, LinhaVTRepository>(_unitOfWork);

        }

        public dynamic BuscarLinhaVT(LinhaVTModel LinhaVT)
        {
            try
            {
                var result = _repoCustomLinhaVT.GetLinhaVT(LinhaVT);

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

        public dynamic BuscarLinhaVTPorId(int id)
        {
            try
            {
                var result = _repoCustomLinhaVT.GetLinhaVTbyId(id);

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

        public dynamic BuscarLinhaVTPorOperadoraVTId(int operadoraVTId)
        {
            try
            {
                var result = _repoCustomLinhaVT.GetLinhaVTbyOperadoraVTId(operadoraVTId);

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


        public dynamic AdicionarLinhaVT(LinhaVTModel LinhaVT)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(LinhaVT);
                if (validacaoEntrada.Codigo == 0)
                {
                    LinhaVT.DataCadastro = DateTime.Now;
                    _repoDefaultLinhaVT.Add(LinhaVT);
                    _unitOfWork.Commit();

                    var result = _repoCustomLinhaVT.GetLinhaVTbyId(LinhaVT.Id);

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

        public dynamic EditarLinhaVT(LinhaVTModel LinhaVT)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(LinhaVT);
                if (validacaoEntrada.Codigo == 0)
                {
                    var LinhaVTResult = _repoCustomLinhaVT.GetLinhaVTbyId(LinhaVT.Id);

                    if (LinhaVTResult != null)
                    {
                        LinhaVTResult.NomeLinha = LinhaVT.NomeLinha;
                        LinhaVTResult.ValorLinha = LinhaVT.ValorLinha;
                        LinhaVTResult.OperadoraVTId = LinhaVT.OperadoraVTId;

                        _unitOfWork.Commit();

                        result = _repoCustomLinhaVT.GetLinhaVTbyId(LinhaVTResult.Id);
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

        public dynamic ExcluirLinhaVT(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomLinhaVT.GetLinhaVTbyId(id);

                if (result != null)
                {
                    _repoDefaultLinhaVT.Delete(result);
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

        private ErrorModel ValidacaoEntrada(LinhaVTModel linhaVT)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(linhaVT.NomeLinha))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Linha";
            }
            
            else if (linhaVT.ValorLinha == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Valor da Linha";
            }
            else if (linhaVT.OperadoraVTId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Operadora";
            }
            else
            {
                var result = _repoCustomLinhaVT.GetLinhaVTValidation(linhaVT);
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
