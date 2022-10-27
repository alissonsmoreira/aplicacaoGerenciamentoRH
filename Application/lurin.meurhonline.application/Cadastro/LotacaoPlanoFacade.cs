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
    public class LotacaoPlanoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultLotacaoPlano;
        private static dynamic _repoDefaultLotacaoPlanoUnidade;

        private static dynamic _repoCustomLotacaoPlano;
        private static dynamic _repoCustomLotacaoPlanoUnidade;

        public LotacaoPlanoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultLotacaoPlano = RepositoryFactory.CreateRepository<LotacaoPlanoModel, Repository<LotacaoPlanoModel>>(_unitOfWork);
            _repoDefaultLotacaoPlanoUnidade = RepositoryFactory.CreateRepository<LotacaoPlanoUnidadeModel, Repository<LotacaoPlanoUnidadeModel>>(_unitOfWork);
            _repoCustomLotacaoPlano = RepositoryFactory.CreateRepositoryCustom<LotacaoPlanoModel, LotacaoPlanoRepository>(_unitOfWork);
            _repoCustomLotacaoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<LotacaoPlanoUnidadeModel, LotacaoPlanoUnidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            try
            {
                var result = _repoCustomLotacaoPlano.GetLotacaoPlano(lotacaoPlano);

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

        public dynamic AdicionarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(lotacaoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    lotacaoPlano.DataCadastro = DateTime.Now;
                    _repoDefaultLotacaoPlano.Add(lotacaoPlano);
                    _unitOfWork.Commit();

                    var result = _repoCustomLotacaoPlano.GetLotacaoPlanobyId(lotacaoPlano.Id);

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

        public dynamic AdicionarLotacaoPlanoUnidade(IEnumerable<LotacaoPlanoUnidadeModel> lotacaoPlanoUnidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaLotacaoPlanoUnidade(lotacaoPlanoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<LotacaoPlanoUnidadeModel> resultDelete = _repoCustomLotacaoPlanoUnidade.GetLotacaoPlanoUnidadeByLotacaoPlanoId(lotacaoPlanoUnidade.FirstOrDefault().LotacaoPlanoId);
                    if (resultDelete.Count > 0)
                    {
                        _repoDefaultLotacaoPlanoUnidade.Delete(resultDelete);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultLotacaoPlanoUnidade.Add(lotacaoPlanoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomLotacaoPlanoUnidade.GetLotacaoPlanoUnidadeByLotacaoPlanoId(lotacaoPlanoUnidade.FirstOrDefault().LotacaoPlanoId);

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

        public dynamic EditarLotacaoPlano(LotacaoPlanoModel lotacaoPlano)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(lotacaoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    var LotacaoPlanoResult = _repoCustomLotacaoPlano.GetLotacaoPlanobyId(lotacaoPlano.Id);

                    if (LotacaoPlanoResult != null)
                    {
                        LotacaoPlanoResult.Codigo = lotacaoPlano.Codigo;
                        LotacaoPlanoResult.Nome = lotacaoPlano.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomLotacaoPlano.GetLotacaoPlanobyId(LotacaoPlanoResult.Id);
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

        public dynamic ExcluirLotacaoPlano(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomLotacaoPlano.GetLotacaoPlanobyId(id);

                if (result != null)
                {
                    _repoDefaultLotacaoPlano.Delete(result);
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

        private ErrorModel ValidacaoEntrada(LotacaoPlanoModel lotacaoPlano)
        {
            var erroModel = new ErrorModel();

            if (lotacaoPlano.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(lotacaoPlano.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomLotacaoPlano.GetLotacaoPlanoValidation(lotacaoPlano);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoEntradaLotacaoPlanoUnidade(IEnumerable<LotacaoPlanoUnidadeModel> lotacaoPlanoUnidade)
        {
            var erroModel = new ErrorModel();

            foreach (var lotacao in lotacaoPlanoUnidade)
            {
                if (lotacao.LotacaoPlanoId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe a Lotacao Plano";
                }
                else if (lotacao.LotacaoUnidadeId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe a Lotacao Unidade";
                }
               
            }

            return erroModel;
        }
    }
}
