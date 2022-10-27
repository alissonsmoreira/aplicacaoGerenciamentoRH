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
    public class CargoPlanoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultCargoPlano;
        private static dynamic _repoDefaultCargoPlanoUnidade;

        private static dynamic _repoCustomCargoPlano;
        private static dynamic _repoCustomCargoPlanoUnidade;

        public CargoPlanoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCargoPlano = RepositoryFactory.CreateRepository<CargoPlanoModel, Repository<CargoPlanoModel>>(_unitOfWork);
            _repoDefaultCargoPlanoUnidade = RepositoryFactory.CreateRepository<CargoPlanoUnidadeModel, Repository<CargoPlanoUnidadeModel>>(_unitOfWork);
            _repoCustomCargoPlano = RepositoryFactory.CreateRepositoryCustom<CargoPlanoModel, CargoPlanoRepository>(_unitOfWork);
            _repoCustomCargoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<CargoPlanoUnidadeModel, CargoPlanoUnidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarCargoPlano(CargoPlanoModel cargoPlano)
        {
            try
            {
                var result = _repoCustomCargoPlano.GetCargoPlano(cargoPlano);

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

        public dynamic AdicionarCargoPlano(CargoPlanoModel cargoPlano)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(cargoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    cargoPlano.DataCadastro = DateTime.Now;
                    _repoDefaultCargoPlano.Add(cargoPlano);
                    _unitOfWork.Commit();

                    var result = _repoCustomCargoPlano.GetCargoPlanobyId(cargoPlano.Id);

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

        public dynamic AdicionarCargoPlanoUnidade(IEnumerable<CargoPlanoUnidadeModel> cargoPlanoUnidade)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntradaCargoPlanoUnidade(cargoPlanoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    List<CargoPlanoUnidadeModel> resultDelete = _repoCustomCargoPlanoUnidade.GetCargoPlanoUnidadeByCargoPlanoId(cargoPlanoUnidade.FirstOrDefault().CargoPlanoId);
                    if (resultDelete.Count > 0)
                    {
                        _repoDefaultCargoPlanoUnidade.Delete(resultDelete);
                        _unitOfWork.Commit();
                    }

                    _repoDefaultCargoPlanoUnidade.Add(cargoPlanoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomCargoPlanoUnidade.GetCargoPlanoUnidadeByCargoPlanoId(cargoPlanoUnidade.FirstOrDefault().CargoPlanoId);

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

        public dynamic EditarCargoPlano(CargoPlanoModel cargoPlano)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(cargoPlano);
                if (validacaoEntrada.Codigo == 0)
                {
                    var CargoPlanoResult = _repoCustomCargoPlano.GetCargoPlanobyId(cargoPlano.Id);

                    if (CargoPlanoResult != null)
                    {
                        CargoPlanoResult.Codigo = cargoPlano.Codigo;
                        CargoPlanoResult.Nome = cargoPlano.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomCargoPlano.GetCargoPlanobyId(CargoPlanoResult.Id);
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

        public dynamic ExcluirCargoPlano(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCargoPlano.GetCargoPlanobyId(id);

                if (result != null)
                {
                    _repoDefaultCargoPlano.Delete(result);
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

        private ErrorModel ValidacaoEntrada(CargoPlanoModel cargoPlano)
        {
            var erroModel = new ErrorModel();

            if (cargoPlano.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(cargoPlano.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomCargoPlano.GetCargoPlanoValidation(cargoPlano);
                if (result != null)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Registro já cadastrado";
                }
            }

            return erroModel;
        }

        private ErrorModel ValidacaoEntradaCargoPlanoUnidade(IEnumerable<CargoPlanoUnidadeModel> cargoPlanoUnidade)
        {
            var erroModel = new ErrorModel();

            foreach (var cargo in cargoPlanoUnidade)
            {
                if (cargo.CargoPlanoId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe o Cargo Plano";
                    break;
                }
                else if (cargo.CargoUnidadeId == 0)
                {
                    erroModel.Codigo = 600;
                    erroModel.Descricao = "Informe o Cargo Unidade";
                    break;
                }
            }

            return erroModel;
        }
    }
}
