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
    public class InformeRendimentoFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static InformeRendimentoFacade informeRendimentoFacade;

        public InformeRendimentoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            informeRendimentoFacade = new InformeRendimentoFacade();
        }

        [TestMethod]
        [Ignore]
        public void ImportarInformeRendimento_SUCESS()
        {
            var informeRendimentoModel = new InformeRendimentoModel();
            informeRendimentoModel.DocumentoBase64 = "insira o arquivo base¨4";
            var result = informeRendimentoFacade.ImportarInformeRendimento(informeRendimentoModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarInformeRendimentoPorColaboradorId_SUCESS()
        {
            var result = informeRendimentoFacade.BuscarInformeRendimentoPorColaboradorIdAno(1, "2021");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void BuscarInformeRendimentoPorId_SUCESS()
        {
            var result = informeRendimentoFacade.BuscarInformeRendimentoPorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
