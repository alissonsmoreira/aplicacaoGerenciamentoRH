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
    public class LotacaoPlanoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static LotacaoPlanoFacade LotacaoPlanoFacade;

        public LotacaoPlanoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            LotacaoPlanoFacade = new LotacaoPlanoFacade();
        }

        [TestMethod]
        public void BuscarLotacaoPlano_SUCESS()
        {
            var lotacaoPlanoModel = new LotacaoPlanoModel();
            lotacaoPlanoModel.Codigo = 1;
            lotacaoPlanoModel.Nome = "Pl";

            var result = LotacaoPlanoFacade.BuscarLotacaoPlano(lotacaoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarLotacaoPlano_SUCESS()
        {
            var lotacaoPlanoModel = new LotacaoPlanoModel();
            lotacaoPlanoModel.Codigo = 35;
            lotacaoPlanoModel.Nome = "Plano 35";
            lotacaoPlanoModel.EmpresaId = 1;

            var result = LotacaoPlanoFacade.AdicionarLotacaoPlano(lotacaoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarLotacaoPlanoUnidade_SUCESS()
        {
            var lotacaoPlanoUnidade = new List<LotacaoPlanoUnidadeModel>();
            var lotacao = new LotacaoPlanoUnidadeModel();
            lotacao.LotacaoPlanoId = 1;
            lotacao.LotacaoUnidadeId = 5;

            lotacaoPlanoUnidade.Add(lotacao);
            var result = LotacaoPlanoFacade.AdicionarLotacaoPlanoUnidade(lotacaoPlanoUnidade);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarLotacaoPlano_SUCESS()
        {
            var lotacaoPlanoModel = new LotacaoPlanoModel();
            lotacaoPlanoModel.Id = 2;
            lotacaoPlanoModel.Codigo = 45;
            lotacaoPlanoModel.Nome = "Plano 35";

            var result = LotacaoPlanoFacade.EditarLotacaoPlano(lotacaoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirLotacaoPlano_SUCESS()
        {
            var result = LotacaoPlanoFacade.ExcluirLotacaoPlano(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
