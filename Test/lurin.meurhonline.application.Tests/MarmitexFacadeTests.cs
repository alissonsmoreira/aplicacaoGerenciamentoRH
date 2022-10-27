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
    public class MarmitexFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static MarmitexFacade MarmitexFacade;

        public MarmitexFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            MarmitexFacade = new MarmitexFacade();
        }

        [TestMethod]
        public void BuscarMarmitex_SUCESS()
        {
            var MarmitexModel = new MarmitexModel();
            MarmitexModel.Tipo = "1";

            var result = MarmitexFacade.BuscarMarmitex(MarmitexModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarMarmitex_SUCESS()
        {
            var MarmitexModel = new MarmitexModel();
            MarmitexModel.Tipo = "Marmitex10";

            var result = MarmitexFacade.AdicionarMarmitex(MarmitexModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarMarmitex_SUCESS()
        {
            var MarmitexModel = new MarmitexModel();
            MarmitexModel.Id = 2;
            MarmitexModel.Tipo = "Marmitex200";

            var result = MarmitexFacade.EditarMarmitex(MarmitexModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirMarmitex_SUCESS()
        {
            var result = MarmitexFacade.ExcluirMarmitex(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
