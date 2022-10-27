﻿using System;
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
    public class AvisoFeriasFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static AvisoFeriasFacade avisoFeriasFacade;

        public AvisoFeriasFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            avisoFeriasFacade = new AvisoFeriasFacade();
        }

        [TestMethod]
        public void AdicionarCartaoPonto_SUCESS()
        {
            var avisoFeriasModel = new AvisoFeriasModel();
            avisoFeriasModel.Ano = "2021";

            var result = avisoFeriasFacade.AdicionarAvisoFerias(avisoFeriasModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }


        [TestMethod]
        public void BuscarCartaoPontoPorId_SUCESS()
        {
            int avisoFerias = 12;

            var result = avisoFeriasFacade.BuscarAvisoFeriasPorId(avisoFerias);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarCartaoPontoPorColaboradorId_SUCESS()
        {
            int ColabotadorId = 8;
            string Ano = "2021";

            var result = avisoFeriasFacade.BuscarAvisoFeriasPorColaboradorIdAno(ColabotadorId, Ano);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}

