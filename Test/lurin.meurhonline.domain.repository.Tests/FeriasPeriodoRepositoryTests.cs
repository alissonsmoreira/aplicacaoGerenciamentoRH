using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository.Tests
{
    [TestClass]
    public class FeriasPeriodoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<FeriasPeriodoModel> _repositoryFeriasPeriodo;
        public static IFeriasPeriodoRepository<FeriasPeriodoModel> _repositoryFeriasPeriodoCustom;

        public FeriasPeriodoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryFeriasPeriodo = new Repository<FeriasPeriodoModel>(_unitOfWork);
            _repositoryFeriasPeriodoCustom = new FeriasPeriodoRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetFeriasById_SUCESS()
        {
            var result = _repositoryFeriasPeriodoCustom.GetFeriasPeriodoById(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
