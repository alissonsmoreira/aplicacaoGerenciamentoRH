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
    public class EquipeGestorFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static EquipeGestorFacade EquipeGestorFacade;

        public EquipeGestorFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            EquipeGestorFacade = new EquipeGestorFacade();
        }

        [TestMethod]
        public void BuscarEquipeGestor_SUCESS()
        {
            var equipeGestorModel = new EquipeGestorModel();
            equipeGestorModel.ColaboradorId = 1;
            equipeGestorModel.LotacaoUnidadeInicialId = 0;
            equipeGestorModel.LotacaoUnidadeFinalId = 0;

            var result = EquipeGestorFacade.BuscarEquipeGestor(equipeGestorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarEquipeGestor_SUCESS()
        {
            var equipeGestorModel = new EquipeGestorModel();
            equipeGestorModel.ColaboradorId = 1;
            equipeGestorModel.LotacaoUnidadeInicialId = 1;
            equipeGestorModel.LotacaoUnidadeFinalId = 3;

            var result = EquipeGestorFacade.AdicionarEquipeGestor(equipeGestorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirEquipeGestor_SUCESS()
        {
            var result = EquipeGestorFacade.ExcluirEquipeGestor(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
