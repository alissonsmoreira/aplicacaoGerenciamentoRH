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
    public class OperadoraVTFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;
        
        private static dynamic _repoDefaultOperadoraVT;
        private static dynamic _repoDefaultOperadoraVTBandeiraCartao;
        private static dynamic _repoDefaultOperadoraVTTarifaTipo;

        private static dynamic _repoCustomOperadoraVT;

        public OperadoraVTFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultOperadoraVT = RepositoryFactory.CreateRepository<OperadoraVTModel, Repository<OperadoraVTModel>>(_unitOfWork);
            _repoDefaultOperadoraVTBandeiraCartao = RepositoryFactory.CreateRepository<OperadoraVTBandeiraCartaoModel, Repository<OperadoraVTBandeiraCartaoModel>>(_unitOfWork);
            _repoDefaultOperadoraVTTarifaTipo = RepositoryFactory.CreateRepository<OperadoraVTTarifaTipoModel, Repository<OperadoraVTTarifaTipoModel>>(_unitOfWork);

            _repoCustomOperadoraVT = RepositoryFactory.CreateRepositoryCustom<OperadoraVTModel, OperadoraVTRepository>(_unitOfWork);
        }

        public dynamic BuscarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            try
            {
                var result = _repoCustomOperadoraVT.GetOperadoraVT(OperadoraVT);

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

        public dynamic BuscarOperadoraVTPorId(int id)
        {
            try
            {
                var result = _repoCustomOperadoraVT.GetOperadoraVTbyId(id);
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

        public dynamic BuscarOperadoraVTPorNome(string nomeOperadoraVT)
        {
            try
            {
                var result = _repoCustomOperadoraVT.GetOperadoraVTByNome(nomeOperadoraVT);

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

        public dynamic BuscarTudoOperadoraVT()
        {
            try
            {
                var result = _repoCustomOperadoraVT.GetAllOperadoraVT();

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
        public dynamic BuscarOperadoraVTBandeiraCartao()
        {
            try
            {
                var result = Cache.Get<List<OperadoraVTBandeiraCartaoModel>>("OperadoraVTBandeiraCartao");
                if (result == null)
                {
                    result = _repoDefaultOperadoraVTBandeiraCartao.GetAll();

                    Cache.AddItem("OperadoraVTBandeiraCartao", result, 1);
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

        public dynamic BuscarOperadoraVTTarifaTipo()
        {
            try
            {
                var result = Cache.Get<List<OperadoraVTTarifaTipoModel>>("OperadoraVTTarifaTipo");
                if (result == null)
                {
                    result = _repoDefaultOperadoraVTTarifaTipo.GetAll();

                    Cache.AddItem("OperadoraVTTarifaTipo", result, 1);
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

        public dynamic AdicionarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            try
            {
                var validacaoEntrada = ValidacaoEntrada(OperadoraVT);
                if (validacaoEntrada.Codigo == 0)
                {
                    OperadoraVT.DataCadastro = DateTime.Now;
                    _repoDefaultOperadoraVT.Add(OperadoraVT);
                    _unitOfWork.Commit();

                    var result = _repoCustomOperadoraVT.GetOperadoraVTbyId(OperadoraVT.Id);

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

        public dynamic EditarOperadoraVT(OperadoraVTModel OperadoraVT)
        {
            dynamic result;

            try
            {
                var validacaoEntrada = ValidacaoEntrada(OperadoraVT);
                if (validacaoEntrada.Codigo == 0)
                {
                    var OperadoraVTResult = _repoCustomOperadoraVT.GetOperadoraVTbyId(OperadoraVT.Id);

                    if (OperadoraVTResult != null)
                    {
                        OperadoraVTResult.Nome = OperadoraVT.Nome;
                        OperadoraVTResult.OperadoraVTBandeiraCartaoId = OperadoraVT.OperadoraVTBandeiraCartaoId;
                        OperadoraVTResult.OperadoraVTTarifaTipoId = OperadoraVT.OperadoraVTTarifaTipoId;

                        _unitOfWork.Commit();

                        result = _repoCustomOperadoraVT.GetOperadoraVTbyId(OperadoraVTResult.Id);
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

        public dynamic ExcluirOperadoraVT(int id)
        {
            dynamic result;

            try
            {
                result = _repoCustomOperadoraVT.GetOperadoraVTbyId(id);

                if (result != null)
                {
                    _repoDefaultOperadoraVT.Delete(result);
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

        private ErrorModel ValidacaoEntrada(OperadoraVTModel operadoraVT)
        {
            var erroModel = new ErrorModel();

            if (string.IsNullOrEmpty(operadoraVT.Nome))
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Informe o Nome da Operadora";
            }
            else if (operadoraVT.OperadoraVTBandeiraCartaoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione a Bandeira do Cartão";
            }
            else if (operadoraVT.OperadoraVTBandeiraCartaoId == 0)
            {
                erroModel.Codigo = 600;
                erroModel.Descricao = "Selecione o Tipo da Tarifa";
            }
            else
            {
                var result = _repoCustomOperadoraVT.GetOperadoraVTValidation(operadoraVT);
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
