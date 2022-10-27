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
    public class TurnoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static TurnoFacade TurnoFacade;

        public TurnoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            TurnoFacade = new TurnoFacade();
        }

        [TestMethod]
        public void BuscarTurno_SUCESS()
        {
            var TurnoModel = new TurnoModel();
            TurnoModel.Codigo = 1;
            TurnoModel.Descricao = "Turno3";

            var result = TurnoFacade.BuscarTurno(TurnoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTurnoDetalhebyTurnoId_SUCESS()
        {

            var result = TurnoFacade.BuscarTurnoDetalhePorTurnoId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTurnoDetalhe_SUCESS()
        {
            var TurnoDetalheModel = new TurnoDetalheModel();
            TurnoDetalheModel.DiaSemana = "Sabado";
            TurnoDetalheModel.HorarioInicial = "0";
            TurnoDetalheModel.HorarioFinal = "0";
            TurnoDetalheModel.TurnoId = 1;

            var result = TurnoFacade.BuscarTurnoDetalhe(TurnoDetalheModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarTurno_SUCESS()
        {
            var TurnoModel = new TurnoModel();
            TurnoModel.Codigo = 2;
            TurnoModel.Descricao = "Turno4";

            var result = TurnoFacade.AdicionarTurno(TurnoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarTurnoDetalhe_SUCESS()
        {
            var TurnoDetalheModel = new TurnoDetalheModel();
            TurnoDetalheModel.DiaSemana = "Quarta";
            TurnoDetalheModel.HorarioInicial = "09:00";
            TurnoDetalheModel.HorarioFinal = "19:00";
            TurnoDetalheModel.TurnoId = 1;

            var result = TurnoFacade.AdicionarTurnoDetalhe(TurnoDetalheModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarTurno_SUCESS()
        {
            var TurnoModel = new TurnoModel();
            TurnoModel.Id = 1;
            TurnoModel.Codigo = 3;
            TurnoModel.Descricao = "Turno5";

            var result = TurnoFacade.EditarTurno(TurnoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarTurnoDetalhe_SUCESS()
        {
            var TurnoDetalheModel = new TurnoDetalheModel();
            TurnoDetalheModel.Id = 16;
            TurnoDetalheModel.DiaSemana = "Quinta";
            TurnoDetalheModel.HorarioInicial = "09:00";
            TurnoDetalheModel.HorarioFinal = "19:00";
            TurnoDetalheModel.TurnoId = 1;

            var result = TurnoFacade.EditarTurnoDetalhe(TurnoDetalheModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirTurno_SUCESS()
        {
            var result = TurnoFacade.ExcluirTurno(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirTurnoDetalhe_SUCESS()
        {
            var result = TurnoFacade.ExcluirTurnoDetalhe(9);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
