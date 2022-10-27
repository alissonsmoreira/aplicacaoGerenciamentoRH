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
    public class CargoUnidadeFacade
    {    
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultCargoUnidade;
        private static dynamic _repoCustomCargoUnidade;
        private static dynamic _repoCustomCargoPlanoUnidade;

        public CargoUnidadeFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCargoUnidade = RepositoryFactory.CreateRepository<CargoUnidadeModel, Repository<CargoUnidadeModel>>(_unitOfWork);
            _repoCustomCargoUnidade = RepositoryFactory.CreateRepositoryCustom<CargoUnidadeModel, CargoUnidadeRepository>(_unitOfWork);
            _repoCustomCargoPlanoUnidade = RepositoryFactory.CreateRepositoryCustom<CargoPlanoUnidadeModel, CargoPlanoUnidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            try
            {
                var result = _repoCustomCargoUnidade.GetCargoUnidade(cargoUnidade);

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

        public dynamic BuscarTudoCargoUnidade()
        {
            try
            {
                var result = _repoDefaultCargoUnidade.GetAll();

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

        public dynamic BuscarCargoUnidadePorIdEmpresa(int id)
        {
            try
            {
                var result = new List<CargoUnidadeModel>();
                var resultRepo = _repoCustomCargoPlanoUnidade.GetCargoUnidadeByEmpresaId(id);
                foreach (var resultFor in resultRepo)
                {
                    result.Add(resultFor.CargoUnidade);
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

        public dynamic AdicionarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {            
            try
            {
                var validacaoEntrada = ValidacaoEntrada(cargoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    cargoUnidade.DataCadastro = DateTime.Now;
                    _repoDefaultCargoUnidade.Add(cargoUnidade);
                    _unitOfWork.Commit();

                    var result = _repoCustomCargoUnidade.GetCargoUnidadebyId(cargoUnidade.Id);

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

        public dynamic EditarCargoUnidade(CargoUnidadeModel cargoUnidade)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(cargoUnidade);
                if (validacaoEntrada.Codigo == 0)
                {
                    var cargoUnidadeResult = _repoCustomCargoUnidade.GetCargoUnidadebyId(cargoUnidade.Id);

                    if (cargoUnidadeResult != null)
                    {
                        cargoUnidadeResult.Codigo = cargoUnidade.Codigo;
                        cargoUnidadeResult.Nome = cargoUnidade.Nome;

                        _unitOfWork.Commit();

                        result = _repoCustomCargoUnidade.GetCargoUnidadebyId(cargoUnidadeResult.Id);
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

        public dynamic ExcluirCargoUnidade(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomCargoUnidade.GetCargoUnidadebyId(id);

                if (result != null)
                {
                    _repoDefaultCargoUnidade.Delete(result);
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

        private ErrorModel ValidacaoEntrada(CargoUnidadeModel cargoUnidade)
        {
            var erroModel = new ErrorModel();

            if (cargoUnidade.Codigo == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Código da Unidade";
            }
            else if (string.IsNullOrEmpty(cargoUnidade.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Unidade";
            }
            else
            {
                var result = _repoCustomCargoUnidade.GetCargoUnidadeValidation(cargoUnidade);
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
