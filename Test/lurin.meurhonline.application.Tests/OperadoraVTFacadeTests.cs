using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class OperadoraVTFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static OperadoraVTFacade OperadoraVTFacade;

        public OperadoraVTFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            OperadoraVTFacade = new OperadoraVTFacade();
        }

        [TestMethod]
        public void BuscarOperadoraVT_SUCESS()
        {
            var OperadoraVTModel = new OperadoraVTModel();
            OperadoraVTModel.Nome = "Tes";
            OperadoraVTModel.OperadoraVTBandeiraCartaoId = 0;
            OperadoraVTModel.OperadoraVTTarifaTipoId = 0;

            var result = OperadoraVTFacade.BuscarOperadoraVT(OperadoraVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarOperadoraVTBandeiraCartao_SUCESS()
        {
            var result = OperadoraVTFacade.BuscarOperadoraVTBandeiraCartao();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarOperadoraVT_SUCESS()
        {
            var OperadoraVTModel = new OperadoraVTModel();
            OperadoraVTModel.Nome = "Operadora2";
            OperadoraVTModel.OperadoraVTBandeiraCartaoId = 1;
            OperadoraVTModel.OperadoraVTTarifaTipoId = 2;

            var result = OperadoraVTFacade.AdicionarOperadoraVT(OperadoraVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarOperadoraVT_SUCESS()
        {
            var OperadoraVTModel = new OperadoraVTModel();
            OperadoraVTModel.Id = 2;
            OperadoraVTModel.Nome = "Operadora3";
            OperadoraVTModel.OperadoraVTBandeiraCartaoId = 2;
            OperadoraVTModel.OperadoraVTTarifaTipoId = 1;

            var result = OperadoraVTFacade.EditarOperadoraVT(OperadoraVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirOperadoraVT_SUCESS()
        {
            var result = OperadoraVTFacade.ExcluirOperadoraVT(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
