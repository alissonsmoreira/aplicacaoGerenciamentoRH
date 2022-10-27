using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.IO;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;


namespace lurin.meurhonline.application
{
    public class DependenteFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultDependente;
        private static dynamic _repoCustomDependente;

        public DependenteFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultDependente = RepositoryFactory.CreateRepository<DependenteModel, Repository<DependenteModel>>(_unitOfWork);
            _repoCustomDependente = RepositoryFactory.CreateRepositoryCustom<DependenteModel, DependenteRepository>(_unitOfWork);
        }

        public dynamic BuscarDependente(DependenteModel dependente)
        {
            try
            {                
                var resultRepo = _repoCustomDependente.GetDependente(dependente);

                
                var result = new List<DependenteModel>();
                foreach (var resultFor in resultRepo)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

                    var resultTitular = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.ColaboradorId);
                    resultFor.TitularId = resultTitular.Id;
                    resultFor.TitularNome = resultTitular.Nome;

                    result.Add(resultFor);
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

        public dynamic BuscarDependentePorId(int id)
        {
            try
            {
                DependenteModel result = _repoCustomDependente.GetDependentebyId(id);

                if (result != null)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    ColaboradorModel resultColaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(result.ColaboradorId);

                    result.TitularId = resultColaborador.Id;
                    result.TitularNome = resultColaborador.Nome;
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

        public dynamic BuscarDependentePorIds(IEnumerable<int> ids)
        {
            try
            {
                var result = _repoCustomDependente.GetDependentebyIds(ids);

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
        
        public dynamic BuscarDependentePorColaboradorId(int id)
        {
            try
            {
                var resultRepo = _repoCustomDependente.GetDependentebyColaboradorId(id);


                var result = new List<DependenteModel>();
                foreach (var resultFor in resultRepo)
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();

                    var resultTitular = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(resultFor.ColaboradorId);
                    resultFor.TitularId = resultTitular.Id;
                    resultFor.TitularNome = resultTitular.Nome;

                    result.Add(resultFor);
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
        public dynamic AdicionarDependente(DependenteModel dependente)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(dependente);
                if (validacaoEntrada.Codigo == 0)
                {
                    var documentoNome = SalvarDocumento(dependente);

                    dependente.DocumentoNome = documentoNome;
                    dependente.DataCadastro = DateTime.Now;
                    _repoDefaultDependente.Add(dependente);
                    _unitOfWork.Commit();

                    var result = _repoCustomDependente.GetDependentebyId(dependente.Id);
                    AdicionarDependenteNotificacao(dependente.Id);

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

        public dynamic EditarDependente(DependenteModel dependente)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(dependente);
                if (validacaoEntrada.Codigo == 0)
                {
                    var dependenteResult = _repoCustomDependente.GetDependentebyId(dependente.Id);

                    if (dependenteResult != null)
                    {
                        dependenteResult.DocumentoBase64 = dependente.DocumentoBase64;
                        var documentoNome = AtualizarDocumento(dependenteResult);

                        dependenteResult.Nome = dependente.Nome;
                        dependenteResult.CPF = dependente.CPF;
                        dependenteResult.Sexo = dependente.Sexo;
                        dependenteResult.DataNascimento = dependente.DataNascimento;
                        dependenteResult.NomeMae = dependente.NomeMae;
                        dependenteResult.GrauDependencia = dependente.GrauDependencia;
                        dependenteResult.ColaboradorId = dependente.ColaboradorId;
                        dependenteResult.DocumentoNome = documentoNome;

                        _unitOfWork.Commit();

                        result = _repoCustomDependente.GetDependentebyId(dependenteResult.Id);
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

        public dynamic ExcluirDependente(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomDependente.GetDependentebyId(id);

                if (result != null)
                {
                    FileOperation.ExcluirDocumentoImagem(FileType.PathDependenteDocumento.Value, result.DocumentoNome);
                    _repoDefaultDependente.Delete(result);
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

        private static void AdicionarDependenteNotificacao(int dependenteId)
        {
            
            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 1; //Cadastro de Dependente
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;            
            notificacao.ById = dependenteId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        public dynamic BuscarArquivo(int id)
        {
            dynamic result;

            var resultDependente = _repoCustomDependente.GetDependentebyId(id);

            if (resultDependente != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathDependenteDocumento.Value, resultDependente.DocumentoNome);
                if (! string.IsNullOrEmpty(imageBase64))
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

        private string SalvarDocumento(DependenteModel dependente)
        {
            string documentoNome = string.Empty;
            if (!string.IsNullOrEmpty(dependente.DocumentoBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                documentoNome = FileOperation.SalvarDocumentoImagem(FileType.PathDependenteDocumento.Value, dependente.DocumentoBase64, fileName);
            }

            return documentoNome;
        }

        private string AtualizarDocumento(DependenteModel dependente)
        {
            string novoDocumentoNome = dependente.DocumentoNome;
            if (!string.IsNullOrEmpty(dependente.DocumentoBase64))
            {
                if (!string.IsNullOrEmpty(dependente.DocumentoNome))
                    FileOperation.ExcluirDocumentoImagem(FileType.PathDependenteDocumento.Value, dependente.DocumentoNome);

                var fileName = Guid.NewGuid().ToString();
                novoDocumentoNome = FileOperation.SalvarDocumentoImagem(FileType.PathDependenteDocumento.Value, dependente.DocumentoBase64, fileName);
            }

            return novoDocumentoNome;
        }

        private ErrorModel ValidacaoEntrada(DependenteModel dependente)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(dependente.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else if (string.IsNullOrEmpty(dependente.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o CPF";
            }
            else if (string.IsNullOrEmpty(dependente.Sexo))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Sexo";
            }
            else if (dependente.DataNascimento == null || dependente.DataNascimento == DateTime.MinValue)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Data de Nascimento";
            }
            else if (string.IsNullOrEmpty(dependente.NomeMae))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Mãe";
            }
            else if (string.IsNullOrEmpty(dependente.GrauDependencia))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Grau de Dependência";
            }
            else if (dependente.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Titular";
            }
            else
            {
                var result = _repoCustomDependente.GetDependenteValidation(dependente);
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
