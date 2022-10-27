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
    public class CentroCustoUnidadeFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static CentroCustoUnidadeFacade CentroCustoUnidadeFacade;

        public CentroCustoUnidadeFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            CentroCustoUnidadeFacade = new CentroCustoUnidadeFacade();
        }

        [TestMethod]
        public void BuscarCentroCustoUnidade_SUCESS()
        {
            var centroCustoUnidadeModel = new CentroCustoUnidadeModel();
            centroCustoUnidadeModel.Codigo = 2;
            centroCustoUnidadeModel.Nome = "to";

            var result = CentroCustoUnidadeFacade.BuscarCentroCustoUnidade(centroCustoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudoCentroCustoUnidade_SUCESS()
        {

            var result = CentroCustoUnidadeFacade.BuscarTudoCentroCustoUnidade();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarCentroCustoUnidadePorIdEmpresa_SUCESS()
        {

            var result = CentroCustoUnidadeFacade.BuscarCentroCustoUnidadePorIdEmpresa(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarCentroCustoUnidade_SUCESS()
        {
            var centroCustoUnidadeModel = new CentroCustoUnidadeModel();
            centroCustoUnidadeModel.Codigo = 2;
            centroCustoUnidadeModel.Nome = "Centro de Custo 1";
            centroCustoUnidadeModel.DataCadastro = DateTime.Now;

            var result = CentroCustoUnidadeFacade.AdicionarCentroCustoUnidade(centroCustoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarCentroCusto_SUCESS()
        {
            var centroCustoUnidadeModel = new CentroCustoUnidadeModel();
            centroCustoUnidadeModel.Id = 1;
            centroCustoUnidadeModel.Nome = "Centro 2";

            var result = CentroCustoUnidadeFacade.EditarCentroCustoUnidade(centroCustoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirCentroCusto_SUCESS()
        {
            var result = CentroCustoUnidadeFacade.ExcluirCentroCustoUnidade(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
