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
    public class JustificativaDivergenciaFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static JustificativaDivergenciaFacade JustificativaDivergenciaFacade;

        public JustificativaDivergenciaFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            JustificativaDivergenciaFacade = new JustificativaDivergenciaFacade();
        }

        [TestMethod]
        public void BuscarJustificativaDivergencia_SUCESS()
        {
            var JustificativaDivergenciaModel = new JustificativaDivergenciaModel();
            JustificativaDivergenciaModel.Tipo = "1";

            var result = JustificativaDivergenciaFacade.BuscarJustificativaDivergencia(JustificativaDivergenciaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarJustificativaDivergencia_SUCESS()
        {
            var JustificativaDivergenciaModel = new JustificativaDivergenciaModel();
            JustificativaDivergenciaModel.Tipo = "Justificativa10";

            var result = JustificativaDivergenciaFacade.AdicionarJustificativaDivergencia(JustificativaDivergenciaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarJustificativaDivergencia_SUCESS()
        {
            var JustificativaDivergenciaModel = new JustificativaDivergenciaModel();
            JustificativaDivergenciaModel.Id = 2;
            JustificativaDivergenciaModel.Tipo = "Justificativa255";

            var result = JustificativaDivergenciaFacade.EditarJustificativaDivergencia(JustificativaDivergenciaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirJustificativaDivergencia_SUCESS()
        {
            var result = JustificativaDivergenciaFacade.ExcluirJustificativaDivergencia(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
