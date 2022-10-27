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
    public class CentroCustoUnidadeFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultCentroCustoUnidade;
        private static dynamic _repoCustomCentroCustoUnidade;
        private static dynamic _repoCustomCentroCustoPlanoUnidade;

        public CentroCustoUnidadeFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCentroCustoUnidade = RepositoryFactory.CreateRepository<CentroCustoUnidadeModel, Repository<CentroCustoUnidadeModel>>(_unitOfWork);
            _repoCustomCentroCustoUnidade = RepositoryFactory.CreateRepositoryCustom<CentroCustoUnidadeModel, CentroCustoUnidadeRepository>(_unitOfWork);
            _repoCustomCentroCustoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<CentroCustoPlanoUnidadeModel, CentroCustoPlanoUnidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            try
            {
                var result = _repoCustomCentroCustoUnidade.GetCentroCustoUnidade(centroCustoUnidade);

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

        public dynamic BuscarTudoCentroCustoUnidade()
        {
            try
            {
                var result = _repoDefaultCentroCustoUnidade.GetAll();

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

        public dynamic BuscarCentroCustoUnidadePorIdEmpresa(int id)
        {
            try
            {
                var result = new List<CentroCustoUnidadeModel>();
                var resultRepo = _repoCustomCentroCustoPlanoUnidade.GetCentroCustoUnidadeByEmpresaId(id);
                foreach (var resultFor in resultRepo)
                {
                    result.Add(resultFor.CentroCustoUnidade);
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

        public dynamic AdicionarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(centroCustoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    centroCustoUnidade.DataCadastro = DateTime.Now;
                    _repoDefaultCentroCustoUnidade.Add(centroCustoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomCentroCustoUnidade.GetCentroCustoUnidadebyId(centroCustoUnidade.Id);

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

        public dynamic EditarCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(centroCustoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    var centroCustoResult = _repoCustomCentroCustoUnidade.GetCentroCustoUnidadebyId(centroCustoUnidade.Id);

                    if (centroCustoResult != null)
                    {
                        centroCustoResult.Codigo = centroCustoUnidade.Codigo;
                        centroCustoResult.Nome = centroCustoUnidade.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomCentroCustoUnidade.GetCentroCustoUnidadebyId(centroCustoResult.Id);
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

        public dynamic ExcluirCentroCustoUnidade(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCentroCustoUnidade.GetCentroCustoUnidadebyId(id);

                if (result != null)
                {
                    _repoDefaultCentroCustoUnidade.Delete(result);
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
        private ErrorModel ValidacaoEntrada(CentroCustoUnidadeModel centroCustoUnidade)
        {
            var erroModel = new ErrorModel();

            if (centroCustoUnidade.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(centroCustoUnidade.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomCentroCustoUnidade.GetCentroCustoUnidadeValidation(centroCustoUnidade);
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
