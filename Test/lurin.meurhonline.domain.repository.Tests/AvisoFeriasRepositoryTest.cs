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
    public class AvisoFeriasRepositoryTest
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<AvisoFeriasModel> _repositoryAvisoFeriasDefault;
        public static IAvisoFeriasRepository<AvisoFeriasModel> _repositoryAvisoFeriasCustom;

        public AvisoFeriasRepositoryTest()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryAvisoFeriasDefault = new Repository<AvisoFeriasModel>(_unitOfWork);
            _repositoryAvisoFeriasCustom = new AvisoFeriasRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetAll_SUCESS()
        {
            int cartaoPontoId = 14;
            var result = _repositoryAvisoFeriasCustom.GetAvisoFeriasById(cartaoPontoId);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBeneficioTipo_SUCESS()
        {
            int colaboradorId = 8;
            string Ano = "2021";

            var result = _repositoryAvisoFeriasCustom.GetAvisoFeriasByColaboradorIdAno(colaboradorId, Ano);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}