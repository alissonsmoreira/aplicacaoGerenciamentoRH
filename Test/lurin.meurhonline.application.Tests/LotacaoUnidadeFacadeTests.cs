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
    public class LotacaoUnidadeFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static LotacaoUnidadeFacade LotacaoUnidadeFacade;

        public LotacaoUnidadeFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            LotacaoUnidadeFacade = new LotacaoUnidadeFacade();
        }

        [TestMethod]
        public void BuscarLotacaoUnidade_SUCESS()
        {
            var LotacaoUnidadeModel = new LotacaoUnidadeModel();
            LotacaoUnidadeModel.Codigo = 1;
            LotacaoUnidadeModel.Nome = "An";

            var result = LotacaoUnidadeFacade.BuscarLotacaoUnidade(LotacaoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudoLotacaoUnidade_SUCESS()
        {

            var result = LotacaoUnidadeFacade.BuscarTudoLotacaoUnidade();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarLotacaoUnidadePorIdEmpesa_SUCESS()
        {

            var result = LotacaoUnidadeFacade.BuscarLotacaoUnidadePorIdEmpresa(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarLotacaoUnidade_SUCESS()
        {
            var LotacaoUnidadeModel = new LotacaoUnidadeModel();
            LotacaoUnidadeModel.Codigo = 25;
            LotacaoUnidadeModel.Nome = "Analista 5";

            var result = LotacaoUnidadeFacade.AdicionarLotacaoUnidade(LotacaoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarLotacaoUnidade_SUCESS()
        {
            var LotacaoUnidadeModel = new LotacaoUnidadeModel();
            LotacaoUnidadeModel.Id = 2;
            LotacaoUnidadeModel.Codigo = 35;
            LotacaoUnidadeModel.Nome = "Analista20";

            var result = LotacaoUnidadeFacade.EditarLotacaoUnidade(LotacaoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirLotacaoUnidade_SUCESS()
        {
            var result = LotacaoUnidadeFacade.ExcluirLotacaoUnidade(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
