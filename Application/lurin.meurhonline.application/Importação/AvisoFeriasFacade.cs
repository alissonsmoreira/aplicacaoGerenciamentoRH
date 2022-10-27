using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.domain.interfaces;

namespace lurin.meurhonline.application
{
    public class AvisoFeriasFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultAvisoFerias;
        private static dynamic _repoDefaultAvisoFeriasLog;

        private static dynamic _repoCustomColaboradorDadoPrincipal;
        private static dynamic _repoCustomAvisoFerias;
        private static dynamic _repoCustomEmpresa;

        private static dynamic _domainAvisoFerias;

        public AvisoFeriasFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultAvisoFerias = RepositoryFactory.CreateRepository<AvisoFeriasModel, Repository<AvisoFeriasModel>>(_unitOfWork);
            _repoDefaultAvisoFeriasLog = RepositoryFactory.CreateRepository<AvisoFeriasLogModel, Repository<AvisoFeriasLogModel>>(_unitOfWork);
            
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
            _repoCustomAvisoFerias = RepositoryFactory.CreateRepositoryCustom<AvisoFeriasModel, AvisoFeriasRepository>(_unitOfWork);
            _repoCustomEmpresa = RepositoryFactory.CreateRepositoryCustom<EmpresaModel, EmpresaRepository>(_unitOfWork);

            _domainAvisoFerias = DomainFactory.CreateDomain<AvisoFeriasModel, AvisoFeriasDomain>(_unitOfWork);
        }

        public dynamic BuscarAvisoFeriasPorId(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomAvisoFerias.GetAvisoFeriasById(id);

                if (result == null)
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
        public dynamic BuscarAvisoFeriasPorColaboradorIdAno(int colaboradorId, string ano)
        {
            List<AvisoFeriasModel> avisoFeriasResult = new List<AvisoFeriasModel>();

            try
            {
                var colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorId);

                if (colaborador == null)
                {
                    AvisoFeriasModel result = new AvisoFeriasModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Colaborador não existe"
                        }
                    };

                    avisoFeriasResult.Add(result);
                }
                else
                {
                    avisoFeriasResult = _repoCustomAvisoFerias.GetAvisoFeriasByColaboradorIdAno(colaborador.Id, ano);

                }

                return avisoFeriasResult;
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

        public dynamic AdicionarAvisoFerias(AvisoFeriasModel avisoFerias)
        {
            var validaAvisoFerias = new AvisoFeriasModel();
            IList<AvisoFeriasLogModel> resultList = new List<AvisoFeriasLogModel>();
            AvisoFeriasLogModel resultItem = new AvisoFeriasLogModel();
            IList<AvisoFeriasModel> avisoFeriasDetalhe = new List<AvisoFeriasModel>();

            try
            {
                validaAvisoFerias = ValidacaoEntrada(avisoFerias);
                if (validaAvisoFerias.Erro.Codigo == 0)
                {
                    if (_domainAvisoFerias.DecodeArquivoTxtAvisoFerias(avisoFerias))
                    {
                        ApagarAvisoFeriasLog();
                        avisoFeriasDetalhe = _domainAvisoFerias.AdicionarAvisoFerias(avisoFerias);

                        foreach (var item in avisoFeriasDetalhe)
                        {
                            var resultProcessamento = ValidacaoProcessamento(item);
                            if (resultProcessamento == null)
                            {
                                GravaAvisoFerias(item);
                            }
                            else
                            {
                                GravaAvisoFeriasLog(resultProcessamento);
                                resultList.Add(resultProcessamento);
                            }
                        }
                    }
                    else
                    {
                        resultItem.DataCadastro = DateTime.Now;
                        resultItem.LogErro = "Erro na conversão do arquivo TXT.";
                        resultList.Add(resultItem);
                    }
                }
                else
                {
                    resultItem.DataCadastro = DateTime.Now;
                    resultItem.LogErro = validaAvisoFerias.Erro.Descricao;
                    resultList.Add(resultItem);
                }

                return resultList;
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

        private void GravaAvisoFerias(AvisoFeriasModel avisoFerias)
        {
            _repoDefaultAvisoFerias.Add(avisoFerias);
            _unitOfWork.Commit();
        }

        private void ApagarAvisoFeriasLog()
        {
            var logs = _repoDefaultAvisoFeriasLog.GetAll();
            _repoDefaultAvisoFeriasLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private void GravaAvisoFeriasLog(AvisoFeriasLogModel avisoFeriasLog)
        {
                _repoDefaultAvisoFeriasLog.Add(avisoFeriasLog);
                _unitOfWork.Commit();
        }

        private AvisoFeriasModel ValidacaoEntrada(AvisoFeriasModel avisoFerias)
        {
            avisoFerias.Erro = new ErrorModel();

            if (string.IsNullOrEmpty(avisoFerias.DocumentoBase64))
            {
                avisoFerias.Erro.Codigo = 600;
                avisoFerias.Erro.Descricao = "Arquivo Invalido";
            }

            if (string.IsNullOrEmpty(avisoFerias.Ano))
            {
                avisoFerias.Erro.Codigo = 600;
                avisoFerias.Erro.Descricao = "Ano não informado";
            }

            return avisoFerias;
        }

        private AvisoFeriasLogModel ValidacaoProcessamento(AvisoFeriasModel avisoFerias)
        {
            AvisoFeriasLogModel result = null;

            if (string.IsNullOrEmpty(avisoFerias.CPF))
            {
                result = new AvisoFeriasLogModel();
                result.DataCadastro = DateTime.Now;
                result.CPF = avisoFerias.CPF;
                result.LogErro = "CPF não invalido";
                return result;
            }

            if (string.IsNullOrEmpty(avisoFerias.CPNJ))
            {
                result = new AvisoFeriasLogModel();
                result.DataCadastro = DateTime.Now;
                result.CPF = avisoFerias.CPF;
                result.LogErro = "CNPJ não invalido";
                return result;
            }

            avisoFerias.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyCPF(avisoFerias.CPF);

            if (avisoFerias.Colaborador == null)
            {
                result = new AvisoFeriasLogModel();
                result.DataCadastro = DateTime.Now;
                result.CPF = avisoFerias.CPF;
                result.LogErro = "CPF não encontrado";
                return result;
            }
            else 
            {
                avisoFerias.Empresa = _repoCustomEmpresa.GetEmpresaByCNPJ(avisoFerias.CPNJ);

                if (avisoFerias.Empresa == null)
                {
                    result = new AvisoFeriasLogModel();
                    result.DataCadastro = DateTime.Now;
                    result.CPF = avisoFerias.CPF;
                    result.LogErro = "CPNJ não encontrado";
                    return result;
                }
                else
                {
                    if (avisoFerias.Colaborador.EmpresaId != avisoFerias.Empresa.Id)
                    {
                        result = new AvisoFeriasLogModel();
                        result.DataCadastro = DateTime.Now;
                        result.CPF = avisoFerias.CPF;
                        result.LogErro = "Matríula não associada ao CPNJ";
                        return result;
                    }
                }
            }

            return result;
        }
    }
}