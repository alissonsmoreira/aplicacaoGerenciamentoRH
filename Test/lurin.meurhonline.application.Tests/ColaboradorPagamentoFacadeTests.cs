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
    public class ColaboradorPagamentoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorPagamentoFacade ColaboradorPagamentoFacade;

        public ColaboradorPagamentoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorPagamentoFacade = new ColaboradorPagamentoFacade();
        }

        [TestMethod]
        public void BuscarPagamentoColaborador_SUCESS()
        {
            var colaboradorPagamentoModel = new ColaboradorPagamentoModel();
            colaboradorPagamentoModel.ColaboradorId = 3;
            colaboradorPagamentoModel.BancoId = 0;
            colaboradorPagamentoModel.Agencia = "";
            colaboradorPagamentoModel.Conta = "";
            colaboradorPagamentoModel.ContaBancariaTipoId = 0;

            var result = ColaboradorPagamentoFacade.BuscarPagamentoColaborador(colaboradorPagamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarPagamentoColaborador_SUCESS()
        {
            var colaboradorPagamentoModel = new ColaboradorPagamentoModel();
            colaboradorPagamentoModel.ColaboradorId = 1;
            colaboradorPagamentoModel.BancoId = 50;
            colaboradorPagamentoModel.Agencia = "001";
            colaboradorPagamentoModel.Conta = "1354842-5";
            colaboradorPagamentoModel.ContaBancariaTipoId = 2;

            var result = ColaboradorPagamentoFacade.AdicionarPagamentoColaborador(colaboradorPagamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarPagamentoColaborador_SUCESS()
        {
            var colaboradorPagamentoModel = new ColaboradorPagamentoModel();
            colaboradorPagamentoModel.Id = 2;
            colaboradorPagamentoModel.ColaboradorId = 1;
            colaboradorPagamentoModel.BancoId = 62;
            colaboradorPagamentoModel.Agencia = "001";
            colaboradorPagamentoModel.Conta = "1354842-5";
            colaboradorPagamentoModel.ContaBancariaTipoId = 3;

            var result = ColaboradorPagamentoFacade.EditarPagamentoColaborador(colaboradorPagamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
