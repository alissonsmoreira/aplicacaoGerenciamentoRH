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
    public class AtestadoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static AtestadoFacade AtestadoFacade;

        public AtestadoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            AtestadoFacade = new AtestadoFacade();
        }

        [TestMethod]
        public void BuscarLancamentoAtestadoPorColaboradorId_SUCESS()
        {

            var result = AtestadoFacade.BuscarLancamentoAtestadoPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        //[Ignore]
        public void LancarAtestado_SUCESS()
        {
            var atestadoModel = new AtestadoModel();
            atestadoModel.ColaboradorId = 1;
            atestadoModel.DataAtestado = DateTime.Now;
            atestadoModel.HorarioChegada = "08:00";
            atestadoModel.HorarioSaida = "12:00";
            atestadoModel.QuantidadeDias = 10;
            atestadoModel.CID = "Leve";
            atestadoModel.AtestadoBase64 = "ASDASDASDAS";
            atestadoModel.ColaboradorId = 1;

            var result = AtestadoFacade.LancarAtestado(atestadoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AprovarLancamentoAtestado_SUCESS()
        {

            var result = AtestadoFacade.AprovarLancamentoAtestado(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void ReprovarLancamentoAtestado_SUCESS()
        {

            var result = AtestadoFacade.ReprovarLancamentoAtestado(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
