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
    public class DesligamentoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static DesligamentoFacade DesligamentoFacade;

        public DesligamentoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            DesligamentoFacade = new DesligamentoFacade();
        }

        [TestMethod]
        public void BuscarSolicitacaoAlteracaoPorColaboradorId_SUCESS()
        {

            var result = DesligamentoFacade.BuscarSolicitacaoDesligamentoPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        //[Ignore]
        public void SolicitarDesligamento_SUCESS()
        {
            var desligamentoModel = new DesligamentoModel();
            desligamentoModel.GestorId = 1;
            desligamentoModel.ColaboradorId = 1;

            desligamentoModel.DataSugerida = Convert.ToDateTime("2021-04-01");
            desligamentoModel.DesligamentoTipoId = 1;
            desligamentoModel.Motivo = "Fim de contrato";
            desligamentoModel.Substituir = true;
            desligamentoModel.Recontrataria = true;

            var result = DesligamentoFacade.SolicitarDesligamento(desligamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AprovarSolicitacaoDesligamento_SUCESS()
        {
            DesligamentoModel desligamento = new DesligamentoModel();
            var result = DesligamentoFacade.AprovarSolicitacaoDesligamento(desligamento);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void ReprovarSolicitacaoDesligamento_SUCESS()
        {

            var result = DesligamentoFacade.ReprovarSolicitacaoDesligamento(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
