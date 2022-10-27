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
    public class CargoPlanoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static CargoPlanoFacade CargoPlanoFacade;

        public CargoPlanoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            CargoPlanoFacade = new CargoPlanoFacade();
        }

        [TestMethod]
        public void BuscarCargoPlano_SUCESS()
        {
            var cargoPlanoModel = new CargoPlanoModel();
            cargoPlanoModel.Codigo = 1;
            cargoPlanoModel.Nome = "Pl";

            var result = CargoPlanoFacade.BuscarCargoPlano(cargoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarCargoPlano_SUCESS()
        {
            var CargoPlanoModel = new CargoPlanoModel();
            CargoPlanoModel.Codigo = 35;
            CargoPlanoModel.Nome = "Plano 35";
            CargoPlanoModel.EmpresaId = 1;

            var result = CargoPlanoFacade.AdicionarCargoPlano(CargoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarCargoPlanoUnidade_SUCESS()
        {
            var cargoPlanoUnidadeModel = new List<CargoPlanoUnidadeModel>();
            var cargo = new CargoPlanoUnidadeModel();
            cargo.CargoPlanoId = 1;
            cargo.CargoUnidadeId = 1;

            cargoPlanoUnidadeModel.Add(cargo);
            var result = CargoPlanoFacade.AdicionarCargoPlanoUnidade(cargoPlanoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarCargoPlano_SUCESS()
        {
            var CargoPlanoModel = new CargoPlanoModel();
            CargoPlanoModel.Id = 2;
            CargoPlanoModel.Codigo = 45;
            CargoPlanoModel.Nome = "Plano 35";

            var result = CargoPlanoFacade.EditarCargoPlano(CargoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirCargoPlano_SUCESS()
        {
            var result = CargoPlanoFacade.ExcluirCargoPlano(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
