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
    public class CargoUnidadeFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static CargoUnidadeFacade CargoUnidadeFacade;

        public CargoUnidadeFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            CargoUnidadeFacade = new CargoUnidadeFacade();
        }

        [TestMethod]
        public void BuscarCargoUnidade_SUCESS()
        {
            var cargoUnidadeModel = new CargoUnidadeModel();
            cargoUnidadeModel.Codigo = 1;
            cargoUnidadeModel.Nome = "An";

            var result = CargoUnidadeFacade.BuscarCargoUnidade(cargoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudoCargoUnidade_SUCESS()
        {

            var result = CargoUnidadeFacade.BuscarTudoCargoUnidade();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarCargoUnidadePorIdEmpesa_SUCESS()
        {

            var result = CargoUnidadeFacade.BuscarCargoUnidadePorIdEmpresa(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarCargoUnidade_SUCESS()
        {
            var cargoUnidadeModel = new CargoUnidadeModel();
            cargoUnidadeModel.Codigo = 25;
            cargoUnidadeModel.Nome = "Analista";

            var result = CargoUnidadeFacade.AdicionarCargoUnidade(cargoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarCargoUnidade_SUCESS()
        {
            var cargoUnidadeModel = new CargoUnidadeModel();
            cargoUnidadeModel.Id = 3;
            cargoUnidadeModel.Codigo = 35;
            cargoUnidadeModel.Nome = "Analista20";

            var result = CargoUnidadeFacade.EditarCargoUnidade(cargoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirCargoUnidade_SUCESS()
        {
            var result = CargoUnidadeFacade.ExcluirCargoUnidade(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
