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
    public class ColaboradorEstrangeiroFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultColaboradorEstrangeiro;
        private static dynamic _repoDefaultColaboradorEstrangeiroTipoVisto;

        private static dynamic _repoCustomColaboradorDadoPrincipal;

        private static dynamic _repoCustomColaboradorEstrangeiro;

        public ColaboradorEstrangeiroFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultColaboradorEstrangeiro = RepositoryFactory.CreateRepository<ColaboradorEstrangeiroModel, Repository<ColaboradorEstrangeiroModel>>(_unitOfWork);
            _repoDefaultColaboradorEstrangeiroTipoVisto = RepositoryFactory.CreateRepository<ColaboradorEstrangeiroTipoVistoModel, Repository<ColaboradorEstrangeiroTipoVistoModel>>(_unitOfWork);

            _repoCustomColaboradorEstrangeiro = RepositoryFactory.CreateRepositoryCustom<ColaboradorEstrangeiroModel, ColaboradorEstrangeiroRepository>(_unitOfWork);

            _repoCustomColaboradorDadoPrincipal = RepositoryFactory.CreateRepositoryCustom<ColaboradorModel, ColaboradorRepository>(_unitOfWork);

        }

        public dynamic BuscarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            try
            {
                var result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiro(colaboradorEstrangeiro);
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

        public dynamic BuscarEstrangeiroColaboradorPreAdmissao(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            try
            {
                var result = _repoCustomColaboradorEstrangeiro.GetColaboradorPreAdmissaoEstrangeiro(colaboradorEstrangeiro);
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

        public dynamic BuscarEstrangeiroColaboradorPreAdmissaoPorId(int id)
        {
            try
            {
                var result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiroPreAdmissaobyId(id);
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

        public dynamic BuscarTudoEstrangeiroColaboradorTipoVisto()
        {
            try
            {
                var result = _repoDefaultColaboradorEstrangeiroTipoVisto.GetAll();
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

        public dynamic AdicionarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorEstrangeiro);
                if (validacaoEntrada.Codigo == 0)
                {
                    colaboradorEstrangeiro.DataCadastro = DateTime.Now;
                    _repoDefaultColaboradorEstrangeiro.Add(colaboradorEstrangeiro);
                    _unitOfWork.Commit();

                    ColaboradorEstrangeiroModel result;
                    ColaboradorModel colaborador;

                    colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorbyId(colaboradorEstrangeiro.ColaboradorId);

                    if (colaborador == null)
                    {
                        colaborador = _repoCustomColaboradorDadoPrincipal.GetColaboradorPreAdmissaobyId(colaboradorEstrangeiro.ColaboradorId);
                        result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiroPreAdmissaobyId(colaboradorEstrangeiro.ColaboradorId);
                    }
                    else
                    {
                        result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeirobyId(colaboradorEstrangeiro.ColaboradorId);
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

        public dynamic EditarEstrangeiroColaborador(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(colaboradorEstrangeiro);
                if (validacaoEntrada.Codigo == 0)
                {
                    var colaboradorEstrangeiroResult = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiroEditarById(colaboradorEstrangeiro.Id);

                    if (colaboradorEstrangeiroResult != null)
                    {
                        colaboradorEstrangeiroResult.ColaboradorId = colaboradorEstrangeiro.ColaboradorId;
                        colaboradorEstrangeiroResult.Origem = colaboradorEstrangeiro.Origem;
                        colaboradorEstrangeiroResult.ColaboradorEstrangeiroTipoVistoId = colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId;
                        colaboradorEstrangeiroResult.Passaporte = colaboradorEstrangeiro.Passaporte;
                        colaboradorEstrangeiroResult.OrgaoEmissorPassaporte = colaboradorEstrangeiro.OrgaoEmissorPassaporte;
                        colaboradorEstrangeiroResult.PaisEmissorPassaporte = colaboradorEstrangeiro.PaisEmissorPassaporte;
                        colaboradorEstrangeiroResult.UFPassaporte = colaboradorEstrangeiro.UFPassaporte;
                        colaboradorEstrangeiroResult.DataEmissaoPassaporte = colaboradorEstrangeiro.DataEmissaoPassaporte;
                        colaboradorEstrangeiroResult.PortariaNaturalizacao = colaboradorEstrangeiro.PortariaNaturalizacao;
                        colaboradorEstrangeiroResult.IdentidadeEstrangeira = colaboradorEstrangeiro.IdentidadeEstrangeira;
                        colaboradorEstrangeiroResult.ValidadeIdentidadeEstrangeira = colaboradorEstrangeiro.ValidadeIdentidadeEstrangeira;
                        colaboradorEstrangeiroResult.AnoChegada = colaboradorEstrangeiro.AnoChegada;

                        _unitOfWork.Commit();

                        result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiroEditarById(colaboradorEstrangeiroResult.Id);
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



        private ErrorModel ValidacaoEntrada(ColaboradorEstrangeiroModel colaboradorEstrangeiro)
        {
            var erroModel = new ErrorModel();

            if (colaboradorEstrangeiro.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome do Colaborador";
            }
            else if (string.IsNullOrEmpty(colaboradorEstrangeiro.Origem))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe a Origem";
            }
            else if (colaboradorEstrangeiro.ColaboradorEstrangeiroTipoVistoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Tipo de Visto";
            }
            else if (string.IsNullOrEmpty(colaboradorEstrangeiro.Passaporte))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Passaporte";
            }
            else
            {
                var result = _repoCustomColaboradorEstrangeiro.GetColaboradorEstrangeiroValidation(colaboradorEstrangeiro);
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
