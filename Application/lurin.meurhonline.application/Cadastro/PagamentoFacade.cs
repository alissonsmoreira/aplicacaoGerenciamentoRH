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
    public class PagamentoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultBanco;
        private static dynamic _repoDefaultContaBancariaTipo;

        public PagamentoFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultBanco = RepositoryFactory.CreateRepository<BancoModel, Repository<BancoModel>>(_unitOfWork);
            _repoDefaultContaBancariaTipo = RepositoryFactory.CreateRepository<ContaBancariaTipoModel, Repository<ContaBancariaTipoModel>>(_unitOfWork);

        }

        public dynamic BuscarTudoBanco()
        {
            try
            {
                var result = _repoDefaultBanco.GetAll();
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

        public dynamic BuscarTudoTipoConta()
        {
            try
            {
                var result = _repoDefaultContaBancariaTipo.GetAll();
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

    }
}