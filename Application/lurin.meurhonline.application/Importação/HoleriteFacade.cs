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
using lurin.meurhonline.domain.model.enumerator;
using System.Linq;

namespace lurin.meurhonline.application
{
    public class HoleriteFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultHolerite;
        private static dynamic _repoDefaultHoleriteEvento;
        private static dynamic _repoDefaultHoleriteLog;

        private static dynamic _repoCustomColaboradorDadoPrincipal;
        private static dynamic _repoCustomHolerite;

        private static dynamic _repoDefaultEmpresa;

        private static dynamic _domainHolerite;

        public HoleriteFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultHolerite = RepositoryFactory.CreateRepository<HoleriteModel, Repository<HoleriteModel>>(_unitOfWork);
            _repoDefaultHoleriteEvento = RepositoryFactory.CreateRepository<HoleriteEventoModel, Repository<HoleriteEventoModel>>(_unitOfWork);
            _repoDefaultHoleriteLog = RepositoryFactory.CreateRepository<HoleriteLogModel, Repository<HoleriteLogModel>>(_unitOfWork);

            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);
            _repoCustomHolerite = RepositoryFactory.CreateRepositoryCustom<HoleriteModel, HoleriteRepository>(_unitOfWork);

            _repoDefaultEmpresa = RepositoryFactory.CreateRepositoryCustom<EmpresaModel, EmpresaRepository>(_unitOfWork);

            _domainHolerite = DomainFactory.CreateDomain<HoleriteModel, HoleriteDomain>(_unitOfWork);
        }

        public dynamic BuscarHoleritePorId(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomHolerite.GetHoleriteById(id);

                if (result == null)
                {
                    result = "Registro não encontrado";
                }
                else
                {
                    result.TotalDescontos = FormatarRetornoNumero(result.TotalDescontos);
                    result.TotalProventos = FormatarRetornoNumero(result.TotalProventos);
                    result.BaseCalcFGTS = FormatarRetornoNumero(result.BaseCalcFGTS);
                    result.BaseCalcIRRF = FormatarRetornoNumero(result.BaseCalcIRRF);
                    result.FTGSMes = FormatarRetornoNumero(result.FTGSMes);
                    result.Liquido = FormatarRetornoNumero(result.Liquido);
                    result.SalarioBase = FormatarRetornoNumero(result.SalarioBase);
                    result.SalarioContrINSS = FormatarRetornoNumero(result.SalarioContrINSS);

                    foreach (HoleriteEventoModel eventos in result.HoleriteEventos)
                    {
                        eventos.ValoresNegativos = FormatarRetornoNumero(eventos.ValoresNegativos);
                        eventos.ValoresPositivos = FormatarRetornoNumero(eventos.ValoresPositivos);
                        eventos.Quantidade = FormatarRetornoNumero(eventos.Quantidade);
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
        public dynamic BuscarHoleritePorColaboradorIdMesAno(int colaboradorId, string mes, string ano, int? empresaId)
        {
            List<HoleriteModel> holeriteResult = new List<HoleriteModel>();
            List<EmpresaModel> empresas = new List<EmpresaModel>();

            try
            {
                if(colaboradorId != 0)
                {
                    ColaboradorModel colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorId);

                    if (colaborador == null)
                    {
                        HoleriteModel result = new HoleriteModel()
                        {
                            Erro = new ErrorModel()
                            {
                                Codigo = 600,
                                Descricao = "Colaborador não existe"
                            }
                        };

                        holeriteResult.Add(result);
                    }
                }

                if (!holeriteResult.Any())

                    holeriteResult = _repoCustomHolerite.GetHoleriteByColaboradorIdMesAno(colaboradorId, mes, ano, empresaId);

                //if (holeriteResult.Any())
                //{
                //    foreach (HoleriteModel holerite in holeriteResult)
                //    {
                //        holerite.TotalDescontos = holerite.TotalDescontos.Replace("-", "");
                //        holerite.TotalProventos = holerite.TotalProventos.Replace("+", "");

                //        foreach(HoleriteEventoModel eventos in holerite.HoleriteEventos)
                //        {
                //            eventos.ValoresNegativos = eventos.ValoresNegativos.Replace("-", "");
                //            eventos.ValoresPositivos = eventos.ValoresPositivos.Replace("+", "");
                //        }
                //    }
                //}

                return holeriteResult;
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

        public dynamic AdicionarHolerite(HoleriteModel holerite)
        {
            var validaHolerite = new HoleriteModel();
            IList<HoleriteLogModel> resultList = new List<HoleriteLogModel>();
            HoleriteLogModel resultItem = new HoleriteLogModel();
            IList<HoleriteModel> holeriteDetalhe = new List<HoleriteModel>();

            try
            {
                validaHolerite = ValidacaoEntrada(holerite);
                if (validaHolerite.Erro.Codigo == 0)
                {
                    holerite.Empresa = _repoDefaultEmpresa.GetEmpresabyId(holerite.EmpresaId.Value);

                    var arquivoCarregado = false;

                    switch (holerite.Empresa.FornecedorHolerite)
                    {
                        case (int)FornecedorHolerite.Domínio:
                            arquivoCarregado = _domainHolerite.DecodeArquivoXlsHolerite(holerite);
                            break;
                        case (int)FornecedorHolerite.Datasul:
                        default:
                            arquivoCarregado = _domainHolerite.DecodeArquivoTxtHolerite(holerite);
                            break;
                    }

                    if (arquivoCarregado)
                    {
                        ApagarHoleriteLog();
                        holeriteDetalhe = _domainHolerite.AdicionarHolerite(holerite);

                        foreach (var item in holeriteDetalhe)
                        {
                            var resultProcessamento = ValidacaoProcessamento(item);
                            if (resultProcessamento == null)
                            {
                                GravaHolerite(item);
                            }
                            else
                            {
                                GravaHoleriteLog(resultProcessamento);
                                resultList.Add(resultProcessamento);
                            }
                        }
                    }
                    else
                    {
                        resultItem.DataCadastro = DateTime.Now;
                        resultItem.LogErro = "Erro na conversão do arquivo.";
                        resultList.Add(resultItem);
                    }
                }
                else
                {
                    resultItem.DataCadastro = DateTime.Now;
                    resultItem.LogErro = validaHolerite.Erro.Descricao;
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

        private void GravaHolerite(HoleriteModel holeite)
        {
            _repoDefaultHolerite.Add(holeite);
            _unitOfWork.Commit();
        }

        private void ApagarHoleriteLog()
        {
            var logs = _repoDefaultHoleriteLog.GetAll();
            _repoDefaultHoleriteLog.Delete(logs);
            _unitOfWork.Commit();
        }

        private void GravaHoleriteLog(HoleriteLogModel holeiteLog)
        {
            _repoDefaultHoleriteLog.Add(holeiteLog);
            _unitOfWork.Commit();
        }
        public bool ExcluirHoleritesSelecionados(int[] holeritesIds)
        {
            List<HoleriteModel> holerites = new List<HoleriteModel>();
            foreach (int id in holeritesIds)
            {
                holerites.Add(_repoCustomHolerite.GetHoleriteById(id));
            }
            return _repoCustomHolerite.ExcluirHolerites(holerites);
        }
        private HoleriteModel ValidacaoEntrada(HoleriteModel holerite)
        {
            holerite.Erro = new ErrorModel();

            if (string.IsNullOrEmpty(holerite.DocumentoBase64))
            {
                holerite.Erro.Codigo = 600;
                holerite.Erro.Descricao = "Arquivo não informado";
            }
            else if (string.IsNullOrEmpty(holerite.Mes))
            {
                holerite.Erro.Codigo = 600;
                holerite.Erro.Descricao = "Mês não informado";
            }
            else if (string.IsNullOrEmpty(holerite.Ano))
            {
                holerite.Erro.Codigo = 600;
                holerite.Erro.Descricao = "Ano não informado";
            }
            else if (holerite.EmpresaId == null)
            {
                holerite.Erro.Codigo = 600;
                holerite.Erro.Descricao = "EmpresaId não informado";
            }

            return holerite;
        }

        private HoleriteLogModel ValidacaoProcessamento(HoleriteModel holerite)
        {
            HoleriteLogModel result = null;

            holerite.Colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyMatriculaEmpresa(holerite.Matricula, holerite.EmpresaId.Value);

            if (holerite.Colaborador == null)
            {
                result = new HoleriteLogModel();
                result.DataCadastro = DateTime.Now;
                result.Matricula = holerite.Matricula;
                result.LogErro = "Matrícula não encontrada";
            }
            else
            {
                var resultCustom = _repoCustomHolerite.GetHoleriteByColaboradorIdMesAno(holerite.Colaborador.Id, holerite.Mes, holerite.Ano, null);

                if (resultCustom?.Count > 0)
                {
                    result = new HoleriteLogModel();
                    result.DataCadastro = DateTime.Now;
                    result.Matricula = holerite.Matricula;
                    result.LogErro = "Holerite já importado";
                }
            }

            return result;
        }

        private string FormatarRetornoNumero(string valor) {
            if (valor == null)
                return string.Empty;

            if(valor.IndexOf(",") > -1)
            {
                valor = valor.Replace(".", "").Replace(",", ".");
            }

            return valor.Replace("-", "").Replace("+", "");
        }
    }
}