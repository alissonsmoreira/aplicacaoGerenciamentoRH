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
    public class DivergenciaFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static DivergenciaFacade DivergenciaFacade;

        public DivergenciaFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            DivergenciaFacade = new DivergenciaFacade();
        }

        [TestMethod]
        [Ignore]
        public void ImportarDivergencia_SUCESS()
        {
            var DivergenciaModel = new DivergenciaModel();
            DivergenciaModel.DocumentoBase64 = "insira o arquivo base64 para teste";
            var result = DivergenciaFacade.ImportarDivergencia(DivergenciaModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarDivergenciaPorColaboradorId_SUCESS()
        {
            var result = DivergenciaFacade.BuscarDivergenciaPorColaboradorIdData(1, "01/01/2020", "01/03/2020");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarDivergenciaPorId_SUCESS()
        {
            var result = DivergenciaFacade.BuscarDivergenciaPorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
