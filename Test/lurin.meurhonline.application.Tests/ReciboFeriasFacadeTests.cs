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
    public class ReciboFeriasFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static ReciboFeriasFacade ReciboFeriasFacade;

        public ReciboFeriasFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ReciboFeriasFacade = new ReciboFeriasFacade();
        }

        [TestMethod]
        [Ignore]
        public void ImportarReciboFerias_SUCESS()
        {
            var ReciboFeriasModel = new ReciboFeriasModel();
            ReciboFeriasModel.DocumentoBase64 = "insira o arquivo base64 para teste";
            var result = ReciboFeriasFacade.ImportarReciboFerias(ReciboFeriasModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarReciboFeriasPorAnoColaboradorId_SUCESS()
        {
            var result = ReciboFeriasFacade.BuscarReciboFeriasPorAnoColaboradorId("2020", 1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarReciboFeriasPorId_SUCESS()
        {
            var result = ReciboFeriasFacade.BuscarReciboFeriasPorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
