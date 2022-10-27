using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class InformeRendimentoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _domainInformeRendimento;
        private static dynamic _repoInformeRendimento;
        private static dynamic _repoInformeRendimentoLog;
        private static dynamic _repoInformeRendimentoCustom;
        private static dynamic _repoTipoRendimentoTributaveis;
        private static dynamic _repoTipoRendimentoIsentos;
        private static dynamic _repoTipoRendimentoSujeitosTrib;
        private static dynamic _repoTipoRendimentoReceb;
        private string _ano;

        public InformeRendimentoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainInformeRendimento = DomainFactory.CreateDomain<InformeRendimentoModel, InformeRendimentoDomain>(_unitOfWork);

            _repoInformeRendimento = RepositoryFactory.CreateRepository<InformeRendimentoModel, Repository<InformeRendimentoModel>>(_unitOfWork);
            _repoInformeRendimentoLog = RepositoryFactory.CreateRepository<InformeRendimentoLogModel, Repository<InformeRendimentoLogModel>>(_unitOfWork);
            _repoInformeRendimentoCustom = RepositoryFactory.CreateRepositoryCustom<InformeRendimentoModel, InformeRendimentoRepository>(_unitOfWork);
            _repoTipoRendimentoTributaveis = RepositoryFactory.CreateRepository<TipoRendimentoTributaveisModel, Repository<TipoRendimentoTributaveisModel>>(_unitOfWork);
            _repoTipoRendimentoIsentos = RepositoryFactory.CreateRepository<TipoRendimentoIsentosModel, Repository<TipoRendimentoIsentosModel>>(_unitOfWork);
            _repoTipoRendimentoSujeitosTrib = RepositoryFactory.CreateRepository<TipoRendimentoSujeitosTribModel, Repository<TipoRendimentoSujeitosTribModel>>(_unitOfWork);
            _repoTipoRendimentoReceb = RepositoryFactory.CreateRepository<TipoRendimentoRecebModel, Repository<TipoRendimentoRecebModel>>(_unitOfWork);
        }

        public dynamic ImportarInformeRendimento(InformeRendimentoModel informeRendimento)
        {
            IList<InformeRendimentoModel> informesRendimentos = _domainInformeRendimento.ImportarInformeRendimento(informeRendimento);
            List<InformeRendimentoLogModel> informesRendimentosLogs = new List<InformeRendimentoLogModel>();
            try
            {
                var validacaodocumento = ValidacaoDocumento(informeRendimento);
                if (validacaodocumento.Codigo == 0)
                {
                    ApagarInformeRendimentoLog();

                    _ano = informeRendimento.Ano;

                    foreach (InformeRendimentoModel ir in informesRendimentos)
                    {
                        var ret = AdicionarInformeRendimento(ir);

                        if ((ret as InformeRendimentoLogModel != null))
                        {
                            InformeRendimentoLogModel log = ret;
                            if (!String.IsNullOrEmpty(log.LogErro))
                            {
                                informesRendimentosLogs.Add(log);
                            }
                        }
                    }

                    return informesRendimentosLogs;
                }
                else
                {
                    return validacaodocumento;
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

        public dynamic BuscarInformeRendimentoPorColaboradorIdAno(int colaboradorId, string ano)
        {
            InformeRendimentoModel result = new InformeRendimentoModel();

            if (colaboradorId == 0)
            {
                result.Erro.Codigo = 600;
                result.Erro.Descricao = "Colaborador inválido";
            }
            else if (ano == null)
            {
                result.Erro.Codigo = 600;
                result.Erro.Descricao = "Ano não informado";
            }
            else
            {
                result = _repoInformeRendimentoCustom.GetInformeRendimentoByColaboradorIdAno(colaboradorId, ano);
            }

            return result;
        }

        public dynamic BuscarInformeRendimentoPorId(int id)
        {
            var result = _repoInformeRendimentoCustom.GetInformeRendimentoById(id);
            
            return result;
        }

        public dynamic AdicionarInformeRendimento(InformeRendimentoModel informeRendimento)
        {
            var result = new InformeRendimentoLogModel();
            try
            {
                informeRendimento.Ano = _ano;

                var validacaoEntrada = ValidacaoEntrada(informeRendimento);
                
                if (validacaoEntrada.Codigo == 0)
                {
                    informeRendimento.DataCadastro = DateTime.Now;
                    _repoInformeRendimento.Add(informeRendimento);
                    _unitOfWork.Commit();
                }
                else
                {
                    result.CPF = informeRendimento.CPF;
                    result.LogErro = validacaoEntrada.Descricao;
                    result.DataCadastro = DateTime.Now;

                    _repoInformeRendimentoLog.Add(result);
                    _unitOfWork.Commit();
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
        }

        private void ApagarInformeRendimentoLog()
        {
            var logs = _repoInformeRendimentoLog.GetAll();
            _repoInformeRendimentoLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private ErrorModel ValidacaoDocumento(InformeRendimentoModel informeRendimento)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(informeRendimento.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Invalido";
            }
            else if (string.IsNullOrEmpty(informeRendimento.Ano))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Ano não informado";
            }
            return erroModel;
        }

        private ErrorModel ValidacaoEntrada(InformeRendimentoModel informeRendimento)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(informeRendimento.CPF))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "CPF não informado";
            }
            else if (string.IsNullOrEmpty(informeRendimento.CNPJ))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "CPF não informado";
            }
            else 
            {
                EmpresaFacade empresaFacade = new EmpresaFacade();
                EmpresaModel empresa = empresaFacade.BuscarEmpresaPorCnpj(informeRendimento.CNPJ);

                if (empresa == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "CNPJ não cadastrado";
                }
                else
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    ColaboradorModel colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorCpf(informeRendimento.CPF);
                    if (colaborador == null)
                    {
                        erroModel.Codigo = 600;
                        erroModel.Descricao = "CPF não encontrado";
                    }
                    else if (empresa.Id != colaborador.EmpresaId)
                    {
                        erroModel.Codigo = 600;
                        erroModel.Descricao = "Colaborador não cadastrado nesta Empresa";
                    }
                    else
                    {
                        informeRendimento.EmpresaId = empresa.Id;
                        informeRendimento.ColaboradorId = colaborador.Id;
                        VerificaDuplicidade(informeRendimento);
                    }
                }
            }

            return erroModel;
        }

        private void VerificaDuplicidade(InformeRendimentoModel informeRendimento)
        {
            InformeRendimentoModel irExistente = _repoInformeRendimentoCustom.GetInformeRendimentoByColaboradorIdAno(informeRendimento.ColaboradorId, informeRendimento.Ano);
            if (irExistente != null)
            {
                _repoInformeRendimento.Delete(irExistente);
            }
        }
    }
}
