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
using System.Collections.ObjectModel;

namespace lurin.meurhonline.application
{
    public class BancoHorasFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultBancoHoras;
        private static dynamic _repoDefaultBancoHorasLog;

        private static dynamic _repoCustomBancoHoras;
        private static dynamic _repoCustomBancoHorasLog;

        private static dynamic _domainBancoHoras;

        public BancoHorasFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultBancoHoras = RepositoryFactory.CreateRepository<BancoHorasModel, Repository<BancoHorasModel>>(_unitOfWork);
            _repoDefaultBancoHorasLog = RepositoryFactory.CreateRepository<BancoHorasLogModel, Repository<BancoHorasLogModel>>(_unitOfWork);

            _repoCustomBancoHoras = RepositoryFactory.CreateRepositoryCustom<BancoHorasModel, BancoHorasRepository>(_unitOfWork);
            _repoCustomBancoHorasLog = RepositoryFactory.CreateRepositoryCustom<BancoHorasLogModel, BancoHorasLogRepository>(_unitOfWork);

            _domainBancoHoras = DomainFactory.CreateDomain<BancoHorasModel, BancoHorasDomain>(_unitOfWork);
        }

        public dynamic BuscarBancoHorasPorId(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomBancoHoras.GetBancoHorasById(id);

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

        public dynamic BuscarTudoBancoHoras()
        {
            var result = new List<BancoHorasModel>();

            try
            {
                List<BancoHorasModel> resultRepo = _repoCustomBancoHoras.GetAllBancoHoras();

                foreach(var resultfor in resultRepo)
                {
                    EmpresaFacade empresaFacade = new EmpresaFacade();
                    resultfor.Empresa = empresaFacade.BuscarEmpresaPorId(resultfor.EmpresaId);

                    result.Add(resultfor);
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

        public dynamic BuscarBancoHorasPorEmpresaId(int id)
        {
            var result = new List<BancoHorasModel>();

            try
            {
                List<BancoHorasModel> resultRepo = _repoCustomBancoHoras.GetBancoHorasByEmpresaId(id);

                foreach (var resultfor in resultRepo)
                {
                    EmpresaFacade empresaFacade = new EmpresaFacade();
                    resultfor.Empresa = empresaFacade.BuscarEmpresaPorId(resultfor.EmpresaId);

                    result.Add(resultfor);
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

        public dynamic BuscarBancoHorasPorGestorId(int id)
        {
            var result = new List<BancoHorasModel>();

            try
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var colaboradorGestor = colaboradorFacade.BuscarColaboradorPorGestorId(id);

                foreach(var colaborador in colaboradorGestor)
                {
                    List<BancoHorasModel> resultRepo = _repoCustomBancoHoras.GetBancoHorasByColaboradorId(colaborador.Id);

                    foreach (var resultfor in resultRepo)
                    {
                        EmpresaFacade empresaFacade = new EmpresaFacade();
                        resultfor.Empresa = empresaFacade.BuscarEmpresaPorId(resultfor.EmpresaId);

                        result.Add(resultfor);
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

        public dynamic BuscarTudoBancoHorasLog()
        {

            try
            {
                var result = _repoCustomBancoHorasLog.GetAllBancoHorasLog();

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

        public dynamic BuscarBancoHorasLogPorEmpresaId(int id)
        {

            try
            {
                var result = _repoCustomBancoHorasLog.GetBancoHorasLogByEmpresaId(id);

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

        public dynamic BuscarBancoHorasPorColaboradorId(int id)
        {
            var result = new List<BancoHorasModel>();

            try
            {
                List<BancoHorasModel> resultRepo = _repoCustomBancoHoras.GetBancoHorasByColaboradorId(id);

                foreach (var resultfor in resultRepo)
                {
                    EmpresaFacade empresaFacade = new EmpresaFacade();
                    resultfor.Empresa = empresaFacade.BuscarEmpresaPorId(resultfor.EmpresaId);

                    result.Add(resultfor);
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

        public dynamic AdicionarBancoHoras(BancoHorasModel bancoHoras)
        {

            IList<BancoHorasLogModel> bancoHorasLogList = new List<BancoHorasLogModel>();
            BancoHorasLogModel resultItem = new BancoHorasLogModel();

            IList<BancoHorasModel> bancoHorasDetalhe = new List<BancoHorasModel>();
            IList<BancoHorasModel> bancoHorasList = new List<BancoHorasModel>();

            try
            {
                var validaBancoHoras = ValidacaoEntrada(bancoHoras);
                if (validaBancoHoras.Codigo == 0)
                {
                    if (_domainBancoHoras.DecodeArquivoTxtBancoHoras(bancoHoras))
                    {
                        bancoHorasDetalhe = _domainBancoHoras.AdicionarBancoHorasDetahes(bancoHoras);

                        foreach (var detalhe in bancoHorasDetalhe)
                        {
                            var resultBancoLog = ValidacaoProcessamento(detalhe);
                            if (resultBancoLog != null)
                            {
                                bancoHorasLogList.Add(resultBancoLog);
                            }
                            else
                            {
                                bancoHorasList.Add(detalhe);
                            }
                        }
                        
                    }
                    else
                    {
                        resultItem.DataImportacao = DateTime.Now;
                        resultItem.Erro = "Erro na conversão do arquivo TXT.";
                        return resultItem;
                    }


                    ApagarBancoHorasLog(bancoHoras.EmpresaId);
                    GravaBancoHorasLog(bancoHorasLogList);

                    ApagarBancoHoras(bancoHoras.EmpresaId);
                    GravaBancoHoras(bancoHorasList);

                }
                else
                {
                    return validaBancoHoras;
                }

                
                return bancoHorasLogList;
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

        private void ApagarBancoHoras(int empresaId)
        {
            var result = _repoCustomBancoHoras.GetBancoHorasByEmpresaId(empresaId);
            _repoDefaultBancoHoras.Delete(result);
            _unitOfWork.Commit();
        }

        private void GravaBancoHoras(IList<BancoHorasModel> BancoHoras)
        {
            _repoDefaultBancoHoras.Add(BancoHoras);
            _unitOfWork.Commit();
        }

        private void ApagarBancoHorasLog(int empresaId)
        {
            var result = _repoCustomBancoHorasLog.GetBancoHorasLogByEmpresaId(empresaId);
            _repoDefaultBancoHorasLog.Delete(result);
            _unitOfWork.Commit();
        }

        private void GravaBancoHorasLog(IEnumerable<BancoHorasLogModel> bancoHorasLog)
        {
         
                _repoDefaultBancoHorasLog.Add(bancoHorasLog);
                _unitOfWork.Commit();
        }

        private ErrorModel ValidacaoEntrada(BancoHorasModel BancoHoras)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(BancoHoras.DocumentoBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Invalido";
            }

            return erroModel;
        }

        private BancoHorasLogModel ValidacaoProcessamento(BancoHorasModel bancoHoras)
        {
            BancoHorasLogModel result = null;
            ColaboradorFacade colaborador = new ColaboradorFacade();

            var resultColaborador = colaborador.BuscarColaboradorPorMatricula(bancoHoras.Matricula);

            if (resultColaborador == null)
            {
                result = new BancoHorasLogModel();
                result.EmpresaId = bancoHoras.EmpresaId;
                result.ColaboradorNome = bancoHoras.ColaboradorNome;
                result.Matricula = bancoHoras.Matricula;
                result.DataImportacao = DateTime.Now;
                result.Erro = "Matrícula não encontrada";
            }
            else
            {
                bancoHoras.ColaboradorId = resultColaborador.Id;

                if (resultColaborador.EmpresaId != bancoHoras.EmpresaId)
                {
                    result = new BancoHorasLogModel();
                    result.EmpresaId = bancoHoras.EmpresaId;
                    result.ColaboradorNome = bancoHoras.ColaboradorNome;
                    result.Matricula = bancoHoras.Matricula;
                    result.DataImportacao = DateTime.Now;
                    result.Erro = "Matrícula não pertence a empresa";
                }
            }

            return result;
        }
    }
}