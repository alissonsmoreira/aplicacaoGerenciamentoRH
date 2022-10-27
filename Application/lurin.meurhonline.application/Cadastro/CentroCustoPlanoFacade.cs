using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class CentroCustoPlanoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultCentroCustoPlano;
        private static dynamic _repoDefaultCentroCustoPlanoUnidade;

        private static dynamic _repoCustomCentroCustoPlano;
        private static dynamic _repoCustomCentroCustoPlanoUnidade;

        public CentroCustoPlanoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCentroCustoPlano = RepositoryFactory.CreateRepository<CentroCustoPlanoModel, Repository<CentroCustoPlanoModel>>(_unitOfWork);
            _repoDefaultCentroCustoPlanoUnidade = RepositoryFactory.CreateRepository<CentroCustoPlanoUnidadeModel, Repository<CentroCustoPlanoUnidadeModel>>(_unitOfWork);
            _repoCustomCentroCustoPlano = RepositoryFactory.CreateRepositoryCustom<CentroCustoPlanoModel, CentroCustoPlanoRepository>(_unitOfWork);
            _repoCustomCentroCustoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<CentroCustoPlanoUnidadeModel, CentroCustoPlanoUnidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            try
            {
                var result = _repoCustomCentroCustoPlano.GetCentroCustoPlano(centroCustoPlano);

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

        public dynamic AdicionarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(centroCustoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    centroCustoPlano.DataCadastro = DateTime.Now;
                    _repoDefaultCentroCustoPlano.Add(centroCustoPlano);
                    _unitOfWork.Commit();

                    var result = _repoCustomCentroCustoPlano.GetCentroCustoPlanobyId(centroCustoPlano.Id);

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

        public dynamic AdicionarCentroCustoPlanoUnidade(IEnumerable<CentroCustoPlanoUnidadeModel> centroCustoPlanoUnidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaCentroCustoPlanoUnidade(centroCustoPlanoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<CentroCustoPlanoUnidadeModel> resultDelete = _repoCustomCentroCustoPlanoUnidade.GetCentroCustoPlanoUnidadeByCentroCustoPlanoId(centroCustoPlanoUnidade.FirstOrDefault().CentroCustoPlanoId);
                    if (resultDelete.Count > 0)
                    {
                        _repoDefaultCentroCustoPlanoUnidade.Delete(resultDelete);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultCentroCustoPlanoUnidade.Add(centroCustoPlanoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomCentroCustoPlanoUnidade.GetCentroCustoPlanoUnidadeByCentroCustoPlanoId(centroCustoPlanoUnidade.FirstOrDefault().CentroCustoPlanoId);

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

        public dynamic EditarCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(centroCustoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    var CentroCustoPlanoResult = _repoCustomCentroCustoPlano.GetCentroCustoPlanobyId(centroCustoPlano.Id);

                    if (CentroCustoPlanoResult != null)
                    {
                        CentroCustoPlanoResult.Codigo = centroCustoPlano.Codigo;
                        CentroCustoPlanoResult.Nome = centroCustoPlano.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomCentroCustoPlano.GetCentroCustoPlanobyId(CentroCustoPlanoResult.Id);
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

        public dynamic ExcluirCentroCustoPlano(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCentroCustoPlano.GetCentroCustoPlanobyId(id);

                if (result != null)
                {
                    _repoDefaultCentroCustoPlano.Delete(result);
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

        private ErrorModel ValidacaoEntrada(CentroCustoPlanoModel centroCustoPlano)
        {
            var erroModel = new ErrorModel();

            if (centroCustoPlano.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(centroCustoPlano.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomCentroCustoPlano.GetCentroCustoPlanoValidation(centroCustoPlano);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoEntradaCentroCustoPlanoUnidade(IEnumerable<CentroCustoPlanoUnidadeModel> centroCustoPlanoUnidade)
        {
            var erroModel = new ErrorModel();

            foreach (var centroCusto in centroCustoPlanoUnidade)
            {
                if (centroCusto.CentroCustoPlanoId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe o Centro de Custo Plano";
                    break;
                }
                else if (centroCusto.CentroCustoUnidadeId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe o Centro de Custo Unidade";
                    break;
                }
            }

            return erroModel;
        }
    }
}
