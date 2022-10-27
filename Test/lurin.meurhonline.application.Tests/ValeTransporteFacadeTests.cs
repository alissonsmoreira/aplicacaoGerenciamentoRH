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
    public class ValeTransporteFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ValeTransporteFacade ValeTransporteFacade;

        public ValeTransporteFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ValeTransporteFacade = new ValeTransporteFacade();
        }

        [TestMethod]
        public void BuscarSolicitacaoValeTransportePorColaboradorId_SUCESS()
        {

            var result = ValeTransporteFacade.BuscarSolicitacaoValeTransportePorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        //[Ignore]
        public void SolicitarValeTransporte_SUCESS()
        {
            var valeTransporteModel = new ValeTransporteModel();
            valeTransporteModel.ColaboradorId = 1;
            valeTransporteModel.OperadoraVTId = 1;
            valeTransporteModel.LinhaVTId = 1;
            valeTransporteModel.ValeTransporteUtilizacaoId = 2;
            valeTransporteModel.ValeTransporteSituacaoId = 2;

            var result = ValeTransporteFacade.SolicitarValeTransporte(valeTransporteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AprovarSolicitacaoValeTransporte_SUCESS()
        {

            var result = ValeTransporteFacade.AprovarSolicitacaoValeTransporte(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void ReprovarSolicitacaoValeTransporte_SUCESS()
        {

            var result = ValeTransporteFacade.ReprovarSolicitacaoValeTransporte(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
