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
    public class DocumentoAdmissionalFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultDocumentoAdmissional;
        private static dynamic _repoCustomDocumentoAdmissional;

        public DocumentoAdmissionalFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultDocumentoAdmissional = RepositoryFactory.CreateRepository<DocumentoAdmissionalModel, Repository<DocumentoAdmissionalModel>>(_unitOfWork);
            _repoCustomDocumentoAdmissional = RepositoryFactory.CreateRepositoryCustom<DocumentoAdmissionalModel, DocumentoAdmissionalRepository>(_unitOfWork);
        }

        public dynamic BuscarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            try
            {
                var result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissional(DocumentoAdmissional);

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
        public dynamic BuscarTudoDocumentoAdmissional()
        {
            try
            {
                var result = _repoDefaultDocumentoAdmissional.GetAll();

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
        public dynamic BuscarDocumentoAdmissionalPadrao()
        {
            try
            {
                var result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalPadrao();

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
        public dynamic BuscarDocumentoAdmissionalPorNome(string nome)
        {
            try
            {
                var result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalbyName(nome);

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
        public dynamic AdicionarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(DocumentoAdmissional);
                if (validacaoEntrada.Codigo == 0)
                {
                    DocumentoAdmissional.DataCadastro = DateTime.Now;
                    _repoDefaultDocumentoAdmissional.Add(DocumentoAdmissional);
                    _unitOfWork.Commit();

                    var result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalbyId(DocumentoAdmissional.Id);

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

        public dynamic EditarDocumentoAdmissional(DocumentoAdmissionalModel DocumentoAdmissional)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(DocumentoAdmissional);
                if (validacaoEntrada.Codigo == 0)
                {
                    var DocumentoAdmissionalResult = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalbyId(DocumentoAdmissional.Id);

                    if (DocumentoAdmissionalResult != null)
                    {
                        DocumentoAdmissionalResult.Nome = DocumentoAdmissional.Nome;
                        DocumentoAdmissionalResult.PermiteVisualizar = DocumentoAdmissional.PermiteVisualizar;

                        _unitOfWork.Commit();

                        result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalbyId(DocumentoAdmissionalResult.Id);
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

        public dynamic ExcluirDocumentoAdmissional(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalbyId(id);

                if (result != null)
                {
                    _repoDefaultDocumentoAdmissional.Delete(result);
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

        private ErrorModel ValidacaoEntrada(DocumentoAdmissionalModel documentoAdmissional)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(documentoAdmissional.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else
            {
                var result = _repoCustomDocumentoAdmissional.GetDocumentoAdmissionalValidation(documentoAdmissional);
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
