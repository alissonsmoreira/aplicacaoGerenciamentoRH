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
    public class AlteracaoCadastralFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultAlteracaoCadastral;
        private static dynamic _repoCustomAlteracaoCadastral;

        public AlteracaoCadastralFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultAlteracaoCadastral = RepositoryFactory.CreateRepository<AlteracaoCadastralModel, Repository<AlteracaoCadastralModel>>(_unitOfWork);
            _repoCustomAlteracaoCadastral = RepositoryFactory.CreateRepositoryCustom<AlteracaoCadastralModel, AlteracaoCadastralRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoAlteracao(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                var resultRepo = _repoCustomAlteracaoCadastral.GetAlteracaoCadastral(alteracaoCadastral);

                var result = new List<AlteracaoCadastralModel>();
                foreach (var resultFor in resultRepo)
                {
                    var solicitacaoStatusModel = new SolicitacaoStatusModel();
                    solicitacaoStatusModel.Id = resultFor.SolicitacaoStatusId;
                    solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = solicitacaoStatusModel;
                    result.Add(resultFor);
                }
                //Todo: colocar status

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

        public dynamic BuscarDadosPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = new AlteracaoCadastralModel();
                var resultColaborador = BuscarColaboradorDadoPrincipalPorColaboradorId(colaboradorId);
                var resultColaboradorDocumentacao = BuscarColaboradorDocumentacaoPorColaboradorId(colaboradorId);
                var resultColaboradorPagamento = BuscarColaboradorPagamentoPorColaboradorId(colaboradorId);

                if (resultColaborador != null)
                {
                    result.ColaboradorId = resultColaborador.Id;
                    result.Nome = resultColaborador.Nome;
                    result.Endereco = resultColaborador.Endereco;
                    result.Numero = resultColaborador.Numero;
                    result.Complemento = resultColaborador.Complemento;
                    result.Bairro = resultColaborador.Bairro;
                    result.CEP = resultColaborador.CEP;
                    result.UF = resultColaborador.UF;
                    result.Cidade = resultColaborador.Cidade;
                    //result.Pais = resultColaborador.Pais; // Campo não existe no cadastro de Colaborador
                    result.Telefone1 = resultColaborador.Telefone1;
                    result.Telefone2 = resultColaborador.Telefone2;
                    result.Telefone3 = resultColaborador.Telefone3;
                    result.Email = resultColaborador.Email;
                }

                if (resultColaboradorDocumentacao != null)
                {
                    result.CategoriaHabilitacao = resultColaboradorDocumentacao.CategoriaHabilitacao;
                    result.DataVencimentoHabilitacao = resultColaboradorDocumentacao.DataVencimentoHabilitacao;
                }

                if (resultColaboradorPagamento != null)
                {
                    result.BancoId = resultColaboradorPagamento.BancoId;
                    result.Banco = resultColaboradorPagamento.Banco;
                    result.Agencia = resultColaboradorPagamento.Agencia;
                    result.Conta = resultColaboradorPagamento.Conta;
                    result.ContaBancariaTipoId = resultColaboradorPagamento.ContaBancariaTipoId;
                    result.ContaBancariaTipo = resultColaboradorPagamento.ContaBancariaTipo;
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

        public dynamic BuscarSolicitacaoAlteracaoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var resultRepo = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyColaboradorId(colaboradorId);

                var result = new List<AlteracaoCadastralModel>();
                foreach (var resultFor in resultRepo)
                {
                    var alteracaoCadastralStatusModel = new SolicitacaoStatusModel();
                    alteracaoCadastralStatusModel.Id = resultFor.SolicitacaoStatusId;
                    alteracaoCadastralStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = alteracaoCadastralStatusModel;
                    result.Add(resultFor);
                }
                //Todo: colocar status

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

        public dynamic SolicitarAlteracao(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(alteracaoCadastral);
                if (validacaoEntrada.Codigo == 0)
                {

                    var fotoNome = SalvarFoto(alteracaoCadastral);
                    alteracaoCadastral.FotoNome = fotoNome;

                    var carteiraHabilitacaoNome = SalvarCarteiraHabilitacao(alteracaoCadastral);
                    alteracaoCadastral.CarteiraHabilitacaoNome = carteiraHabilitacaoNome;

                    var comprovanteResidenciaNome = SalvarComprovanteResidencia(alteracaoCadastral);
                    alteracaoCadastral.ComprovanteResidenciaNome = comprovanteResidenciaNome;

                    alteracaoCadastral.DataSolicitacao = DateTime.Now;
                    alteracaoCadastral.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultAlteracaoCadastral.Add(alteracaoCadastral);
                    _unitOfWork.Commit();

                    AdicionarAlteracaoCadastralNotificacao(alteracaoCadastral.ColaboradorId);

                    var result = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(alteracaoCadastral.Id);

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

        public dynamic AprovarSolicitacaoAlteracao(int alteracaoCadastralId)
        {
            dynamic result;

            try
            {
                var alteracaoCadastralResult = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(alteracaoCadastralId);
                
                if (alteracaoCadastralResult != null)
                {
                    if (alteracaoCadastralResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        
                        alteracaoCadastralResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        alteracaoCadastralResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(alteracaoCadastralResult.Id);

                        var alteracaoCadastralStatusModel = new SolicitacaoStatusModel();
                        alteracaoCadastralStatusModel.Id = result.SolicitacaoStatusId;
                        alteracaoCadastralStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = alteracaoCadastralStatusModel;

                        AtualizarColaborador(result);

                    }
                    else
                        result = "Registro não pode ser alterado";
                }
                else
                    result = "Registro não encontrado";

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

        public dynamic ReprovarSolicitacaoAlteracao(int alteracaoCadastralId)
        {
            dynamic result;

            try
            {
                var alteracaoCadastralResult = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(alteracaoCadastralId);

                if (alteracaoCadastralResult != null)
                {
                    if (alteracaoCadastralResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        alteracaoCadastralResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        alteracaoCadastralResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(alteracaoCadastralResult.Id);

                        var alteracaoCadastralStatusModel = new SolicitacaoStatusModel();
                        alteracaoCadastralStatusModel.Id = result.SolicitacaoStatusId;
                        alteracaoCadastralStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = alteracaoCadastralStatusModel;

                    }
                    else
                        result = "Registro não pode ser alterado";
                    
                }
                else
                    result = "Registro não encontrado";

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

        private dynamic BuscarColaboradorDadoPrincipalPorColaboradorId(int colaboradorId)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            return colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId);
        }

        private dynamic BuscarColaboradorDocumentacaoPorColaboradorId(int colaboradorId)
        {
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();
            return colaboradorDocumentacaoFacade.BuscarDocumentacaoColaboradorPorColaboradorId(colaboradorId);
        }

        private dynamic BuscarColaboradorPagamentoPorColaboradorId(int colaboradorId)
        {
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();
            return colaboradorPagamentoFacade.BuscarPagamentoColaboradorPorColaboradorId(colaboradorId);
        }

        private static void AdicionarAlteracaoCadastralNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 4; //Solicitação de Alteração Cadastral
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private void AtualizarColaborador(AlteracaoCadastralModel alteracaoCadastral)
        {
            ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
            ColaboradorDocumentacaoFacade colaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();
            ColaboradorPagamentoFacade colaboradorPagamentoFacade = new ColaboradorPagamentoFacade();

            colaboradorFacade.AlteracaoCadastralColaboradorDadoPrincipal(alteracaoCadastral);
            colaboradorDocumentacaoFacade.AlteracaoCadastralColaboradorDocumentacao(alteracaoCadastral);
            colaboradorPagamentoFacade.AlteracaoCadastralColaboradorPagamento(alteracaoCadastral);

            ColaboradorDocumentoAdmissionalFacade colaboradorCarteiraHabilitacao = new ColaboradorDocumentoAdmissionalFacade();
            colaboradorCarteiraHabilitacao.AlteracaoCadastralCarteiraHabilitacao(alteracaoCadastral);

            ColaboradorDocumentoAdmissionalFacade colaboradorComprovanteResidencia = new ColaboradorDocumentoAdmissionalFacade();
            colaboradorComprovanteResidencia.AlteracaoCadastralComprovanteResidencia(alteracaoCadastral);
        }

        private string SalvarFoto(AlteracaoCadastralModel alteracaoCadastral)
        {
            string fotoNome = string.Empty;
            if (!string.IsNullOrEmpty(alteracaoCadastral.FotoBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                fotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorFoto.Value, alteracaoCadastral.FotoBase64, fileName);
            }

            return fotoNome;
        }
        private string SalvarCarteiraHabilitacao(AlteracaoCadastralModel alteracaoCadastral)
        {
            string fotoNome = string.Empty;
            if (!string.IsNullOrEmpty(alteracaoCadastral.CarteiraHabilitacaoBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                fotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorDocumento.Value, alteracaoCadastral.CarteiraHabilitacaoBase64, fileName);
            }

            return fotoNome;
        }

        private string SalvarComprovanteResidencia(AlteracaoCadastralModel alteracaoCadastral)
        {
            string fotoNome = string.Empty;
            if (!string.IsNullOrEmpty(alteracaoCadastral.ComprovanteResidenciaBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                fotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorDocumento.Value, alteracaoCadastral.ComprovanteResidenciaBase64, fileName);
            }

            return fotoNome;
        }
        public dynamic BuscarFoto(int id)
        {
            dynamic result;

            var resultAlteracaoCadastral = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(id);

            if (resultAlteracaoCadastral != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorFoto.Value, resultAlteracaoCadastral.FotoNome);
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
        public dynamic BuscarCarteiraHabilitacao(int id)
        {
            dynamic result;

            var resultAlteracaoCadastral = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(id);

            if (resultAlteracaoCadastral != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorDocumento.Value, resultAlteracaoCadastral.CarteiraHabilitacaoNome);
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
        public dynamic BuscarComprovanteResidencia(int id)
        {
            dynamic result;

            var resultAlteracaoCadastral = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralbyId(id);

            if (resultAlteracaoCadastral != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorDocumento.Value, resultAlteracaoCadastral.ComprovanteResidenciaNome);
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
        private ErrorModel ValidacaoEntrada(AlteracaoCadastralModel alteracaoCadastral)
        {
            var erroModel = new ErrorModel();

            if (alteracaoCadastral.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else
            {
                var result = _repoCustomAlteracaoCadastral.GetAlteracaoCadastralValidation(alteracaoCadastral);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Já existe uma solicitação Em Análise";
                }
            }

            return erroModel;
        }
    }
}
