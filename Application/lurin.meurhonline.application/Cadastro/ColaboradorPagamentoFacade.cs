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
    public class ColaboradorPagamentoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultColaboradorPagamento;

        private static dynamic _repoCustomColaboradorPagamento;

        private static dynamic _repoCustomColaboradorDadoPrincipal;

        public ColaboradorPagamentoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultColaboradorPagamento = RepositoryFactory.CreateRepository<ColaboradorPagamentoModel, Repository<ColaboradorPagamentoModel>>(_unitOfWork);
            _repoCustomColaboradorPagamento = RepositoryFactory.CreateRepositoryCustom<ColaboradorPagamentoModel, ColaboradorPagamentoRepository>(_unitOfWork);
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);


        }

        public dynamic BuscarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            try
            {
                var result = _repoCustomColaboradorPagamento.GetColaboradorPagamento(colaboradorPagamento);
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

        public dynamic BuscarPagamentoColaboradorPreAdmissao(ColaboradorPagamentoModel colaboradorPagamento)
        {
            try
            {
                var result = _repoCustomColaboradorPagamento.GetColaboradorPreAdmissaoPagamento(colaboradorPagamento);
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
        
        public dynamic BuscarPagamentoColaboradorPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorPagamento.GetColaboradorPagamentobyColaboradorId(colaboradorId);
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

        public dynamic BuscarPagamentoColaboradorPreAdmissaoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorPagamento.GetColaboradorPagamentoPreAdmissaobyId(colaboradorId);
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

        public dynamic AdicionarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorPagamento);
                
                
                if (validacaoEntrada.Codigo == 0)
                {
                    colaboradorPagamento.DataCadastro = DateTime.Now;
                    _repoDefaultColaboradorPagamento.Add(colaboradorPagamento);
                    _unitOfWork.Commit();

                    ColaboradorPagamentoModel result;
                    ColaboradorModel colaborador;

                    colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorPagamento.ColaboradorId);

                    if (colaborador == null)
                    {
                        colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorPagamento.ColaboradorId);
                        result = _repoCustomColaboradorPagamento.GetColaboradorPagamentoPreAdmissaobyId(colaboradorPagamento.ColaboradorId);
                    }
                    else
                    {
                        result = _repoCustomColaboradorPagamento.GetColaboradorPagamentobyId(colaboradorPagamento.ColaboradorId);
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

        public dynamic EditarPagamentoColaborador(ColaboradorPagamentoModel colaboradorPagamento)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorPagamento);
                if (validacaoEntrada.Codigo == 0)
                {
                    var colaboradorPagamentoResult = _repoCustomColaboradorPagamento.GetColaboradorPagamentoEditarById(colaboradorPagamento.Id);

                    if (colaboradorPagamentoResult != null)
                    {
                        colaboradorPagamentoResult.ColaboradorId = colaboradorPagamento.ColaboradorId;
                        colaboradorPagamentoResult.BancoId = colaboradorPagamento.BancoId;
                        colaboradorPagamentoResult.Agencia = colaboradorPagamento.Agencia;
                        colaboradorPagamentoResult.Conta = colaboradorPagamento.Conta;
                        colaboradorPagamentoResult.ContaBancariaTipoId = colaboradorPagamento.ContaBancariaTipoId;

                        _unitOfWork.Commit();

                        result = _repoCustomColaboradorPagamento.GetColaboradorPagamentoEditarById(colaboradorPagamentoResult.Id);
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

        public void AlteracaoCadastralColaboradorPagamento(AlteracaoCadastralModel alteracaoCadastral)
        {
            try
            {
                var colaboradorPagamentoResult = _repoCustomColaboradorPagamento.GetColaboradorPagamentobyColaboradorId(alteracaoCadastral.ColaboradorId);

                if (colaboradorPagamentoResult != null)
                {
                    colaboradorPagamentoResult.BancoId = alteracaoCadastral.BancoId;
                    colaboradorPagamentoResult.Agencia = alteracaoCadastral.Agencia;
                    colaboradorPagamentoResult.Conta = alteracaoCadastral.Conta;
                    colaboradorPagamentoResult.ContaBancariaTipoId = alteracaoCadastral.ContaBancariaTipoId;
                    _unitOfWork.Commit();
                }
                else
                {
                    ColaboradorPagamentoModel colaboradorPagamento = new ColaboradorPagamentoModel();
                    colaboradorPagamento.ColaboradorId = alteracaoCadastral.ColaboradorId;
                    colaboradorPagamento.BancoId = alteracaoCadastral.BancoId;
                    colaboradorPagamento.Agencia = alteracaoCadastral.Agencia;
                    colaboradorPagamento.Conta = alteracaoCadastral.Conta;
                    colaboradorPagamento.ContaBancariaTipoId = alteracaoCadastral.ContaBancariaTipoId;
                    AdicionarPagamentoColaborador(colaboradorPagamento);
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

        private ErrorModel ValidacaoEntrada(ColaboradorPagamentoModel colaboradorPagamento)
        {
            var erroModel = new ErrorModel();

            if (colaboradorPagamento.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Colaborador";
            }
            else if (colaboradorPagamento.BancoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Banco";
            }
            else if (string.IsNullOrEmpty(colaboradorPagamento.Agencia))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Agência";
            }
            else if (string.IsNullOrEmpty(colaboradorPagamento.Conta))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Conta";
            }
            else if (colaboradorPagamento.ContaBancariaTipoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Tipo de Conta";
            }
            else
            {
                var result = _repoCustomColaboradorPagamento.GetColaboradorPagamentoValidation(colaboradorPagamento);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }
    }
}
