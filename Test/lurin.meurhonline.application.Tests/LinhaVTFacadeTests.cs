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
    public class LinhaVTFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static LinhaVTFacade LinhaVTFacade;

        public LinhaVTFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            LinhaVTFacade = new LinhaVTFacade();
        }

        [TestMethod]
        public void BuscarLinhaVT_SUCESS()
        {
            var LinhaVTModel = new LinhaVTModel();
            LinhaVTModel.NomeLinha = "2";
            LinhaVTModel.ValorLinha = 20.05M;
            LinhaVTModel.OperadoraVTId = 0;

            var result = LinhaVTFacade.BuscarLinhaVT(LinhaVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarLinhaVT_SUCESS()
        {
            var LinhaVTModel = new LinhaVTModel();
            LinhaVTModel.NomeLinha = "Linha";
            LinhaVTModel.ValorLinha = 20.05M;
            LinhaVTModel.OperadoraVTId = 1;

            var result = LinhaVTFacade.AdicionarLinhaVT(LinhaVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarLinhaVT_SUCESS()
        {
            var LinhaVTModel = new LinhaVTModel();
            LinhaVTModel.Id = 1;
            LinhaVTModel.NomeLinha = "Linha 525";
            LinhaVTModel.ValorLinha = Convert.ToDecimal("50,05");
            LinhaVTModel.OperadoraVTId = 4;

            var result = LinhaVTFacade.EditarLinhaVT(LinhaVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExcluirLinhaVT_SUCESS()
        {
            var result = LinhaVTFacade.ExcluirLinhaVT(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
