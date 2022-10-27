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
    public class ColaboradorDocumentacaoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultColaboradorDocumentacao;

        private static dynamic _repoCustomColaboradorDocumentacao;
        private static dynamic _repoCustomColaboradorEmpregador;

        public ColaboradorDocumentacaoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultColaboradorDocumentacao = RepositoryFactory.CreateRepository<ColaboradorDocumentacaoModel, Repository<ColaboradorDocumentacaoModel>>(_unitOfWork);
            _repoCustomColaboradorDocumentacao = RepositoryFactory.CreateRepositoryCustom<ColaboradorDocumentacaoModel, ColaboradorDocumentacaoRepository>(_unitOfWork);

        }

        public dynamic BuscarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            try
            {
                var result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacao(colaboradorDocumentacao);
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

        public dynamic BuscarDocumentacaoColaboradorPreAdmissao(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            try
            {
                var result = _repoCustomColaboradorDocumentacao.GetColaboradorPreAdmissaoDocumentacao(colaboradorDocumentacao);
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

        public dynamic BuscarDocumentacaoColaboradorPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaobyColaboradorId(colaboradorId);
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

        public dynamic BuscarColaboradorEmpregadorbyColaboradorIdOuTipoRegistro(int colaboradorId, int? tipoRegistro)
        {
            try
            {
                var result = _repoCustomColaboradorEmpregador.GetColaboradorEmpregadorbyColaboradorIdOuTipoRegistro(colaboradorId, tipoRegistro);
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


        public dynamic BuscarDocumentacaoColaboradorPreAdmissaoPorColaboradorId(int colaboradorId)
        {
            try
            {
                var result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaoPreAdmissaobyId(colaboradorId);
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

        public dynamic AdicionarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorDocumentacao);
                if (validacaoEntrada.Codigo == 0)
                {
                    colaboradorDocumentacao.DataCadastro = DateTime.Now;
                    _repoDefaultColaboradorDocumentacao.Add(colaboradorDocumentacao);
                    _unitOfWork.Commit();

                    var result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaobyId(colaboradorDocumentacao.Id);

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

        public dynamic EditarDocumentacaoColaborador(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorDocumentacao);
                if (validacaoEntrada.Codigo == 0)
                {
                    var colaboradorDocumentacaoResult = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaoEditarById(colaboradorDocumentacao.Id);

                    if (colaboradorDocumentacaoResult != null)
                    {
                        
                        colaboradorDocumentacaoResult.ColaboradorId = colaboradorDocumentacao.ColaboradorId;
                        colaboradorDocumentacaoResult.RG = colaboradorDocumentacao.RG;
                        colaboradorDocumentacaoResult.OrgaoEmissorRG = colaboradorDocumentacao.OrgaoEmissorRG;
                        colaboradorDocumentacaoResult.UFEmissaoRG = colaboradorDocumentacao.UFEmissaoRG;
                        colaboradorDocumentacaoResult.DataEmissaoRG = colaboradorDocumentacao.DataEmissaoRG;
                        colaboradorDocumentacaoResult.RIC = colaboradorDocumentacao.RIC;
                        colaboradorDocumentacaoResult.UFEmissaoRIC = colaboradorDocumentacao.UFEmissaoRIC;
                        colaboradorDocumentacaoResult.CidadeEmissaoRIC = colaboradorDocumentacao.CidadeEmissaoRIC;
                        colaboradorDocumentacaoResult.OrgaoEmissorRIC = colaboradorDocumentacao.OrgaoEmissorRIC;
                        colaboradorDocumentacaoResult.DataExpedicaoRIC = colaboradorDocumentacao.DataExpedicaoRIC;
                        colaboradorDocumentacaoResult.CartaoNacionalSaude = colaboradorDocumentacao.CartaoNacionalSaude;
                        colaboradorDocumentacaoResult.NumeroReservista = colaboradorDocumentacao.NumeroReservista;
                        colaboradorDocumentacaoResult.TituloEleitor = colaboradorDocumentacao.TituloEleitor;
                        colaboradorDocumentacaoResult.ZonaEleitoral = colaboradorDocumentacao.ZonaEleitoral;
                        colaboradorDocumentacaoResult.UFEleitoral = colaboradorDocumentacao.UFEleitoral;
                        colaboradorDocumentacaoResult.CidadeEleitoral = colaboradorDocumentacao.CidadeEleitoral;
                        colaboradorDocumentacaoResult.CarteiraHabilitacao = colaboradorDocumentacao.CarteiraHabilitacao;
                        colaboradorDocumentacaoResult.CategoriaHabilitacao = colaboradorDocumentacao.CategoriaHabilitacao;
                        colaboradorDocumentacaoResult.DataVencimentoHabilitacao = colaboradorDocumentacao.DataVencimentoHabilitacao;
                        colaboradorDocumentacaoResult.NumeroCTPS = colaboradorDocumentacao.NumeroCTPS;
                        colaboradorDocumentacaoResult.SerieCTPS = colaboradorDocumentacao.SerieCTPS;
                        colaboradorDocumentacaoResult.UFCTPS = colaboradorDocumentacao.UFCTPS;
                        colaboradorDocumentacaoResult.DataEmissaoCTPS = colaboradorDocumentacao.DataEmissaoCTPS;
                        colaboradorDocumentacaoResult.PISNITNIS = colaboradorDocumentacao.PISNITNIS;
                        colaboradorDocumentacaoResult.DataEmissaoPISNITNIS = colaboradorDocumentacao.DataEmissaoPISNITNIS;

                        _unitOfWork.Commit();

                        result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaoEditarById(colaboradorDocumentacaoResult.Id);
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

        public void AlteracaoCadastralColaboradorDocumentacao(AlteracaoCadastralModel alteracaoCadastral)
        {

            try
            {
                var colaboradorDocumentacaoResult = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaobyColaboradorId(alteracaoCadastral.ColaboradorId);

                if (colaboradorDocumentacaoResult != null)
                {
                    colaboradorDocumentacaoResult.CategoriaHabilitacao = alteracaoCadastral.CategoriaHabilitacao;
                    colaboradorDocumentacaoResult.DataVencimentoHabilitacao = alteracaoCadastral.DataVencimentoHabilitacao;
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

        private ErrorModel ValidacaoEntrada(ColaboradorDocumentacaoModel colaboradorDocumentacao)
        {
            var erroModel = new ErrorModel();

            if (colaboradorDocumentacao.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Colaborador";
            }
            else if (string.IsNullOrEmpty(colaboradorDocumentacao.RG))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o RG";
            }
            else
            {
                var result = _repoCustomColaboradorDocumentacao.GetColaboradorDocumentacaoValidation(colaboradorDocumentacao);
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
