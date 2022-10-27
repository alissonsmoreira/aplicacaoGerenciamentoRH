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
    public class UnidadeNegocioFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static UnidadeNegocioFacade UnidadeNegocioFacade;

        public UnidadeNegocioFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            UnidadeNegocioFacade = new UnidadeNegocioFacade();
        }

        [TestMethod]
        public void BuscarUnidadeNegocio_SUCESS()
        {
            var UnidadeNegocioModel = new UnidadeNegocioModel();
            UnidadeNegocioModel.Codigo = 1;
            UnidadeNegocioModel.Nome = "Tip";

            var result = UnidadeNegocioFacade.BuscarUnidadeNegocio(UnidadeNegocioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarUnidadeNegocio_SUCESS()
        {
            var UnidadeNegocioModel = new UnidadeNegocioModel();
            UnidadeNegocioModel.Codigo = 2;
            UnidadeNegocioModel.Nome = "Unidade2";

            var result = UnidadeNegocioFacade.AdicionarUnidadeNegocio(UnidadeNegocioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarUnidadeNegocio_SUCESS()
        {
            var UnidadeNegocioModel = new UnidadeNegocioModel();
            UnidadeNegocioModel.Id = 2;
            UnidadeNegocioModel.Codigo = 3;
            UnidadeNegocioModel.Nome = "Unidade3";

            var result = UnidadeNegocioFacade.EditarUnidadeNegocio(UnidadeNegocioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirUnidadeNegocio_SUCESS()
        {
            var result = UnidadeNegocioFacade.ExcluirUnidadeNegocio(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
