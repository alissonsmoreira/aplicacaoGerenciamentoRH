using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.cache;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;

namespace lurin.meurhonline.application
{
    public class BeneficioFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;        
        private static dynamic _repoDefaultBeneficio;
        private static dynamic _repoDefaultBeneficioTipo;

        private static dynamic _repoCustomBeneficio;        

        public BeneficioFacade()
        {
            _unitOfWork = new UnitOfWork();            

            _repoDefaultBeneficio = RepositoryFactory.CreateRepository<BeneficioModel, Repository<BeneficioModel>>(_unitOfWork);
            _repoDefaultBeneficioTipo = RepositoryFactory.CreateRepository<BeneficioTipoModel, Repository<BeneficioTipoModel>>(_unitOfWork);

            _repoCustomBeneficio = RepositoryFactory.CreateRepositoryCustom<BeneficioModel, BeneficioRepository>(_unitOfWork);            
        }

        public dynamic BuscarBeneficio(BeneficioModel beneficio)
        {
            try
            {                
                var result = _repoCustomBeneficio.GetBeneficio(beneficio);              

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

        public dynamic BuscarTudoBeneficio()
        {
            try
            {
                var result = _repoCustomBeneficio.GetAllBeneficio();

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

        public dynamic BuscarBeneficioTipo()
        {
            try
            {                
                var result = Cache.Get<List<BeneficioTipoModel>>("BeneficioTipo");
                if (result == null)
                { 
                    result = _repoDefaultBeneficioTipo.GetAll();

                    Cache.AddItem("BeneficioTipo", result, 1);
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

        public dynamic AdicionarBeneficio(BeneficioModel beneficio)
        {
            var result = new BeneficioModel();

            try
            {
                result = ValidacaoEntrada(beneficio);
                if (result.Erro.Codigo == 0)
                {
                    beneficio.DataCadastro = DateTime.Now;
                    _repoDefaultBeneficio.Add(beneficio);
                    _unitOfWork.Commit();

                    result = _repoCustomBeneficio.GetBeneficiobyId(beneficio.Id);                                       
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

        public dynamic EditarBeneficio(BeneficioModel beneficio)
        {
            var result = new BeneficioModel();

            try
            {
                result = ValidacaoEntrada(beneficio);
                if (result.Erro.Codigo == 0)
                {
                    var beneficioResult = _repoCustomBeneficio.GetBeneficiobyId(beneficio.Id);
                    if (beneficioResult != null)
                    {
                        beneficioResult.Nome = beneficio.Nome;
                        beneficioResult.RegraDesconto = beneficio.RegraDesconto;
                        beneficioResult.CustoBeneficio = beneficio.CustoBeneficio;
                        beneficioResult.BeneficioTipoId = beneficio.BeneficioTipoId;

                        _unitOfWork.Commit();

                        result = _repoCustomBeneficio.GetBeneficiobyId(beneficioResult.Id);
                    }
                    else
                    {
                        result.Erro = new ErrorModel();
                        result.Erro.Codigo = 600;
                        result.Erro.Descricao = "Registro não encontrado";
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

        public dynamic ExcluirBeneficio(int id)
        {
            var result = new BeneficioModel();

            try
            {
                result = _repoCustomBeneficio.GetBeneficiobyId(id);
                if (result != null)
                {
                    _repoDefaultBeneficio.Delete(result);
                    _unitOfWork.Commit();
                }
                else
                {
                    result = new BeneficioModel();
                    result.Erro = new ErrorModel();
                    result.Erro.Codigo = 600;
                    result.Erro.Descricao = "Registro não encontrado";
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

        private BeneficioModel ValidacaoEntrada(BeneficioModel beneficio)
        {
            beneficio.Erro = new ErrorModel();

            if (string.IsNullOrEmpty(beneficio.Nome))
            {
                beneficio.Erro.Codigo = 600;
                beneficio.Erro.Descricao = "Informe o Nome";
            }
            else if (string.IsNullOrEmpty(beneficio.RegraDesconto))
            {
                beneficio.Erro.Codigo = 600;
                beneficio.Erro.Descricao = "Informe a Regra de Desconto";                
            }
            else if (beneficio.BeneficioTipoId == 0)
            {
                beneficio.Erro.Codigo = 600;
                beneficio.Erro.Descricao = "Selecione o Tipo";
            }                
            else if (beneficio.CustoBeneficio == 0)
            {
                beneficio.Erro.Codigo = 600;
                beneficio.Erro.Descricao = "Informe o Custo";
            }
            else
            {
                var resultValidation = _repoCustomBeneficio.GetBeneficioValidation(beneficio);
                if (resultValidation != null)
                {
                    beneficio = resultValidation;
                    beneficio.Erro = new ErrorModel();
                    beneficio.Erro.Codigo = 600;
                    beneficio.Erro.Descricao = "Registro já cadastrado";
                }
            }            

            return beneficio;
        }
    }
}
