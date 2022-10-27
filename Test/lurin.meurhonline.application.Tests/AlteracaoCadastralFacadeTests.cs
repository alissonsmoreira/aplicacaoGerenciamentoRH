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
    public class AlteracaoCadastralFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static AlteracaoCadastralFacade AlteracaoCadastralFacade;

        public AlteracaoCadastralFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            AlteracaoCadastralFacade = new AlteracaoCadastralFacade();
        }

        [TestMethod]
        public void BuscarDadosPorColaboradorId_SUCESS()
        {

            var result = AlteracaoCadastralFacade.BuscarDadosPorColaboradorId(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarSolicitacaoAlteracaoPorColaboradorId_SUCESS()
        {

            var result = AlteracaoCadastralFacade.BuscarSolicitacaoAlteracaoPorColaboradorId(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        //[Ignore]
        public void SolicitarAlteracao_SUCESS()
        {
            var alteracaoCadastralModel = new AlteracaoCadastralModel();
            alteracaoCadastralModel.ColaboradorId = 2;
            alteracaoCadastralModel.Nome = "Colaborador Alteracao";
            alteracaoCadastralModel.Endereco = "Rua Alteracao";
            alteracaoCadastralModel.Numero = "20";
            alteracaoCadastralModel.Complemento = "Teste";
            alteracaoCadastralModel.Bairro = "Bairro Alteracao";
            alteracaoCadastralModel.CEP = "0000020";
            alteracaoCadastralModel.UF = "RJ";
            alteracaoCadastralModel.Cidade = "Cidade1";
            alteracaoCadastralModel.Pais = "Brasil";
            alteracaoCadastralModel.Telefone1 = "XXXXXXX";
            alteracaoCadastralModel.Telefone2 = "XXXXXXX";
            alteracaoCadastralModel.Telefone3 = "XXXXXXXXXXX";
            alteracaoCadastralModel.Email = "aaa@aaa.caa";
            alteracaoCadastralModel.CategoriaHabilitacao = "AAC";
            alteracaoCadastralModel.DataVencimentoHabilitacao = DateTime.Now;
            alteracaoCadastralModel.BancoId = 20;
            alteracaoCadastralModel.Agencia = "AAAA";
            alteracaoCadastralModel.Conta = "0001254545-5";
            alteracaoCadastralModel.ContaBancariaTipoId = 2;

            var result = AlteracaoCadastralFacade.SolicitarAlteracao(alteracaoCadastralModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AprovarSolicitacaoAlteracao_SUCESS()
        {

            var result = AlteracaoCadastralFacade.AprovarSolicitacaoAlteracao(5);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ReprovarSolicitacalAlteracao_SUCESS()
        {

            var result = AlteracaoCadastralFacade.ReprovarSolicitacaoAlteracao(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
