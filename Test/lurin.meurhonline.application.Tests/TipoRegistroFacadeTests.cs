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
    public class TipoRegistroFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static TipoRegistroFacade TipoRegistroFacade;

        public TipoRegistroFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            TipoRegistroFacade = new TipoRegistroFacade();
        }

        [TestMethod]
        public void BuscarTipoRegistro_SUCESS()
        {
            var TipoRegistroModel = new TipoRegistroModel();
            TipoRegistroModel.Nome = "Re";

            var result = TipoRegistroFacade.BuscarTipoRegistro(TipoRegistroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarTipoRegistro_SUCESS()
        {
            var TipoRegistroModel = new TipoRegistroModel();
            TipoRegistroModel.Nome = "TipoRegistro2";

            var result = TipoRegistroFacade.AdicionarTipoRegistro(TipoRegistroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarTipoRegistro_SUCESS()
        {
            var TipoRegistroModel = new TipoRegistroModel();
            TipoRegistroModel.Id = 2;
            TipoRegistroModel.Nome = "TipoRegistro3";

            var result = TipoRegistroFacade.EditarTipoRegistro(TipoRegistroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirTipoRegistro_SUCESS()
        {
            var result = TipoRegistroFacade.ExcluirTipoRegistro(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
