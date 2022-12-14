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
    public class CidadeFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;

        private static dynamic _repoDefaultCidade;
        private static dynamic _repoCustomCidade;

        public CidadeFacade()
        {
            _unitOfWork = new UnitOfWork();

            _repoDefaultCidade = RepositoryFactory.CreateRepository<CidadeModel, Repository<CidadeModel>>(_unitOfWork);
            _repoCustomCidade = RepositoryFactory.CreateRepositoryCustom<CidadeModel, CidadeRepository>(_unitOfWork);
        }

        public dynamic BuscarCidadePorUF(string uf)
        {
            try
            {
                var result = _repoCustomCidade.GetCidadebyUF(uf);

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
