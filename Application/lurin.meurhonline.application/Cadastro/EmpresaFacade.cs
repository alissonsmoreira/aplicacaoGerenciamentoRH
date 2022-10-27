using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class EmpresaFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultEmpresa;
        private static dynamic _repoDefaultEmpresaTipo;
        private static dynamic _repoDefaultEmpresaFuncionalidade;
        private static dynamic _repoDefaultEmpresaDocumentoAdmissional;
        private static dynamic _repoDefaultEmpresaEmpresaFuncionalidade;

        private static dynamic _repoCustomEmpresa;
        private static dynamic _repoCustomEmpresaFuncionalidade;
        private static dynamic _repoCustomEmpresaDocumentoAdmissional;
        private static dynamic _repoCustomEmpresaEmpresaFuncionalidade;

        public EmpresaFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultEmpresa = RepositoryFactory.CreateRepository<EmpresaModel, Repository<EmpresaModel>>(_unitOfWork);
            _repoDefaultEmpresaTipo = RepositoryFactory.CreateRepository<EmpresaTipoModel, Repository<EmpresaTipoModel>>(_unitOfWork);            
            _repoDefaultEmpresaFuncionalidade = RepositoryFactory.CreateRepository<EmpresaFuncionalidadeModel, Repository<EmpresaFuncionalidadeModel>>(_unitOfWork);
            _repoDefaultEmpresaDocumentoAdmissional = RepositoryFactory.CreateRepository<EmpresaDocumentoAdmissionalModel, Repository<EmpresaDocumentoAdmissionalModel>>(_unitOfWork);
            _repoDefaultEmpresaEmpresaFuncionalidade = RepositoryFactory.CreateRepository<EmpresaEmpresaFuncionalidadeModel, Repository<EmpresaEmpresaFuncionalidadeModel>>(_unitOfWork);

            _repoCustomEmpresa = RepositoryFactory.CreateRepositoryCustom<EmpresaModel, EmpresaRepository>(_unitOfWork);
            _repoCustomEmpresaFuncionalidade = RepositoryFactory.CreateRepositoryCustom<EmpresaFuncionalidadeModel, EmpresaFuncionalidadeRepository>(_unitOfWork);
            _repoCustomEmpresaDocumentoAdmissional = RepositoryFactory.CreateRepositoryCustom<EmpresaDocumentoAdmissionalModel, EmpresaDocumentoAdmissionalRepository>(_unitOfWork);
            _repoCustomEmpresaEmpresaFuncionalidade = RepositoryFactory.CreateRepositoryCustom<EmpresaEmpresaFuncionalidadeModel, EmpresaEmpresaFuncionalidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarEmpresa(EmpresaModel empresa)
        {
            try
            {
                var resultRepo = _repoCustomEmpresa.GetEmpresa(empresa);

                var result = new List<EmpresaModel>();
                foreach (var resultFor in resultRepo)
                {
                    var empresaStatusModel = new EmpresaStatusModel();
                    empresaStatusModel.Id = resultFor.EmpresaStatusId;
                    empresaStatusModel.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultFor.EmpresaStatusId);
                    resultFor.EmpresaStatus = empresaStatusModel;

                    if (resultFor.EmpresaTipo.Id == 2) // FILIAL
                    {
                        var resultRepoEmpresaMatriz = _repoCustomEmpresa.GetEmpresabyId(resultFor.EmpresaMatrizId);

                        var empresaMatrizModel = new EmpresaMatrizModel();
                        empresaMatrizModel.Id = resultRepoEmpresaMatriz.Id;
                        empresaMatrizModel.Nome = resultRepoEmpresaMatriz.Nome;
                        resultFor.EmpresaMatriz = empresaMatrizModel;
                    }

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

        public dynamic BuscarEmpresaPorId(int id)
        {
            try
            {
                var result = _repoCustomEmpresa.GetEmpresabyId(id);
                
                if (result != null)
                {
                    var empresaStatusModel = new EmpresaStatusModel();
                    empresaStatusModel.Id = result.EmpresaStatusId;
                    empresaStatusModel.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)result.EmpresaStatusId);
                    result.EmpresaStatus = empresaStatusModel;

                    if (result.EmpresaTipo.Nome == "Filial")
                    {
                        var resultRepoEmpresaMatriz = _repoCustomEmpresa.GetEmpresabyId(result.EmpresaMatrizId);

                        var empresaMatrizModel = new EmpresaMatrizModel();
                        empresaMatrizModel.Id = resultRepoEmpresaMatriz.Id;
                        empresaMatrizModel.Nome = resultRepoEmpresaMatriz.Nome;
                        result.EmpresaMatriz = empresaMatrizModel;
                    }
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

        public dynamic BuscarEmpresaPorCnpj(string cnpj)
        {
            try
            {
                var result = _repoCustomEmpresa.GetEmpresaByCNPJ(cnpj);

                if (result != null)
                {
                    var empresaStatusModel = new EmpresaStatusModel();
                    empresaStatusModel.Id = result.EmpresaStatusId;
                    empresaStatusModel.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)result.EmpresaStatusId);
                    result.EmpresaStatus = empresaStatusModel;

                    if (result.EmpresaTipo?.Nome == "Filial")
                    {
                        var resultRepoEmpresaMatriz = _repoCustomEmpresa.GetEmpresabyId(result.EmpresaMatrizId);

                        var empresaMatrizModel = new EmpresaMatrizModel();
                        empresaMatrizModel.Id = resultRepoEmpresaMatriz.Id;
                        empresaMatrizModel.Nome = resultRepoEmpresaMatriz.Nome;
                        result.EmpresaMatriz = empresaMatrizModel;
                    }
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

        public dynamic BuscarEmpresaTipo()
        {
            try
            {
                var result = Cache.Get<List<EmpresaTipoModel>>("EmpresaTipo");
                if (result == null)
                {
                    result = _repoDefaultEmpresaTipo.GetAll();
                    Cache.AddItem("EmpresaTipo", result, 1);
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

        public dynamic BuscarEmpresaFuncionalidade()
        {
            try
            {
                var result = Cache.Get<List<EmpresaFuncionalidadeModel>>("EmpresaFuncionalidade");
                if (result == null)
                {
                    result = _repoDefaultEmpresaFuncionalidade.GetAll();

                    Cache.AddItem("EmpresaFuncionalidade", result, 1);
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

        public dynamic AdicionarEmpresa(EmpresaModel empresa)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(empresa);
                if (validacaoEntrada.Codigo == 0)
                {
                    empresa.DataCadastro = DateTime.Now;
                    _repoDefaultEmpresa.Add(empresa);
                    _unitOfWork.Commit();

                    var result = _repoCustomEmpresa.GetEmpresabyId(empresa.Id);

                    var empresaStatusModel = new EmpresaStatusModel();
                    empresaStatusModel.Id = result.EmpresaStatusId;
                    empresaStatusModel.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)result.EmpresaStatusId);
                    result.EmpresaStatus = empresaStatusModel;

                    AdicionarEmpresaFuncionalidadePadrao(empresa.Id);
                    AdicionarEmpresaDocumentoAdmissionalPadrao(empresa.Id);

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

        public dynamic AdicionarEmpresaDocumentoAdmissional(IEnumerable<EmpresaDocumentoAdmissionalModel> empresaDocumentoAdmissional)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaEmpresaDocumentoAdmissional(empresaDocumentoAdmissional);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<EmpresaDocumentoAdmissionalModel> documentos = _repoCustomEmpresaDocumentoAdmissional.GetEmpresaDocumentoAdmissionalNaoPadraoByEmpresaId(empresaDocumentoAdmissional.FirstOrDefault().EmpresaId);

                    if (documentos.Count > 0)
                    {
                        _repoDefaultEmpresaDocumentoAdmissional.Delete(documentos);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultEmpresaDocumentoAdmissional.Add(empresaDocumentoAdmissional);
                    _unitOfWork.Commit();

                    var result = _repoCustomEmpresaDocumentoAdmissional.GetEmpresaDocumentoAdmissionalByEmpresaId(empresaDocumentoAdmissional.FirstOrDefault().EmpresaId);

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

        public dynamic AdicionarEmpresaFuncionalidade(IEnumerable<EmpresaEmpresaFuncionalidadeModel> empresaEmpresaFuncionalidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaEmpresaEmpresaFuncionalidade(empresaEmpresaFuncionalidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<EmpresaEmpresaFuncionalidadeModel> funcionalidades = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(empresaEmpresaFuncionalidade.FirstOrDefault().EmpresaId);

                    if (funcionalidades.Count > 0)
                    {
                        _repoDefaultEmpresaEmpresaFuncionalidade.Delete(funcionalidades);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultEmpresaEmpresaFuncionalidade.Add(empresaEmpresaFuncionalidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(empresaEmpresaFuncionalidade.FirstOrDefault().EmpresaId);

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

        private void AdicionarEmpresaFuncionalidadePadrao(int empresaId)
        {

            var empresaEmpresaFuncionalidades = new List<EmpresaEmpresaFuncionalidadeModel>();
            var resultEmpresaFuncionalidade = _repoCustomEmpresaFuncionalidade.GetEmpresaFuncionalidadePadrao();

            foreach(var resulfor in resultEmpresaFuncionalidade)
            {
                var empresaFuncionalidade = new EmpresaEmpresaFuncionalidadeModel();
                empresaFuncionalidade.EmpresaId = empresaId;
                empresaFuncionalidade.EmpresaFuncionalidadeId = resulfor.Id;

                empresaEmpresaFuncionalidades.Add(empresaFuncionalidade);
            }

            _repoDefaultEmpresaEmpresaFuncionalidade.Add(empresaEmpresaFuncionalidades);
            _unitOfWork.Commit();

        }

        private void AdicionarEmpresaDocumentoAdmissionalPadrao(int empresaId)
        {

            DocumentoAdmissionalFacade documentoAdmissional = new DocumentoAdmissionalFacade();
            var empresaDocumentoAdmissional = new List<EmpresaDocumentoAdmissionalModel>();
            var resultEmpresaDocumentoAdmissional = documentoAdmissional.BuscarDocumentoAdmissionalPadrao();

            foreach (var resulfor in resultEmpresaDocumentoAdmissional)
            {
                var empresaDocumento = new EmpresaDocumentoAdmissionalModel();
                empresaDocumento.EmpresaId = empresaId;
                empresaDocumento.DocumentoAdmissionalId = resulfor.Id;

                empresaDocumentoAdmissional.Add(empresaDocumento);
            }

            _repoDefaultEmpresaDocumentoAdmissional.Add(empresaDocumentoAdmissional);
            _unitOfWork.Commit();

        }

        public dynamic EditarEmpresa(EmpresaModel empresa)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(empresa);
                if (validacaoEntrada.Codigo == 0)
                {
                    var empresaResult = _repoCustomEmpresa.GetEmpresabyId(empresa.Id);

                    if (empresaResult != null)
                    {
                        empresaResult.Nome = empresa.Nome;
                        empresaResult.CNPJ = empresa.CNPJ;
                        empresaResult.InscricaoEstadual = empresa.InscricaoEstadual;
                        empresaResult.InscricaoMunicipal = empresa.InscricaoMunicipal;
                        empresaResult.Endereco = empresa.Endereco;
                        empresaResult.Numero = empresa.Numero;
                        empresaResult.Bairro = empresa.Bairro;
                        empresaResult.CEP = empresa.CEP;
                        empresaResult.UF = empresa.UF;
                        empresaResult.Cidade = empresa.Cidade;
                        empresaResult.TelefoneContato1 = empresa.TelefoneContato1;
                        empresaResult.EmailContato1 = empresa.EmailContato1;
                        empresaResult.TelefoneContato2 = empresa.TelefoneContato2;
                        empresaResult.EmailContato2 = empresa.EmailContato2;
                        empresaResult.TelefoneContato3 = empresa.TelefoneContato3;
                        empresaResult.EmailContato3 = empresa.EmailContato3;
                        empresaResult.EmpresaTipoId = empresa.EmpresaTipoId;
                        empresaResult.EmpresaStatusId = empresa.EmpresaStatusId;
                        empresaResult.FornecedorHolerite = empresa.FornecedorHolerite;

                        if (empresa.EmpresaTipoId == 2) //FILIAL
                        {
                            if (empresa.EmpresaMatrizId != 0)
                                empresaResult.EmpresaMatrizId = empresa.EmpresaMatrizId;
                            else
                                return "Empresa Matriz não informada";
                        }
                        else if (empresa.EmpresaTipoId == 1) //MATRIZ
                            empresaResult.EmpresaMatrizId = 0;                        

                        _unitOfWork.Commit();

                        result = _repoCustomEmpresa.GetEmpresabyId(empresaResult.Id);

                        //Insere a Descrição do Status
                        var empresaStatusModel = new EmpresaStatusModel();
                        empresaStatusModel.Id = result.EmpresaStatusId;
                        empresaStatusModel.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)result.EmpresaStatusId);
                        result.EmpresaStatus = empresaStatusModel;
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

        public dynamic EditarEmpresaFuncionalidade(IEnumerable<EmpresaEmpresaFuncionalidadeModel> empresaEmpresaFuncionalidade)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntradaEmpresaEmpresaFuncionalidade(empresaEmpresaFuncionalidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<EmpresaEmpresaFuncionalidadeModel> funcionalidades = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(empresaEmpresaFuncionalidade.FirstOrDefault().EmpresaId);

                    if (funcionalidades.Count > 0)
                    {
                        _repoDefaultEmpresaEmpresaFuncionalidade.Delete(funcionalidades);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultEmpresaEmpresaFuncionalidade.Add(empresaEmpresaFuncionalidade);
                    _unitOfWork.Commit();

                    result = _repoCustomEmpresaEmpresaFuncionalidade.GetEmpresaEmpresaFuncionalidadeByEmpresaId(empresaEmpresaFuncionalidade.FirstOrDefault().EmpresaId);

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

        public dynamic BuscarEmpresaPorNome(string empresa)
        {
            try
            {
                var resultRepo = _repoCustomEmpresa.GetEmpresaByNome(empresa);

                var result = new List<EmpresaModel>();
                foreach (var resultFor in resultRepo)
                {
                    var empresaStatus = new EmpresaStatusModel();
                        empresaStatus.Id = resultFor.EmpresaStatusId;
                        empresaStatus.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultFor.EmpresaStatusId);

                    resultFor.EmpresaStatus = empresaStatus;                                     

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

        public dynamic BuscarEmpresaMatrizPorNome(string nomeEmpresa)
        {
            try
            {
                var resultRepo = _repoCustomEmpresa.GetEmpresaMatrizByNome(nomeEmpresa);

                var result = new List<EmpresaModel>();
                foreach (var resultFor in resultRepo)
                {
                    var empresaStatus = new EmpresaStatusModel();
                    empresaStatus.Id = resultFor.EmpresaStatusId;
                    empresaStatus.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultFor.EmpresaStatusId);

                    resultFor.EmpresaStatus = empresaStatus;

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

        public dynamic BuscarEmpresaGrupoPorIdEmpresa(int id)
        {
            try
            {
                int empresaMatrizId = 0;

                EmpresaModel resultEmpresa = _repoCustomEmpresa.GetEmpresabyId(id);

                if (resultEmpresa.EmpresaTipoId == 1) //Matriz
                    empresaMatrizId = resultEmpresa.Id;
                else
                    empresaMatrizId = resultEmpresa.EmpresaMatrizId;

                var resultRepo = _repoCustomEmpresa.GetEmpresaGrupoByEmpresaMatrizId(empresaMatrizId);
                
                var result = new List<EmpresaModel>();
                foreach (var resultFor in resultRepo)
                {
                    var empresaStatus = new EmpresaStatusModel();
                    empresaStatus.Id = resultFor.EmpresaStatusId;
                    empresaStatus.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultFor.EmpresaStatusId);

                    resultFor.EmpresaStatus = empresaStatus;

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

        public dynamic BuscarMatrizFilialPorEmpresaId(int id)
        {
            try
            {
                var result = new List<EmpresaModel>();

                var resultEmpresa = _repoCustomEmpresa.GetEmpresabyId(id);

                if (resultEmpresa != null)
                {
                    var empresaStatus = new EmpresaStatusModel();
                    empresaStatus.Id = resultEmpresa.EmpresaStatusId;
                    empresaStatus.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultEmpresa.EmpresaStatusId);
                    resultEmpresa.EmpresaStatus = empresaStatus;

                    result.Add(resultEmpresa);

                    List<EmpresaModel> resultGrupo = BuscarEmpresaGrupoPorIdEmpresa(id);
                    resultGrupo.Remove(resultEmpresa);

                    foreach (var resultFor in resultGrupo)
                    {
                        var empresaGrupoStatus = new EmpresaStatusModel();
                        empresaGrupoStatus.Id = resultFor.EmpresaStatusId;
                        empresaGrupoStatus.Nome = Utils.GetEnumDescription((EmpresaStatusEnum)resultFor.EmpresaStatusId);
                        resultFor.EmpresaStatus = empresaGrupoStatus;

                        result.Add(resultFor);
                    }
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

        private ErrorModel ValidacaoEntrada(EmpresaModel empresa)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(empresa.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome";
            }
            else if (string.IsNullOrEmpty(empresa.CNPJ))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o CNPJ";
            }
            else
            {
                var result = _repoCustomEmpresa.GetEmpresaValidation(empresa);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
                else if (empresa.EmpresaTipoId == 2) //FILIAL
                {
                    if (empresa.EmpresaMatrizId == 0)
                    {                        
                        erroModel.Codigo = 600;
                        erroModel.Descricao = "Informe a Matriz da Filial";                     
                    }
                }
            }

            return erroModel;
        }
        private ErrorModel ValidacaoEntradaEmpresaDocumentoAdmissional(IEnumerable<EmpresaDocumentoAdmissionalModel> empresaDocumentoAdmissional)
        {
            var erroModel = new ErrorModel();

            foreach(var empresa in empresaDocumentoAdmissional)
            {
                if (empresa.EmpresaId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe a Empresa";
                }
                else if (empresa.DocumentoAdmissionalId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe o Documento Admissional";
                }
            }

            return erroModel;
        }
        private ErrorModel ValidacaoEntradaEmpresaEmpresaFuncionalidade(IEnumerable<EmpresaEmpresaFuncionalidadeModel> empresaEmpresaFuncionalidade)
        {
            var erroModel = new ErrorModel();

            foreach(var empresa in empresaEmpresaFuncionalidade)
            {
                if (empresa.EmpresaId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe a Empresa";
                }
                else if (empresa.EmpresaFuncionalidadeId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe a Funcionalidade";
                }
            }
            
            return erroModel;
        }
    }
}
