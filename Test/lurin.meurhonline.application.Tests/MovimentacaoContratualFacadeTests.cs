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
    public class MovimentacaoContratualFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static MovimentacaoContratualFacade MovimentacaoContratualFacade;

        public MovimentacaoContratualFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            MovimentacaoContratualFacade = new MovimentacaoContratualFacade();
        }

        [TestMethod]
        public void BuscarDadosPorColaboradorId_SUCESS()
        {

            var result = MovimentacaoContratualFacade.BuscarDadosPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarSolicitacaoAlteracaoPorColaboradorId_SUCESS()
        {

            var result = MovimentacaoContratualFacade.BuscarSolicitacaoMovimentacaoContratualPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        //[Ignore]
        public void SolicitarMovimentacaoContratual_SUCESS()
        {
            var movimentacaoContratualModel = new MovimentacaoContratualModel();
            movimentacaoContratualModel.GestorId = 1;
            movimentacaoContratualModel.ColaboradorId = 1;
            movimentacaoContratualModel.EmpresaId = 1;
            movimentacaoContratualModel.LotacaoUnidadeId = 1;
            movimentacaoContratualModel.CentroCustoUnidadeId = 1;
            movimentacaoContratualModel.CargoUnidadeId = 1;
            movimentacaoContratualModel.TurnoId = 1;
            movimentacaoContratualModel.UnidadeNegocioId = 1;
            movimentacaoContratualModel.NumeroCartaoPonto = "545450";
            movimentacaoContratualModel.TipoMaoObraId = 1;
            movimentacaoContratualModel.Salario = 2000;

            var result = MovimentacaoContratualFacade.SolicitarMovimentacaoContratual(movimentacaoContratualModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AprovarSolicitacaoMovimentacaoContratual_SUCESS()
        {

            var result = MovimentacaoContratualFacade.AprovarSolicitacaoMovimentacaoContratual(8);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void ReprovarSolicitacalMovimentacaoContratual_SUCESS()
        {

            var result = MovimentacaoContratualFacade.ReprovarSolicitacaoMovimentacaoContratual(4);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
