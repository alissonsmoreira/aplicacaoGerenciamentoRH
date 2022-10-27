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
    public class BeneficioColaboradorFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static BeneficioColaboradorFacade BeneficioColaboradorFacade;

        public BeneficioColaboradorFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            BeneficioColaboradorFacade = new BeneficioColaboradorFacade();
        }

        [TestMethod]
        public void BuscarBeneficioColaboradorPorColaboradorId_SUCESS()
        {

            var result = BeneficioColaboradorFacade.BuscarTudoBeneficioColaboradorPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void SolicitarBeneficioColaborador_SUCESS()
        {
            var BeneficioColaboradorModel = new BeneficioColaboradorModel();
            BeneficioColaboradorModel.ColaboradorId = 1;
            BeneficioColaboradorModel.BeneficioId = 1;

            var result = BeneficioColaboradorFacade.SolicitarBeneficioColaborador(BeneficioColaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AprovarSolicitacaoBeneficioColaborador_SUCESS()
        {

            var result = BeneficioColaboradorFacade.AprovarSolicitacaoBeneficioColaborador(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ReprovarSolicitacaoBeneficioColaborador_SUCESS()
        {

            var result = BeneficioColaboradorFacade.ReprovarSolicitacaoBeneficioColaborador(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirSolicitacaoBeneficioColaborador_SUCESS()
        {

            var result = BeneficioColaboradorFacade.ExcluirBeneficioColaborador(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
