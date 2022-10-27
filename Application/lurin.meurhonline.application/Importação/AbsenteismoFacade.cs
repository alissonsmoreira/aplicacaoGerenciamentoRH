using System.Linq;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.log;
using System;

namespace lurin.meurhonline.application
{
    public class AbsenteismoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _domainAbsenteismo;
        private static dynamic _repoAbsenteismo;
        private static dynamic _repoAbsenteismoLog;
        private static dynamic _repoCustomAbsenteismo;
        
        public AbsenteismoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _domainAbsenteismo = DomainFactory.CreateDomain<AbsenteismoModel, AbsenteismoDomain>(_unitOfWork);
            _repoAbsenteismo = RepositoryFactory.CreateRepository<AbsenteismoModel, Repository<AbsenteismoModel>>(_unitOfWork);
            _repoAbsenteismoLog = RepositoryFactory.CreateRepository<AbsenteismoLogModel, Repository<AbsenteismoLogModel>>(_unitOfWork);
            _repoCustomAbsenteismo = RepositoryFactory.CreateRepositoryCustom<AbsenteismoModel, AbsenteismoRepository>(_unitOfWork);
        }

        public dynamic ImportarAbsenteismo(AbsenteismoModel absenteismo)
        {
            List<AbsenteismoLogModel> absenteismoLogs = new List<AbsenteismoLogModel>();

            try
            {
                var validacaodocumento = ValidacaoDocumento(absenteismo);
                if (validacaodocumento.Codigo == 0)
                {
                    List<AbsenteismoModel> listaAbsenteismo = _domainAbsenteismo.ConverterArquivoExcel(absenteismo.ExcelBase64);

                    if (listaAbsenteismo.Count > 0)
                    {
                        ApagarAbsenteismoLog();
                        VerificaDuplicidade(absenteismo.Ano, absenteismo.Ano);
                        foreach (AbsenteismoModel abs in listaAbsenteismo)
                        {
                            abs.Ano = absenteismo.Ano;
                            abs.Mes = absenteismo.Mes;

                            var ret = AdicionarAbsenteismo(abs);

                            if ((ret as AbsenteismoLogModel != null))
                            {
                                AbsenteismoLogModel log = ret;
                                if (!string.IsNullOrEmpty(log.LogErro))
                                {
                                    absenteismoLogs.Add(log);
                                }
                            }

                        }
                    }
                }
                else
                {
                    return validacaodocumento;
                }
                return absenteismoLogs;
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

        public dynamic BuscarAbsenteismoPorColaboradorId(int colaboradorId)
        {
            var result = new List<AbsenteismoModel>();

            try
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorId(colaboradorId);

                if (colaborador == null)
                {
                    AbsenteismoModel abs = new AbsenteismoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Colaborador não existe"
                        }
                    };

                    result.Add(abs); 
                }
                else
                {
                    result = _repoCustomAbsenteismo.GetAbsenteismoByColaboradorId(colaborador.Id);

                    //ATUALIZA A PROPRIEDADE ABSENTEÍSMO DA LISTA PARA 2 CASAS DECIMAIS                                        
                    result.Where(x => x.Absenteismo != "" && x.Absenteismo != "0").Select(s => { s.Absenteismo = string.Concat(Math.Round(Convert.ToDouble(s.Absenteismo), 2).ToString(), "%"); return s; }).ToList();
                    result.Where(x => x.Absenteismo == "" || x.Absenteismo == "0").Select(s => { s.Absenteismo = "0,00%"; return s; }).ToList();

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

        public dynamic BuscarAbsenteismoPorAnoMes(string ano, string mes)
        {
            dynamic result;

            try
            {

                if (ano == null)
                {
                    AbsenteismoModel abs = new AbsenteismoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Ano não informado"
                        }
                    };
                    result = abs;
                }
                else if (mes == null)
                {
                    AbsenteismoModel abs = new AbsenteismoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Mes não informado"
                        }
                    };
                    result = abs;
                }
                else
                {
                    var resultRepo = new List<AbsenteismoModel>();
                    resultRepo = _repoCustomAbsenteismo.GetAbsenteismoByAnoMes(ano, mes);

                    //ATUALIZA A PROPRIEDADE ABSENTEÍSMO DA LISTA PARA 2 CASAS DECIMAIS                                        
                    resultRepo.Where(x => x.Absenteismo != "" && x.Absenteismo != "0").Select(s => { s.Absenteismo = string.Concat(Math.Round(Convert.ToDouble(s.Absenteismo), 2).ToString(), "%"); return s; }).ToList();
                    resultRepo.Where(x => x.Absenteismo == "" || x.Absenteismo == "0").Select(s => { s.Absenteismo = "0,00%"; return s; }).ToList();                    

                    result = resultRepo;
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

        public dynamic BuscarAbsenteismoPorGestorIdAnoMes(int gestorId, string ano, string mes)
        {
            var result = new List<AbsenteismoModel>();

            try
            {
                if (ano == null)
                {
                    AbsenteismoModel abs = new AbsenteismoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Ano não informado"
                        }
                    };
                    result.Add(abs);
                }
                else if (mes == null)
                {
                    AbsenteismoModel abs = new AbsenteismoModel()
                    {
                        Erro = new ErrorModel()
                        {
                            Codigo = 600,
                            Descricao = "Mes não informado"
                        }
                    };
                    result.Add(abs);
                }
                else
                {
                    ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                    var colaboradorGestor = colaboradorFacade.BuscarColaboradorPorGestorId(gestorId);

                    foreach (var colaborador in colaboradorGestor)
                    {
                        var listaAbs = _repoCustomAbsenteismo.GetAbsenteismoByColaboradorIdAnoMes(colaborador.Id, ano, mes);
                        if (listaAbs != null )
                        { 
                            result.Add(listaAbs);
                        }
                    }

                    if (result != null)
                    {
                        //ATUALIZA A PROPRIEDADE ABSENTEÍSMO DA LISTA PARA 2 CASAS DECIMAIS                                        
                        result.Where(x => x.Absenteismo != "" && x.Absenteismo != "0").Select(s => { s.Absenteismo = string.Concat(Math.Round(Convert.ToDouble(s.Absenteismo), 2).ToString(), "%"); return s; }).ToList();
                        result.Where(x => x.Absenteismo == "" || x.Absenteismo == "0").Select(s => { s.Absenteismo = "0,00%"; return s; }).ToList();
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

        public dynamic AdicionarAbsenteismo(AbsenteismoModel absenteismo)
        {
            var result = new AbsenteismoLogModel();
            try
            {
                AbsenteismoLogModel log = new AbsenteismoLogModel();
                var validacaoEntrada = ValidacaoEntrada(absenteismo);

                if (validacaoEntrada.Codigo == 0)
                {
                    absenteismo.DataCadastro = DateTime.Now;
                    _repoAbsenteismo.Add(absenteismo);
                    _unitOfWork.Commit();
                }
                else
                {
                    result.Cpf = absenteismo.Cpf;
                    result.LogErro = validacaoEntrada.Descricao;
                    result.DataCadastro = DateTime.Now;

                    _repoAbsenteismoLog.Add(result);
                }

                _unitOfWork.Commit();
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

        private ErrorModel ValidacaoDocumento(AbsenteismoModel absenteismo)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(absenteismo.ExcelBase64))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Arquivo Inválido";
            }
            else if (string.IsNullOrEmpty(absenteismo.Ano))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Ano não informado";
            }
            else if (string.IsNullOrEmpty(absenteismo.Mes))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Mês não informado";
            }
            
            return erroModel;
        }

        private ErrorModel ValidacaoEntrada(AbsenteismoModel absenteismo)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(absenteismo.Cpf))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Cpf não informado";
            }
            else
            {
                ColaboradorFacade colaboradorFacade = new ColaboradorFacade();
                var colaborador = colaboradorFacade.BuscarColaboradorDadoPrincipalPorCpf(absenteismo.Cpf);

                if (colaborador == null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "CPF não encontrado";
                }
                else
                {
                    absenteismo.ColaboradorId = colaborador.Id;
                }
            }
            
            return erroModel;
        }

        private void ApagarAbsenteismoLog()
        {
            var logs = _repoAbsenteismoLog.GetAll();
            _repoAbsenteismoLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private void VerificaDuplicidade(string ano, string mes)
        {
            List<AbsenteismoModel> absenteismosExistentes = _repoCustomAbsenteismo.GetAbsenteismoByAnoMes(ano, mes);
            if (absenteismosExistentes != null)
            {
                _repoAbsenteismo.Delete(absenteismosExistentes);
            }
        }
    }
}
