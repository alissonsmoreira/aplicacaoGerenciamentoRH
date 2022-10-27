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
    public class CentroCustoPlanoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static CentroCustoPlanoFacade CentroCustoPlanoFacade;

        public CentroCustoPlanoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            CentroCustoPlanoFacade = new CentroCustoPlanoFacade();
        }

        [TestMethod]
        public void BuscarCentroCustoPlano_SUCESS()
        {
            var centroCustoPlanoModel = new CentroCustoPlanoModel();
            centroCustoPlanoModel.Codigo = 1;
            centroCustoPlanoModel.Nome = "Pl";

            var result = CentroCustoPlanoFacade.BuscarCentroCustoPlano(centroCustoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarCentroCustoPlano_SUCESS()
        {
            var centroCustoPlanoModel = new CentroCustoPlanoModel();
            centroCustoPlanoModel.Codigo = 35;
            centroCustoPlanoModel.Nome = "Plano 35";
            centroCustoPlanoModel.EmpresaId = 1;

            var result = CentroCustoPlanoFacade.AdicionarCentroCustoPlano(centroCustoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarCentroCustoPlanoUnidade_SUCESS()
        {
            var centroCustoPlanoUnidade = new List<CentroCustoPlanoUnidadeModel>();
            var centroCusto = new CentroCustoPlanoUnidadeModel();
            centroCusto.CentroCustoPlanoId = 1;
            centroCusto.CentroCustoUnidadeId = 2;

            centroCustoPlanoUnidade.Add(centroCusto);
            var result = CentroCustoPlanoFacade.AdicionarCentroCustoPlanoUnidade(centroCustoPlanoUnidade);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarCentroCustoPlano_SUCESS()
        {
            var centroCustoPlanoModel = new CentroCustoPlanoModel();
            centroCustoPlanoModel.Id = 2;
            centroCustoPlanoModel.Codigo = 45;
            centroCustoPlanoModel.Nome = "Plano 35";

            var result = CentroCustoPlanoFacade.EditarCentroCustoPlano(centroCustoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirCentroCustoPlano_SUCESS()
        {
            var result = CentroCustoPlanoFacade.ExcluirCentroCustoPlano(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
