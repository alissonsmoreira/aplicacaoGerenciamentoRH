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
    public class HoleriteRepositoryTest
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<HoleriteModel> _repositoryHoleriteDefault;
        public static IHoleriteRepository<HoleriteModel> _repositoryHoleriteCustom;

        public HoleriteRepositoryTest()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryHoleriteDefault = new Repository<HoleriteModel>(_unitOfWork);
            _repositoryHoleriteCustom = new HoleriteRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetAll_SUCESS()
        {
            int holeriteId = 4;
            var result = _repositoryHoleriteCustom.GetHoleriteById(holeriteId);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBeneficioTipo_SUCESS()
        {
            int colaboradorId = 2;
            string Mes = "03";
            string Ano = "2021";

            var result = _repositoryHoleriteCustom.GetHoleriteByColaboradorIdMesAno(colaboradorId, Mes, Ano, null);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}