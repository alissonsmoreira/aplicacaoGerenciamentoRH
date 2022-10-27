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
    public class TipoMaoObraFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static TipoMaoObraFacade TipoMaoObraFacade;

        public TipoMaoObraFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            TipoMaoObraFacade = new TipoMaoObraFacade();
        }

        [TestMethod]
        public void BuscarTipoMaoObra_SUCESS()
        {
            var TipoMaoObraModel = new TipoMaoObraModel();
            TipoMaoObraModel.Codigo = 1;
            TipoMaoObraModel.Nome = "Tip";

            var result = TipoMaoObraFacade.BuscarTipoMaoObra(TipoMaoObraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarTipoMaoObra_SUCESS()
        {
            var TipoMaoObraModel = new TipoMaoObraModel();
            TipoMaoObraModel.Codigo = 2;
            TipoMaoObraModel.Nome = "TipoMaodeObra2";

            var result = TipoMaoObraFacade.AdicionarTipoMaoObra(TipoMaoObraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarTipoMaoObra_SUCESS()
        {
            var TipoMaoObraModel = new TipoMaoObraModel();
            TipoMaoObraModel.Id = 2;
            TipoMaoObraModel.Codigo = 3;
            TipoMaoObraModel.Nome = "TipoMaodeObra3";

            var result = TipoMaoObraFacade.EditarTipoMaoObra(TipoMaoObraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirTipoMaoObra_SUCESS()
        {
            var result = TipoMaoObraFacade.ExcluirTipoMaoObra(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
