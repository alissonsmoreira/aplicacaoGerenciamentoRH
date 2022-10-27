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
    public class SolicitacaoHoraExtraFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static SolicitacaoHoraExtraFacade solicitacaoHoraExtraFacade;

        public SolicitacaoHoraExtraFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            solicitacaoHoraExtraFacade = new SolicitacaoHoraExtraFacade();
        }

        [TestMethod]
        public void BuscarSolicitacaoHoraExtraPorGestorId_SUCESS()
        {
            int IdGestor = 6;
            DateTime data = Convert.ToDateTime("2021-03-30");

            var result = solicitacaoHoraExtraFacade.BuscarSolicitacaoHoraExtraPorGestorId(IdGestor, data);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao_SUCESS()
        {
            int empresaID = 1;
            DateTime dataSolicitacao = Convert.ToDateTime("2021-03-21");

            var result = solicitacaoHoraExtraFacade.BuscarSolicitacaoHoraExtraPorEmpresaIdDataSolicitacao(empresaID, dataSolicitacao);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void SolicitarHoraExtra_SUCESS()
        {
            SolicitacaoHoraExtraModel solicitacao = new SolicitacaoHoraExtraModel();

            solicitacao.GestorId = 6;
            solicitacao.Data = Convert.ToDateTime("2021-03-21");
            solicitacao.HoraInicio = Convert.ToDateTime("2021-03-21T07:00:00").TimeOfDay;
            solicitacao.HoraInicio = Convert.ToDateTime("2021-03-21T12:00:00").TimeOfDay;
            solicitacao.Motivo = "teste";
            solicitacao.TemCafeManha = true;
            solicitacao.TemRefeicao = true;
            solicitacao.TemMarmitex = false;
            solicitacao.MarmitexId = null;

            var result = solicitacaoHoraExtraFacade.SolicitarHorExtra(solicitacao);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ConvocarFuncionarios_SUCESS()
        {
            var solicitacaoHoraExtra = new SolicitacaoHoraExtraModel();
            SolicitacaoHoraExtraColaboradorModel solicitacaoHoraExtraColaborador = new SolicitacaoHoraExtraColaboradorModel();
            solicitacaoHoraExtra.Id = 4;
            solicitacaoHoraExtraColaborador.ColaboradorId = 2;
            solicitacaoHoraExtraColaborador.SolicitacaoHoraExtraId = 4;
            solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador.Add(solicitacaoHoraExtraColaborador);

            var result = solicitacaoHoraExtraFacade.ConvocarFuncionarios(solicitacaoHoraExtra);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AprovarSolicitacaoHoraExtra_SUCESS()
        {
            var solicitacaoHoraExtra = new SolicitacaoHoraExtraModel();
            var solicitacaoHoraExtraColaborador = new SolicitacaoHoraExtraColaboradorModel();
            solicitacaoHoraExtra.Id = 4;
            solicitacaoHoraExtraColaborador.ColaboradorId = 2;
            solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador.Add(solicitacaoHoraExtraColaborador);

            var result = solicitacaoHoraExtraFacade.AprovarSolicitacaoHoraExtra(solicitacaoHoraExtra);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ReprovarSolicitacaoHoraExtra_SUCESS()
        {
            var solicitacaoHoraExtra = new SolicitacaoHoraExtraModel();
            var solicitacaoHoraExtraColaborador = new SolicitacaoHoraExtraColaboradorModel();
            solicitacaoHoraExtra.Id = 4;
            solicitacaoHoraExtraColaborador.ColaboradorId = 3;
            solicitacaoHoraExtra.SolicitacaoHoraExtraColaborador.Add(solicitacaoHoraExtraColaborador);

            var result = solicitacaoHoraExtraFacade.ReprovarSolicitacaoHoraExtra(solicitacaoHoraExtra);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}

