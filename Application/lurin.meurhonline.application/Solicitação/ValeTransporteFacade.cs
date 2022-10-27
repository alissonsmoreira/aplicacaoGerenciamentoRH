using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

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
    public class ValeTransporteFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultValeTransporte;
        private static dynamic _repoDefaultValeTransporteUtilizacao;
        private static dynamic _repoDefaultValeTransporteSituacao;

        private static dynamic _repoCustomValeTransporte;

        public ValeTransporteFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultValeTransporte = RepositoryFactory.CreateRepository<ValeTransporteModel, Repository<ValeTransporteModel>>(_unitOfWork);
            _repoDefaultValeTransporteUtilizacao = RepositoryFactory.CreateRepository<ValeTransporteUtilizacaoModel, Repository<ValeTransporteUtilizacaoModel>>(_unitOfWork);
            _repoDefaultValeTransporteSituacao = RepositoryFactory.CreateRepository<ValeTransporteSituacaoModel, Repository<ValeTransporteSituacaoModel>>(_unitOfWork);

            _repoCustomValeTransporte = RepositoryFactory.CreateRepositoryCustom<ValeTransporteModel, ValeTransporteRepository>(_unitOfWork);
        }

        public dynamic BuscarSolicitacaoValeTransporte(ValeTransporteModel valeTransporte)
        {
            try
            {
                var resultRepo = _repoCustomValeTransporte.GetValeTransporte(valeTransporte);

                var result = new List<ValeTransporteModel>();
                foreach (ValeTransporteModel resultFor in resultRepo)
                {
                    OperadoraVTFacade operadoraVTFacade = new OperadoraVTFacade();
                    LinhaVTFacade linhaVTFacade = new LinhaVTFacade();

                    var solicitacaoStatusModel = new SolicitacaoStatusModel();
                    solicitacaoStatusModel.Id = resultFor.SolicitacaoStatusId;
                    solicitacaoStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = solicitacaoStatusModel;

                    resultFor.OperadoraVT = operadoraVTFacade.BuscarOperadoraVTPorId(resultFor.OperadoraVTId);
                    resultFor.LinhaVT = linhaVTFacade.BuscarLinhaVTPorId(resultFor.LinhaVTId);

                    var diasSemanaList = resultFor.DiasSemana.Split(',').ToList();
                    resultFor.DiasSemana = string.Empty;
                    foreach (var dia in diasSemanaList)
                    {
                        if (string.IsNullOrEmpty(resultFor.DiasSemana))
                            resultFor.DiasSemana = Utils.GetEnumDescription((ValeTransporteDiasSemanaEnum)Convert.ToInt16(dia));
                        else
                            resultFor.DiasSemana += string.Concat(",", Utils.GetEnumDescription((ValeTransporteDiasSemanaEnum)Convert.ToInt16(dia)));
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

        public dynamic BuscarSolicitacaoValeTransportePorColaboradorId(int colaboradorId)
        {
            try
            {
                var resultRepo = _repoCustomValeTransporte.GetValeTransportebyColaboradorId(colaboradorId);

                var result = new List<ValeTransporteModel>();
                foreach (ValeTransporteModel resultFor in resultRepo)
                {
                    OperadoraVTFacade operadoraVTFacade = new OperadoraVTFacade();
                    LinhaVTFacade linhaVTFacade = new LinhaVTFacade();

                    var ValeTransporteStatusModel = new SolicitacaoStatusModel();
                    ValeTransporteStatusModel.Id = resultFor.SolicitacaoStatusId;
                    ValeTransporteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor.SolicitacaoStatusId);
                    resultFor.SolicitacaoStatus = ValeTransporteStatusModel;

                    resultFor.OperadoraVT = operadoraVTFacade.BuscarOperadoraVTPorId(resultFor.OperadoraVTId);
                    resultFor.LinhaVT = linhaVTFacade.BuscarLinhaVTPorId(resultFor.LinhaVTId);

                    var diasSemanaList = resultFor.DiasSemana.Split(',').ToList();
                    resultFor.DiasSemana = string.Empty;
                    foreach (var dia in diasSemanaList)
                    {
                        if (string.IsNullOrEmpty(resultFor.DiasSemana))
                            resultFor.DiasSemana = Utils.GetEnumDescription((ValeTransporteDiasSemanaEnum)Convert.ToInt16(dia));
                        else
                            resultFor.DiasSemana += string.Concat(",",Utils.GetEnumDescription((ValeTransporteDiasSemanaEnum)Convert.ToInt16(dia)));
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

        public dynamic BuscarTudoValeTransporteUtilizacao()
        {
            try
            {
                var result = Cache.Get<List<ValeTransporteUtilizacaoModel>>("ValeTransporteUtilizacao");
                if (result == null)
                {
                    result = _repoDefaultValeTransporteUtilizacao.GetAll();

                    Cache.AddItem("ValeTransporteUtilizacao", result, 1);
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

        public dynamic BuscarTudoValeTransporteSituacao()
        {
            try
            {
                var result = Cache.Get<List<ValeTransporteSituacaoModel>>("ValeTransporteSituacao");
                if (result == null)
                {
                    result = _repoDefaultValeTransporteSituacao.GetAll();

                    Cache.AddItem("ValeTransporteSituacao", result, 1);
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

        public dynamic SolicitarValeTransporte(ValeTransporteModel valeTransporte)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(valeTransporte);
                if (validacaoEntrada.Codigo == 0)
                {
                    valeTransporte.DataSolicitacao = DateTime.Now;
                    valeTransporte.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE;

                    _repoDefaultValeTransporte.Add(valeTransporte);
                    _unitOfWork.Commit();

                    AdicionarValeTransporteNotificacao(valeTransporte.ColaboradorId);

                    var result = _repoCustomValeTransporte.GetValeTransportebyId(valeTransporte.Id);

                    var ValeTransporteStatusModel = new SolicitacaoStatusModel();
                    ValeTransporteStatusModel.Id = result.SolicitacaoStatusId;
                    ValeTransporteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                    result.SolicitacaoStatus = ValeTransporteStatusModel;

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

        public dynamic AprovarSolicitacaoValeTransporte(int valeTransporteId)
        {
            dynamic result;

            try
            {
                var ValeTransporteResult = _repoCustomValeTransporte.GetValeTransportebyId(valeTransporteId);

                if (ValeTransporteResult != null)
                {
                    if (ValeTransporteResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {

                        ValeTransporteResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.APROVADO;
                        ValeTransporteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomValeTransporte.GetValeTransportebyId(ValeTransporteResult.Id);

                        var ValeTransporteStatusModel = new SolicitacaoStatusModel();
                        ValeTransporteStatusModel.Id = result.SolicitacaoStatusId;
                        ValeTransporteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = ValeTransporteStatusModel;

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

        public dynamic ReprovarSolicitacaoValeTransporte(int valeTransporteId)
        {
            dynamic result;

            try
            {
                var ValeTransporteResult = _repoCustomValeTransporte.GetValeTransportebyId(valeTransporteId);

                if (ValeTransporteResult != null)
                {
                    if (ValeTransporteResult.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                    {
                        ValeTransporteResult.SolicitacaoStatusId = (int)SolicitacaoStatusEnum.REPROVADO;
                        ValeTransporteResult.DataConclusao = DateTime.Now;

                        _unitOfWork.Commit();

                        result = _repoCustomValeTransporte.GetValeTransportebyId(ValeTransporteResult.Id);

                        var ValeTransporteStatusModel = new SolicitacaoStatusModel();
                        ValeTransporteStatusModel.Id = result.SolicitacaoStatusId;
                        ValeTransporteStatusModel.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)result.SolicitacaoStatusId);
                        result.SolicitacaoStatus = ValeTransporteStatusModel;

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

        private static void AdicionarValeTransporteNotificacao(int colaboradorId)
        {

            NotificacaoFacade NotificacaoFacade = new NotificacaoFacade();
            var notificacao = new NotificacaoModel();
            notificacao.NotificacaoDetalheId = 6; //Solicitação de Vale Transporte
            notificacao.NotificacaoStatusLeituraId = (int)NotificacaoStatusLeituraEnum.NAO_LIDO;
            notificacao.ById = colaboradorId;

            NotificacaoFacade.AdicionarNotificacao(notificacao);
        }

        private ErrorModel ValidacaoEntrada(ValeTransporteModel ValeTransporte)
        {
            var erroModel = new ErrorModel();

            if (ValeTransporte.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else if (ValeTransporte.OperadoraVTId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Operadora VT";
            }
            else if (ValeTransporte.LinhaVTId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Linha VT";
            }
            else if (ValeTransporte.ValeTransporteUtilizacaoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Utilização";
            }
            else if (ValeTransporte.ValeTransporteSituacaoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Situação";
            }
            else
            {
                var result = _repoCustomValeTransporte.GetValeTransporteValidation(ValeTransporte);
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