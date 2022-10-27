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
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.infrastructure.IO;

namespace lurin.meurhonline.application
{
    public class ColaboradorDocumentoAdmissionalFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultColaboradorDocumentoAdmissional;

        private static dynamic _repoCustomColaboradorDocumentoAdmissional;

        private static dynamic _repoCustomColaboradorDadoPrincipal;

        public ColaboradorDocumentoAdmissionalFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultColaboradorDocumentoAdmissional = RepositoryFactory.CreateRepository<ColaboradorDocumentoAdmissionalModel, Repository<ColaboradorDocumentoAdmissionalModel>>(_unitOfWork);
            _repoCustomColaboradorDocumentoAdmissional = RepositoryFactory.CreateRepositoryCustom<ColaboradorDocumentoAdmissionalModel, ColaboradorDocumentoAdmissionalRepository>(_unitOfWork);
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);

        }

        public dynamic BuscarDocumentoAdmissionalColaborador(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            try
            {

                var result = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissional(colaboradorDocumentoAdmissional);
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

        public dynamic BuscarDocumentoAdmissionalColaboradorPreAdmissao(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            try
            {

                var result = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorPreAdmissaoDocumentoAdmissional(colaboradorDocumentoAdmissional);
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
        public dynamic BuscarUrlDocumentoAdmissional(int documentoId)
        {
            try
            {
                var documento = BuscarDocumentoAdmissionalColaboradorPreAdmissaoPorId(documentoId);
                return FileType.PathColaboradorDocumento.Value + "\\" + documento.DocumentoNome;
                
            }
            catch (Exception ex)
            {
                Log.RecordError(ex);
                throw (ex.InnerException);
            }

        }

        public dynamic BuscarDocumentoAdmissionalColaboradorPreAdmissaoPorId(int id)
        {
            try
            {

                var result = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalPreAdmissaobyId(id);
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

        public dynamic SalvarDocumentoAdmissionalColaborador(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorDocumentoAdmissional);
                if (validacaoEntrada.Codigo == 0)
                {
                    dynamic result;
                    var documentoNome = string.Empty;
                    var colaboradorDocumentoResult = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorValidation(colaboradorDocumentoAdmissional);

                    
                    documentoNome = SalvarDocumento(colaboradorDocumentoAdmissional);
                    
                    
                    colaboradorDocumentoAdmissional.DocumentoNome = documentoNome;
                    colaboradorDocumentoAdmissional.DataCadastro = DateTime.Now;

                    _repoDefaultColaboradorDocumentoAdmissional.Add(colaboradorDocumentoAdmissional);

                    _unitOfWork.Commit();

                    result = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalEditarById(colaboradorDocumentoAdmissional.Id);

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

        public bool RemoverDocumentoPreAdmissionalColaborador(int id)
        {
            try
            {
                var resultado = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalPreAdmissaobyId(id);

                RemoverDocumento(resultado);                

                _repoDefaultColaboradorDocumentoAdmissional.Delete(resultado);

                _unitOfWork.Commit();

                return true;
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

        public bool RemoverDocumentoAdmissionalColaborador(int id)
        {
            try
            {
                var resultado = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalbyId(id);

                RemoverDocumento(resultado);

                _repoDefaultColaboradorDocumentoAdmissional.Delete(resultado);

                _unitOfWork.Commit();

                return true;
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

        public dynamic BuscarArquivoDocumentoAnexoColaborador(int id)
        {
            dynamic result;

            var resultDependente = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalbyId(id);

            if (resultDependente != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorDocumento.Value, resultDependente.DocumentoNome);
                if (!string.IsNullOrEmpty(imageBase64))
                {
                    result = imageBase64;
                }
                else
                {
                    result = "Documento não encontrado";
                }
            }
            else
            {
                result = "Registro não encontrado";
            }

            return result;

        }

        public dynamic BuscarArquivoDocumentoAnexoPreAdmissaoColaborador(int id)
        {
            dynamic result;

            var resultDependente = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorDocumentoAdmissionalPreAdmissaobyId(id);

            if (resultDependente != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorDocumento.Value, resultDependente.DocumentoNome);
                if (!string.IsNullOrEmpty(imageBase64))
                {
                    result = imageBase64;
                }
                else
                {
                    result = "Documento não encontrado";
                }
            }
            else
            {
                result = "Registro não encontrado";
            }

            return result;

        }

        private string SalvarDocumento(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            string documentoNome = string.Empty;
            if (!string.IsNullOrEmpty(colaboradorDocumentoAdmissional.DocumentoBase64))
            {

                if (colaboradorDocumentoAdmissional.ColaboradorId != 0)
                {
                    colaboradorDocumentoAdmissional.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorDocumentoAdmissional.ColaboradorId);

                    if (colaboradorDocumentoAdmissional.Colaborador == null)
                    {
                        colaboradorDocumentoAdmissional.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorDocumentoAdmissional.ColaboradorId);
                    }

                }

                var fileName = GeraNomeArquivo(colaboradorDocumentoAdmissional);
                string[] strings = colaboradorDocumentoAdmissional.DocumentoBase64.Split(',');

                if (strings[0] == "data:application/pdf;base64")
                {
                    documentoNome = FileOperation.SalvarDocumentoPdf(FileType.PathColaboradorDocumento.Value, colaboradorDocumentoAdmissional.DocumentoBase64, fileName);
                }
                else
                {
                    documentoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorDocumento.Value, colaboradorDocumentoAdmissional.DocumentoBase64, fileName);
                }
 
            }

            return documentoNome;
        }

        private void RemoverDocumento(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {            
            FileOperation.ExcluirDocumentoImagem(FileType.PathColaboradorDocumento.Value, colaboradorDocumentoAdmissional.DocumentoNome);
        }

        private string AtualizarDocumento(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            string novoFotoNome = colaboradorDocumentoAdmissional.DocumentoNome;
            if (!string.IsNullOrEmpty(colaboradorDocumentoAdmissional.DocumentoBase64))
            {
                if (!string.IsNullOrEmpty(colaboradorDocumentoAdmissional.DocumentoNome))
                    FileOperation.ExcluirDocumentoImagem(FileType.PathColaboradorDocumento.Value, colaboradorDocumentoAdmissional.DocumentoNome);

                var fileName = Guid.NewGuid().ToString();
                novoFotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorDocumento.Value, colaboradorDocumentoAdmissional.DocumentoBase64, fileName);
            }

            return novoFotoNome;
        }

        public void AlteracaoCadastralCarteiraHabilitacao(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                if (!string.IsNullOrEmpty(alteracaoCadastral.CarteiraHabilitacaoNome))
                {
                    DocumentoAdmissionalFacade documentoAdmissionalFacade = new DocumentoAdmissionalFacade();
                    var documentoAdmissional = documentoAdmissionalFacade.BuscarDocumentoAdmissionalPorNome("Carteira de Habilitação");

                    var colaboradorDocumentoResult = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorCarteiraHabilitacao(alteracaoCadastral.ColaboradorId);
    
                    if (colaboradorDocumentoResult != null)
                    {
                        _repoDefaultColaboradorDocumentoAdmissional.Delete(colaboradorDocumentoResult);
                        _unitOfWork.Commit();
                    }

                    var colaboradorDocumentoAdmissional = new ColaboradorDocumentoAdmissionalModel();
                    colaboradorDocumentoAdmissional.ColaboradorId = alteracaoCadastral.ColaboradorId;
                    colaboradorDocumentoAdmissional.DocumentoAdmissionalId = documentoAdmissional.Id;
                     colaboradorDocumentoAdmissional.DocumentoNome = alteracaoCadastral.CarteiraHabilitacaoNome;
                    colaboradorDocumentoAdmissional.DataCadastro = DateTime.Now;

                    _repoDefaultColaboradorDocumentoAdmissional.Add(colaboradorDocumentoAdmissional);
                    _unitOfWork.Commit();
                    
                }
                
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

        public void AlteracaoCadastralComprovanteResidencia(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                if (!string.IsNullOrEmpty(alteracaoCadastral.ComprovanteResidenciaNome))
                {
                    DocumentoAdmissionalFacade documentoAdmissionalFacade = new DocumentoAdmissionalFacade();
                    var documentoAdmissional = documentoAdmissionalFacade.BuscarDocumentoAdmissionalPorNome("Comprovante de Residência");

                    var colaboradorDocumentoResult = _repoCustomColaboradorDocumentoAdmissional.GetColaboradorComprovanteResidencia(alteracaoCadastral.ColaboradorId);

                    if (colaboradorDocumentoResult != null)
                    {
                        _repoDefaultColaboradorDocumentoAdmissional.Delete(colaboradorDocumentoResult);
                        _unitOfWork.Commit();
                    }

                    var colaboradorDocumentoAdmissional = new ColaboradorDocumentoAdmissionalModel();

                    colaboradorDocumentoAdmissional.ColaboradorId = alteracaoCadastral.ColaboradorId;
                    colaboradorDocumentoAdmissional.DocumentoAdmissionalId = documentoAdmissional.Id;
                    colaboradorDocumentoAdmissional.DocumentoNome = alteracaoCadastral.ComprovanteResidenciaNome;
                    colaboradorDocumentoAdmissional.DataCadastro = DateTime.Now;

                    _repoDefaultColaboradorDocumentoAdmissional.Add(colaboradorDocumentoAdmissional);
                    _unitOfWork.Commit();
                    
                }
                
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

        private ErrorModel ValidacaoEntrada(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            var erroModel = new ErrorModel();

            if (colaboradorDocumentoAdmissional.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Colaborador";
            }
            else if (colaboradorDocumentoAdmissional.DocumentoAdmissionalId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Documento";
            }
            else if (string.IsNullOrEmpty(colaboradorDocumentoAdmissional.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Imagem do Documento";
            }

            return erroModel;
        }
        private string GeraNomeArquivo(ColaboradorDocumentoAdmissionalModel colaboradorDocumentoAdmissional)
        {
            var tipoDocumento = string.Empty;

            switch (colaboradorDocumentoAdmissional.DocumentoAdmissionalId)
            {
                case 1:
                    tipoDocumento = DocumentoAdmissionalEnum.CarteiraDeHabilitação.ToString();
                    break;
                case 2:
                    tipoDocumento = DocumentoAdmissionalEnum.ComprovanteDeResidencia.ToString();
                    break;
                case 3:
                    tipoDocumento = DocumentoAdmissionalEnum.RG.ToString();
                    break;
                case 4:
                    tipoDocumento = DocumentoAdmissionalEnum.CPF.ToString();
                    break;
                case 5:
                    tipoDocumento = DocumentoAdmissionalEnum.CertidaoNascimentoCasamento.ToString();
                    break;
                case 6:
                    tipoDocumento = DocumentoAdmissionalEnum.PIS.ToString();
                    break;
            }
            //var documentoNome = colaboradorDocumentoAdmissional.Colaborador.Nome + "-" + tipoDocumento + "-" + DateTime.Now.ToString("G").Replace(" ", "-").Replace("/","-").Replace(":","-");
            var documentoNome = colaboradorDocumentoAdmissional.Colaborador.Nome + "-" + tipoDocumento + "-" + DateTime.Now.ToString("G").Replace(" ", "-").Replace("/","-").Replace(":","-");
            return documentoNome;
        }
    }
}
