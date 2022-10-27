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
    public class EquipeGestorFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        private static dynamic _repoDefaultEquipeGestor;
        private static dynamic _repoCustomEquipeGestor;

        public EquipeGestorFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultEquipeGestor = RepositoryFactory.CreateRepository<EquipeGestorModel, Repository<EquipeGestorModel>>(_unitOfWork);
            _repoCustomEquipeGestor = RepositoryFactory.CreateRepositoryCustom<EquipeGestorModel, EquipeGestorRepository>(_unitOfWork);
            
        }

        public dynamic BuscarEquipeGestor(EquipeGestorModel equipeGestor)
        {
            try
            {
                List<EquipeGestorModel> result = new List<EquipeGestorModel>();
                var resultRepo = _repoCustomEquipeGestor.GetEquipeGestor(equipeGestor);

                foreach(var resultFor in resultRepo)
                {
                    LotacaoUnidadeFacade lotacaoInicial = new LotacaoUnidadeFacade();
                    resultFor.LotacaoUnidadeInicial = lotacaoInicial.BuscarLotacaoUnidadePorId(resultFor.LotacaoUnidadeInicialId);

                    LotacaoUnidadeFacade lotacaoFinal = new LotacaoUnidadeFacade();
                    resultFor.LotacaoUnidadeFinal = lotacaoFinal.BuscarLotacaoUnidadePorId(resultFor.LotacaoUnidadeFinalId);
                    result.Add(resultFor);
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

        public dynamic BuscarEquipeGestorPorGestorId(int id)
        {
            try
            {
                List<EquipeGestorModel> result = new List<EquipeGestorModel>();
                var resultRepo = _repoCustomEquipeGestor.GetEquipeGestorByGestorId(id);

                foreach (var resultFor in resultRepo)
                {
                    LotacaoUnidadeFacade lotacaoInicial = new LotacaoUnidadeFacade();
                    resultFor.LotacaoUnidadeInicial = lotacaoInicial.BuscarLotacaoUnidadePorId(resultFor.LotacaoUnidadeInicialId);

                    LotacaoUnidadeFacade lotacaoFinal = new LotacaoUnidadeFacade();
                    resultFor.LotacaoUnidadeFinal = lotacaoFinal.BuscarLotacaoUnidadePorId(resultFor.LotacaoUnidadeFinalId);
                    result.Add(resultFor);
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

        public dynamic AdicionarEquipeGestor(EquipeGestorModel equipeGestor)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(equipeGestor);
                if (validacaoEntrada.Codigo == 0)
                {
                    equipeGestor.DataCadastro = DateTime.Now;
                    _repoDefaultEquipeGestor.Add(equipeGestor);
                    _unitOfWork.Commit();

                    var result = _repoCustomEquipeGestor.GetEquipeGestorbyId(equipeGestor.Id);
                    if (result != null)
                    {
                        LotacaoUnidadeFacade lotacaoInicial = new LotacaoUnidadeFacade();
                        result.LotacaoUnidadeInicial = lotacaoInicial.BuscarLotacaoUnidadePorId(result.LotacaoUnidadeInicialId);

                        LotacaoUnidadeFacade lotacaoFinal = new LotacaoUnidadeFacade();
                        result.LotacaoUnidadeFinal = lotacaoInicial.BuscarLotacaoUnidadePorId(result.LotacaoUnidadeFinalId);
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

        public dynamic ExcluirEquipeGestor(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomEquipeGestor.GetEquipeGestorbyId(id);

                if (result != null)
                {
                    _repoDefaultEquipeGestor.Delete(result);
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

        private ErrorModel ValidacaoEntrada(EquipeGestorModel equipeGestor)
        {
            var erroModel = new ErrorModel();

            if (equipeGestor.ColaboradorId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Colaborador";
            }
            else if (equipeGestor.LotacaoUnidadeInicialId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Código Inicial";
            }
            else if (equipeGestor.LotacaoUnidadeFinalId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Código Final";
            }
            else
            {
                var result = _repoCustomEquipeGestor.GetEquipeGestorValidation(equipeGestor);
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
