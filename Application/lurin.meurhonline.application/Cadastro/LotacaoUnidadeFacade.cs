using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class LotacaoUnidadeFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultLotacaoUnidade;
        private static dynamic _repoCustomLotacaoUnidade;
        private static dynamic _repoCustomLotacaoPlanoUnidade;
        private static dynamic _repoCustomEmpresa;

        public LotacaoUnidadeFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultLotacaoUnidade = RepositoryFactory.CreateRepository<LotacaoUnidadeModel, Repository<LotacaoUnidadeModel>>(_unitOfWork);
            _repoCustomLotacaoUnidade = RepositoryFactory.CreateRepositoryCustom<LotacaoUnidadeModel, LotacaoUnidadeRepository>(_unitOfWork);
            _repoCustomLotacaoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<LotacaoPlanoUnidadeModel, LotacaoPlanoUnidadeRepository>(_unitOfWork);
            _repoCustomEmpresa = RepositoryFactory.CreateRepositoryCustom<EmpresaModel, EmpresaRepository>(_unitOfWork);
        }

        public dynamic BuscarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            try
            {
                var result = _repoCustomLotacaoUnidade.GetLotacaoUnidade(lotacaoUnidade);

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

        public dynamic BuscarLotacaoUnidadePorId(int id)
        {
            try
            {
                var result = _repoCustomLotacaoUnidade.GetLotacaoUnidadebyId(id);

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

        public dynamic BuscarTudoLotacaoUnidade()
        {
            try
            {
                var result = _repoDefaultLotacaoUnidade.GetAll();

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

        public dynamic BuscarLotacaoUnidadePorIdEmpresa(int id)
        {
            try
            {
                dynamic result;
                var empresaMatrizId = 0;

                var resultEmpresa = _repoCustomEmpresa.GetEmpresabyId(id);

                if (resultEmpresa != null)
                {
                    if (resultEmpresa.EmpresaTipo.Nome == "Matriz")
                        empresaMatrizId = resultEmpresa.Id;
                    else
                        empresaMatrizId = resultEmpresa.EmpresaMatrizId;

                    var empresaGrupo = _repoCustomEmpresa.GetEmpresaGrupoByEmpresaMatrizId(empresaMatrizId);

                    result = new List<LotacaoUnidadeModel>();

                    foreach (var resultEmpFor in empresaGrupo)
                    {
                        var resultRepo = _repoCustomLotacaoPlanoUnidade.GetLotacaoUnidadeByEmpresaId(resultEmpFor.Id);
                        foreach (var resultFor in resultRepo)
                        {
                            result.Add(resultFor.LotacaoUnidade);
                        }
                    }
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

        public dynamic AdicionarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(lotacaoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    lotacaoUnidade.DataCadastro = DateTime.Now;
                    _repoDefaultLotacaoUnidade.Add(lotacaoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomLotacaoUnidade.GetLotacaoUnidadebyId(lotacaoUnidade.Id);

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

        public dynamic EditarLotacaoUnidade(LotacaoUnidadeModel lotacaoUnidade)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(lotacaoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    var LotacaoUnidadeResult = _repoCustomLotacaoUnidade.GetLotacaoUnidadebyId(lotacaoUnidade.Id);

                    if (LotacaoUnidadeResult != null)
                    {
                        LotacaoUnidadeResult.Codigo = lotacaoUnidade.Codigo;
                        LotacaoUnidadeResult.Nome = lotacaoUnidade.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomLotacaoUnidade.GetLotacaoUnidadebyId(LotacaoUnidadeResult.Id);
                    }
                    else
                    {
                        result = "Registro não encontrado";
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

        public dynamic ExcluirLotacaoUnidade(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomLotacaoUnidade.GetLotacaoUnidadebyId(id);

                if (result != null)
                {
                    _repoDefaultLotacaoUnidade.Delete(result);
                    _unitOfWork.Commit();
                }
                else
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

        private ErrorModel ValidacaoEntrada(LotacaoUnidadeModel lotacaoUnidade)
        {
            var erroModel = new ErrorModel();

            if (lotacaoUnidade.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(lotacaoUnidade.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomLotacaoUnidade.GetLotacaoUnidadeValidation(lotacaoUnidade);
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
