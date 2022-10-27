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
    public class ColaboradorEmpregadorFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultColaboradorEmpregador;

        private static dynamic _repoCustomColaboradorEmpregador;
        private static dynamic _repoCustomColaboradorDadoPrincipal;

        public ColaboradorEmpregadorFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultColaboradorEmpregador = RepositoryFactory.CreateRepository<ColaboradorEmpregadorModel, Repository<ColaboradorEmpregadorModel>>(_unitOfWork);
            _repoCustomColaboradorEmpregador = RepositoryFactory.CreateRepositoryCustom<ColaboradorEmpregadorModel, ColaboradorEmpregadorRepository>(_unitOfWork);
            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);

        }

        public dynamic BuscarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            try
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregador(colaboradorEmpregador);
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

        public dynamic BuscarEmpregadorColaboradorPreAdmissao(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            try
            {
                //var result = _repoCustomColaboradorEmpregador.GetColaboradorPreAdmissaoEmpregador(colaboradorEmpregador);
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorPreAdmissaobyId(colaboradorEmpregador.ColaboradorId);
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

        public dynamic BuscarColaboradorEmpregadorPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyColaboradorId(colaboradorId);
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
        public dynamic BuscarColaboradorEmpregadorPreAdmissaoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorPreAdmissaobyId(colaboradorId);
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

        public dynamic BuscarColaboradorEmpregadorPorNome(string nome)
        {
            try
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorByNome(nome);
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

        public dynamic BuscarColaboradorEmpregadorPorGestorId(int gestorId)
        {
            try
            {
                var gestor = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(gestorId);

                List<ColaboradorEmpregadorModel> result = new List<ColaboradorEmpregadorModel>();
                EquipeGestorFacade equipeGestor = new EquipeGestorFacade();
                var resultEquipeRepo = equipeGestor.BuscarEquipeGestorPorGestorId(gestorId);

                foreach(var resultEquipeFor in resultEquipeRepo)
                {                    
                    var resultColaboradorRepo = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorByLotacao(resultEquipeFor.LotacaoUnidadeInicial.Codigo, resultEquipeFor.LotacaoUnidadeFinal.Codigo, gestor.Empresa.Id, gestor.Empresa.EmpresaMatrizId);
                    foreach (var resultColaboradorFor in resultColaboradorRepo)
                    {
                        result.Add(resultColaboradorFor);
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

        public dynamic AdicionarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorEmpregador);
               

                if (validacaoEntrada.Codigo == 0)
                {
                    colaboradorEmpregador.DataCadastro = DateTime.Now;
                    _repoDefaultColaboradorEmpregador.Add(colaboradorEmpregador);
                    _unitOfWork.Commit();
                    
                    ColaboradorEmpregadorModel result;
                    ColaboradorModel colaborador;

                    colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorEmpregador.ColaboradorId);

                    if(colaborador == null)
                    {
                        colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorEmpregador.ColaboradorId);
                        result = _repoCustomColaboradorEmpregador.GetColaboradorEstrangeiroPreAdmissaobyId(colaboradorEmpregador.ColaboradorId);
                    }
                    
                    else
                    {
                        result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyId(colaboradorEmpregador.ColaboradorId);
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

        public dynamic EditarEmpregadorColaborador(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorEmpregador);
                if (validacaoEntrada.Codigo == 0)
                {
                    var colaboradorEmpregadorResult = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorEditarById(colaboradorEmpregador.Id);

                    if (colaboradorEmpregadorResult != null)
                    {
                        colaboradorEmpregadorResult.ColaboradorId = colaboradorEmpregador.ColaboradorId;
                        colaboradorEmpregadorResult.CargoUnidadeId = colaboradorEmpregador.CargoUnidadeId;
                        colaboradorEmpregadorResult.CentroCustoUnidadeId = colaboradorEmpregador.CentroCustoUnidadeId;
                        colaboradorEmpregadorResult.LotacaoUnidadeId = colaboradorEmpregador.LotacaoUnidadeId;
                        colaboradorEmpregadorResult.TipoRegistroId = colaboradorEmpregador.TipoRegistroId;
                        colaboradorEmpregadorResult.TipoMaoObraId = colaboradorEmpregador.TipoMaoObraId;
                        colaboradorEmpregadorResult.UnidadeNegocioId = colaboradorEmpregador.UnidadeNegocioId;
                        colaboradorEmpregadorResult.NumeroCartaoPonto = colaboradorEmpregador.NumeroCartaoPonto;
                        colaboradorEmpregadorResult.Situacao = colaboradorEmpregador.Situacao;
                        colaboradorEmpregadorResult.TurnoId = colaboradorEmpregador.TurnoId;
                        colaboradorEmpregadorResult.CategoriaSalarialId = colaboradorEmpregador.CategoriaSalarialId;
                        colaboradorEmpregadorResult.Salario = colaboradorEmpregador.Salario;
                        colaboradorEmpregadorResult.DataAdmissao = colaboradorEmpregador.DataAdmissao;
                        colaboradorEmpregadorResult.SindicatoId = colaboradorEmpregador.SindicatoId;

                        _unitOfWork.Commit();

                        result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorEditarById(colaboradorEmpregadorResult.Id);
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

        public void MovimentacaoContratualColaboradorPagamento(MovimentacaoContratualModel movimentacaoContratual)
        {
            try
            {
                var colaboradorEmpregadorResult = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyColaboradorId(movimentacaoContratual.ColaboradorId);

                if (colaboradorEmpregadorResult != null)
                {
                    colaboradorEmpregadorResult.LotacaoUnidadeId = movimentacaoContratual.LotacaoUnidadeId;
                    colaboradorEmpregadorResult.CentroCustoUnidadeId = movimentacaoContratual.CentroCustoUnidadeId;
                    colaboradorEmpregadorResult.CargoUnidadeId = movimentacaoContratual.CargoUnidadeId;
                    colaboradorEmpregadorResult.TurnoId = movimentacaoContratual.TurnoId;
                    colaboradorEmpregadorResult.UnidadeNegocioId = movimentacaoContratual.UnidadeNegocioId;
                    colaboradorEmpregadorResult.NumeroCartaoPonto = movimentacaoContratual.NumeroCartaoPonto;
                    colaboradorEmpregadorResult.TipoMaoObraId = movimentacaoContratual.TipoMaoObraId;
                    colaboradorEmpregadorResult.Salario = movimentacaoContratual.Salario;
                    
                    _unitOfWork.Commit();
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

        private ErrorModel ValidacaoEntrada(ColaboradorEmpregadorModel colaboradorEmpregador)
        {
            var erroModel = new ErrorModel();

            if (colaboradorEmpregador.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Colaborador";
            }
            else if (colaboradorEmpregador.CargoUnidadeId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Cargo";
            }
            else if (colaboradorEmpregador.CentroCustoUnidadeId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Centro de Custo";
            }
            else if (colaboradorEmpregador.LotacaoUnidadeId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Lotação";
            }
            else
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorValidation(colaboradorEmpregador);
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
