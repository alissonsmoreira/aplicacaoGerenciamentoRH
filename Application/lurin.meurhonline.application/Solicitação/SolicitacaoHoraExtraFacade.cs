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
using lurin.meurhonline.infrastructure.cache;

namespace lurin.meurhonline.application
{
    public class SolicitacaoHoraExtraFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultSolicitacaoHoraExtra;
        private static dynamic _repoDefaultSolicitacaoHoraExtraColaborador;

        private static dynamic _repoCustomSolicitacaoHoraExtra;
        private static dynamic _repoCustomColaboradorDadoPrincipal;
        private static dynamic _repoCustomMarmitex;

        public SolicitacaoHoraExtraFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultSolicitacaoHoraExtra = RepositoryFactory.CreateRepository<SolicitacaoHoraExtraModel, Repository<SolicitacaoHoraExtraModel>>(_unitOfWork);
            _repoDefaultSolicitacaoHoraExtraColaborador = RepositoryFactory.CreateRepository<SolicitacaoHoraExtraColaboradorModel, Repository<SolicitacaoHoraExtraColaboradorModel>>(_unitOfWork);

            _repoCustomSolicitacaoHoraExtra = RepositoryFactory.CreateRepositoryCustom<SolicitacaoHoraExtraModel, SolicitacaoHoraExtraRepository>(_unitOfWork);
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
            _repoCustomMarmitex = RepositoryFactory.CreateRepositoryCustom<MarmitexModel, MarmitexRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoHoraExtraPorGestorId(int gestorId, DateTime? data)
        {
            dynamic result;
            dynamic resultColaborador;

            try
            {
                result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtrabyGestorId(gestorId, data);

                if (result == null)
                {
                    result = "Registro não encontrado";
                }
                else
                {
                    foreach (var item in result)
                    {
                        resultColaborador = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(item.Id);

                        foreach (var itemColaborador in resultColaborador)
                        {
                            var HoraExtraStatusModel = new SolicitacaoStatusModel();
                            HoraExtraStatusModel.Id = itemColaborador.SolicitacaoStatusId;
                            HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)itemColaborador.SolicitacaoStatusId);
                            itemColaborador.SolicitacaoStatus = HoraExtraStatusModel;
                        }
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

        public dynamic BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao(int empresaId, DateTime? dataSolicitacao)
        {
            dynamic result;
            dynamic resultColaborador;

            try
            {
                result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtrabyEmpresaIdDataSolicitacao(empresaId, dataSolicitacao);

                if (result == null)
                {
                    result = "Registro não encontrado";
                }
                else
                {
                    foreach (var item in result)
                    {
                        resultColaborador = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(item.Id);

                                                foreach (var itemColaborador in resultColaborador)
                        {
                            var HoraExtraStatusModel = new SolicitacaoStatusModel();
                            HoraExtraStatusModel.Id = itemColaborador.SolicitacaoStatusId;
                            HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)itemColaborador.SolicitacaoStatusId);
                            itemColaborador.SolicitacaoStatus = HoraExtraStatusModel;
                        }
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

        public dynamic BuscarSolicitacaoHoraExtraPorColaboradorId(int colaboradorId)
        {
            dynamic resultColaborador;
            List<SolicitacaoHoraExtraModel> solicitacaoHoraExtra = new List<SolicitacaoHoraExtraModel>();

            try
            {
                resultColaborador = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaboradorbyColaboradorId(colaboradorId);

                if (resultColaborador == null)                
                    resultColaborador = "Registro não encontrado";                
                else
                {
                    foreach (var itemColaborador in resultColaborador)
                    {
                        var HoraExtraStatusModel = new SolicitacaoStatusModel();
                        HoraExtraStatusModel.Id = itemColaborador.SolicitacaoStatusId;
                        HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)itemColaborador.SolicitacaoStatusId);
                        itemColaborador.SolicitacaoStatus = HoraExtraStatusModel;

                        SolicitacaoHoraExtraModel result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraId(itemColaborador.SolicitacaoHoraExtraId);
                        if (result != null)
                        {
                            result.SolicitacaoHoraExtraColaborador.Clear();
                            result.SolicitacaoHoraExtraColaborador.Add(itemColaborador);
                            solicitacaoHoraExtra.Add(result);
                        }
                    }
                }

                return solicitacaoHoraExtra;
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

        public dynamic BuscarConvocadosPorSolicitacaoHoraExtraID(int solicitacaoHoraExtraID)
        {
            dynamic resultColaborador;

            try
            {
                resultColaborador = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(solicitacaoHoraExtraID);

                if (resultColaborador == null)
                {
                    resultColaborador = "Registro não encontrado";
                }
                else
                {
                    foreach (var itemColaborador in resultColaborador)
                    {
                        var HoraExtraStatusModel = new SolicitacaoStatusModel();
                        HoraExtraStatusModel.Id = itemColaborador.SolicitacaoStatusId;
                        HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)itemColaborador.SolicitacaoStatusId);
                        itemColaborador.SolicitacaoStatus = HoraExtraStatusModel;
                    }
                }

                return resultColaborador;
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

        public dynamic ConvocarFuncionarios(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            dynamic result = null;

            try
            {
                var validacaoEntrada = ValidacaoConvocarFuncionarios(solicitacaoHoraExtra);
                if (validacaoEntrada.Codigo == 0)
                {
                    result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraId(solicitacaoHoraExtra.Id);

                    if (result != null)
                    {
                        foreach (var colaboradorItem in solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador)
                        {
                            colaboradorItem.SolicitacaoHoraExtraId = solicitacaoHoraExtra.Id;
                            var validaColaboradorExiste = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaborador(colaboradorItem);

                            if (validaColaboradorExiste == null)
                            {
                                SolicitacaoHoraExtraColaboradorModel horaExtraColaborador = new SolicitacaoHoraExtraColaboradorModel();
                                horaExtraColaborador.ColaboradorId = colaboradorItem.ColaboradorId;
                                horaExtraColaborador.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorItem.ColaboradorId.Value);

                                horaExtraColaborador.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                                var HoraExtraStatusModel = new SolicitacaoStatusModel();
                                HoraExtraStatusModel.Id = horaExtraColaborador.SolicitacaoStatusId.Value;
                                HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)horaExtraColaborador.SolicitacaoStatusId);
                                horaExtraColaborador.SolicitacaoStatus = HoraExtraStatusModel;

                                result.SolicitacaoHoraExtraColaborador.Add(horaExtraColaborador);

                                _repoDefaultSolicitacaoHoraExtraColaborador.Add(horaExtraColaborador);
                                _unitOfWork.Commit();

                                AdicionarSolicitacaoHoraExtraNotificacao(horaExtraColaborador.ColaboradorId.Value);
                            }
                        }
                    }
                    else
                    {
                        result = "Solicitação de Hora Extra não encontrada";
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

        public dynamic SolicitarHorExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            dynamic result = null;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(solicitacaoHoraExtra);
                if (validacaoEntrada.Codigo == 0)
                {
                    solicitacaoHoraExtra.DataSolicitacao = DateTime.Now;

                    var colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(solicitacaoHoraExtra.GestorId);
                    if (colaborador != null)
                    {
                        solicitacaoHoraExtra.EmpresaId = colaborador.EmpresaId;

                        _repoDefaultSolicitacaoHoraExtra.Add(solicitacaoHoraExtra);
                        _unitOfWork.Commit();

                        result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraId(solicitacaoHoraExtra.Id);
                    }
                    else 
                    {
                        result = "Gestor não encontrado";
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

        public dynamic AprovarSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            try
            {
                return AlteraStatusSolicitacaoHoraExtra(solicitacaoHoraExtra, SolicitacaoStatusEnum.APROVADO);

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

        public dynamic ReprovarSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            try
            {
                return AlteraStatusSolicitacaoHoraExtra(solicitacaoHoraExtra, SolicitacaoStatusEnum.REPROVADO);

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

        private dynamic AlteraStatusSolicitacaoHoraExtra(SolicitacaoHoraExtraModel solicitacaoHoraExtra, SolicitacaoStatusEnum status)
        {
            dynamic result = null;

            try
            {
                var validacaoEntrada = ValidacaoConvocarFuncionarios(solicitacaoHoraExtra);
                if (validacaoEntrada.Codigo == 0)
                {
                    result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraId(solicitacaoHoraExtra.Id);
                    var resultColaborador = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaboradorbySolicitacaoHoraExtraId(solicitacaoHoraExtra.Id);

                    if (result != null)
                    {
                        result.TemMarmitex = solicitacaoHoraExtra.TemMarmitex;
                        result.TemRefeicao = solicitacaoHoraExtra.TemRefeicao;
                        result.MarmitexId = solicitacaoHoraExtra.MarmitexId;
                        _unitOfWork.Commit();

                        foreach (var colaboradorItem in solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador)
                        {
                            colaboradorItem.SolicitacaoHoraExtraId = solicitacaoHoraExtra.Id;
                            var horaExtraColabResult = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraColaborador(colaboradorItem);

                            if (horaExtraColabResult != null)
                            {
                                if (horaExtraColabResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                                {
                                    horaExtraColabResult.SolicitacaoStatusId = (int)status;
                                    horaExtraColabResult.DataConclusao = DateTime.Now;
                                    _unitOfWork.Commit();
                                }

                                var HoraExtraStatusModel = new SolicitacaoStatusModel();
                                HoraExtraStatusModel.Id = horaExtraColabResult.SolicitacaoStatusId;
                                HoraExtraStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)horaExtraColabResult.SolicitacaoStatusId);
                                horaExtraColabResult.SolicitacaoStatus = HoraExtraStatusModel;

                                result.SolicitacaoHoraExtraColaborador.Add(horaExtraColabResult);
                            }
                            else
                            {
                                result = "Registro não encontrado";
                            }
                        }
                    }
                    else
                    {
                        result = "Solicitação de Hora Extra não encontrada";
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

        private static void AdicionarSolicitacaoHoraExtraNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 7; //Solicitação de Hora Extra
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private ErrorModel ValidacaoEntrada(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            var erroModel = new ErrorModel();

            if (solicitacaoHoraExtra.GestorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Gestor";
            }
            else if (solicitacaoHoraExtra.Data == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Data";
            }
            else if (solicitacaoHoraExtra.HoraInicio == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Hora Inicial";
            }
            else if (solicitacaoHoraExtra.HoraFim == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Hora Final";
            }
            else if (solicitacaoHoraExtra.TemMarmitex && solicitacaoHoraExtra.TemRefeicao)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe apenas um tipo de Aliementação";
            }
            //else if (solicitacaoHoraExtra.TemMarmitex && solicitacaoHoraExtra.MarmitexId == null)
            //{
            //    erroModel.Codigo = 600;
            //    erroModel.Descricao = "Informe a Marmitex";
            //}
            else if (solicitacaoHoraExtra.MarmitexId != null)
            {
                var result = _repoCustomMarmitex.GetMarmitexbyId(solicitacaoHoraExtra.MarmitexId.Value);

                if (result == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Marmitex não encontrada";
                }
            }
            else
            {
                var result = _repoCustomSolicitacaoHoraExtra.GetSolicitacaoHoraExtraValidation(solicitacaoHoraExtra);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Já existe uma solicitação no periodo informado.";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoConvocarFuncionarios(SolicitacaoHoraExtraModel solicitacaoHoraExtra)
        {
            var erroModel = new ErrorModel();

            if (solicitacaoHoraExtra.Id == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Id da Solicitação de Hora Extra";
            }
            else if (solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe os Id de Colaboradores";
            }
            else if (solicitacaoHoraExtra.TemMarmitex && solicitacaoHoraExtra.TemRefeicao)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe apenas um tipo de Aliementação";
            }
            else if (solicitacaoHoraExtra.TemMarmitex && solicitacaoHoraExtra.MarmitexId == null)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Marmitex";
            }
            else if (solicitacaoHoraExtra.MarmitexId != null)
            {
                var result = _repoCustomMarmitex.GetMarmitexbyId(solicitacaoHoraExtra.MarmitexId.Value);

                if (result == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Marmitex não encontrada";
                }
            }

            return erroModel;
        }
    }
}