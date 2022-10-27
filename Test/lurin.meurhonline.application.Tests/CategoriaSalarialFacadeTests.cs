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
    public class CategoriaSalarialFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static CategoriaSalarialFacade CategoriaSalarialFacade;

        public CategoriaSalarialFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            CategoriaSalarialFacade = new CategoriaSalarialFacade();
        }

        [TestMethod]
        public void BuscarCategoriaSalarial_SUCESS()
        {
            var CategoriaSalarialModel = new CategoriaSalarialModel();
            CategoriaSalarialModel.Nome = "to";

            var result = CategoriaSalarialFacade.BuscarCategoriaSalarial(CategoriaSalarialModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarCategoriaSalarial_SUCESS()
        {
            var CategoriaSalarialModel = new CategoriaSalarialModel();
            CategoriaSalarialModel.Nome = "Categoria10";

            var result = CategoriaSalarialFacade.AdicionarCategoriaSalarial(CategoriaSalarialModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarCategoriaSalarial_SUCESS()
        {
            var CategoriaSalarialModel = new CategoriaSalarialModel();
            CategoriaSalarialModel.Id = 3;
            CategoriaSalarialModel.Nome = "Categoria20";

            var result = CategoriaSalarialFacade.EditarCategoriaSalarial(CategoriaSalarialModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirCategoriaSalarial_SUCESS()
        {
            var result = CategoriaSalarialFacade.ExcluirCategoriaSalarial(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
