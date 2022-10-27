using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

using lurin.meurhonline.domain;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository;
using lurin.meurhonline.infrastructure.factory;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.infrastructure.log;
using lurin.meurhonline.infrastructure.exception;
using lurin.meurhonline.infrastructure.common;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.infrastructure.IO;

namespace lurin.meurhonline.application
{
    public class SolicitacaoFacade
    {
        private static IUnitOfWorkCustom _unitOfWork;


        public SolicitacaoFacade()
        {
            _unitOfWork = new UnitOfWork();

        }

        public dynamic BuscarTudoStatus()
        {
            try
            {
                var result = new List<SolicitacaoStatusModel>();
                foreach (var resultFor in Enum.GetValues(typeof(SolicitacaoStatusEnum)))
                {
                    var colaboradorStatus = new SolicitacaoStatusModel();
                    colaboradorStatus.Id = (int)resultFor;
                    colaboradorStatus.Nome = Utils.GetEnumDescription((SolicitacaoStatusEnum)resultFor);
                    result.Add(colaboradorStatus);
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
    }
}
