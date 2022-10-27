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
    public class AtestadoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultAtestado;
        private static dynamic _repoCustomAtestado;

        public AtestadoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultAtestado = RepositoryFactory.CreateRepository<AtestadoModel, Repository<AtestadoModel>>(_unitOfWork);
            _repoCustomAtestado = RepositoryFactory.CreateRepositoryCustom<AtestadoModel, AtestadoRepository>(_unitOfWork);
        }

        public dynamic BuscarLancamentoAtestado(AtestadoModel atestado)
        {
            try
            {
                var resultRepo = _repoCustomAtestado.GetAtestado(atestado);

                var result = new List<AtestadoModel>();
                foreach (var resultFor in resultRepo)
                {

                    var lancamentoStatusModel = new LancamentoStatusModel();
                    lancamentoStatusModel.Id = resultFor.LancamentoStatusId;
                    lancamentoStatusModel.Nome = Utils.GetEnumDescription((LancamentoStatusEnum)resultFor.LancamentoStatusId);
                    resultFor.LancamentoStatus = lancamentoStatusModel;
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

        public dynamic BuscarLancamentoAtestadoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var resultRepo = _repoCustomAtestado.GetAtestadobyColaboradorId(colaboradorId);

                var result = new List<AtestadoModel>();
                foreach (var resultFor in resultRepo)
                {
                    var lancamentoStatusModel = new LancamentoStatusModel();
                    lancamentoStatusModel.Id = resultFor.LancamentoStatusId;
                    lancamentoStatusModel.Nome = Utils.GetEnumDescription((LancamentoStatusEnum)resultFor.LancamentoStatusId);
                    resultFor.LancamentoStatus = lancamentoStatusModel;
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

        
        public dynamic LancarAtestado(AtestadoModel atestado)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(atestado);
                if (validacaoEntrada.Codigo == 0)
                {
                    var fotoNome = SalvarImagemAtestado(atestado);
                    atestado.AtestadoNome = fotoNome;

                    atestado.DataLancamento = DateTime.Now;
                    atestado.LancamentoStatusId = (int)LancamentoStatusEnum.EM_ANALISE;

                    _repoDefaultAtestado.Add(atestado);
                    _unitOfWork.Commit();

                    AdicionarLancamentoAtestadoNotificacao(atestado.ColaboradorId);

                    var result = _repoCustomAtestado.GetAtestadobyId(atestado.Id);

                    var lancamentoStatusModel = new LancamentoStatusModel();
                    lancamentoStatusModel.Id = result.LancamentoStatusId;
                    lancamentoStatusModel.Nome = Utils.GetEnumDescription((LancamentoStatusEnum)result.LancamentoStatusId);
                    result.LancamentoStatus = lancamentoStatusModel;

                    result.AtestadoBase64 = string.Empty;

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

        public dynamic AprovarLancamentoAtestado(int atestadoId)
        {
            dynamic result;

            try
            {
                var AtestadoResult = _repoCustomAtestado.GetAtestadobyId(atestadoId);

                if (AtestadoResult != null)
                {
                    if (AtestadoResult.LancamentoStatusId == (int)LancamentoStatusEnum.EM_ANALISE)
                    {

                        AtestadoResult.LancamentoStatusId = (int)LancamentoStatusEnum.APROVADO;
                        AtestadoResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomAtestado.GetAtestadobyId(AtestadoResult.Id);

                        var lancamentoStatusModel = new LancamentoStatusModel();
                        lancamentoStatusModel.Id = result.LancamentoStatusId;
                        lancamentoStatusModel.Nome = Utils.GetEnumDescription((LancamentoStatusEnum)result.LancamentoStatusId);
                        result.LancamentoStatus = lancamentoStatusModel;

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

        public dynamic ReprovarLancamentoAtestado(int atestadoId)
        {
            dynamic result;

            try
            {
                var AtestadoResult = _repoCustomAtestado.GetAtestadobyId(atestadoId);

                if (AtestadoResult != null)
                {
                    if (AtestadoResult.LancamentoStatusId == (int)LancamentoStatusEnum.EM_ANALISE)
                    {
                        AtestadoResult.LancamentoStatusId = (int)LancamentoStatusEnum.REPROVADO;
                        AtestadoResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomAtestado.GetAtestadobyId(AtestadoResult.Id);

                        var lancamentoStatusModel = new LancamentoStatusModel();
                        lancamentoStatusModel.Id = result.LancamentoStatusId;
                        lancamentoStatusModel.Nome = Utils.GetEnumDescription((LancamentoStatusEnum)result.LancamentoStatusId);
                        result.LancamentoStatus = lancamentoStatusModel;

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

        private static void AdicionarLancamentoAtestadoNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 7; //Lançamento de Atestado
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private string SalvarImagemAtestado(AtestadoModel atestado)
        {
            string fotoNome = string.Empty;
            if (!string.IsNullOrEmpty(atestado.AtestadoBase64))
            {
                var fileName = Guid.NewGuid().ToString();
                fotoNome = FileOperation.SalvarDocumentoImagem(FileType.PathColaboradorAtestado.Value, atestado.AtestadoBase64, fileName);
            }

            return fotoNome;
        }

        public dynamic BuscarImagemAtestado(int id)
        {
            dynamic result;

            var resultAtestado = _repoCustomAtestado.GetAtestadobyId(id);

            if (resultAtestado != null)
            {
                var imageBase64 = FileOperation.CarregarDocumentoBase64(FileType.PathColaboradorAtestado.Value, resultAtestado.AtestadoNome);
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


        private ErrorModel ValidacaoEntrada(AtestadoModel Atestado)
        {
            var erroModel = new ErrorModel();

            if (Atestado.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else if (Atestado.DataAtestado == DateTime.MinValue)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Data";
            }
            else if (string.IsNullOrEmpty(Atestado.HorarioChegada))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Horário de Chegada";
            }
            else if (string.IsNullOrEmpty(Atestado.HorarioSaida))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Horário de Saída";
            }
            else if (string.IsNullOrEmpty(Atestado.AtestadoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Atestado";
            }
            else
            {
                var result = _repoCustomAtestado.GetAtestadoValidation(Atestado);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Já existe um lançamento Em Análise";
                }
            }

            return erroModel;
        }
    }
}