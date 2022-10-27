using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository.Tests
{
    [TestClass]
    public class ColaboradorPagamentoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorPagamentoModel> _repositoryColaboradorPagamentoDadoPrincipalDefault;
        public static IColaboradorPagamentoRepository<ColaboradorPagamentoModel> _repositoryColaboradorPagamentoDadoPrincipalCustom;

        public ColaboradorPagamentoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorPagamentoDadoPrincipalDefault = new Repository<ColaboradorPagamentoModel>(_unitOfWork);
            _repositoryColaboradorPagamentoDadoPrincipalCustom = new ColaboradorPagamentoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaboradorPagamento_SUCESS()
        {
            var colaboradorPagamentoModel = new ColaboradorPagamentoModel();
            colaboradorPagamentoModel.ColaboradorId = 1;
            colaboradorPagamentoModel.BancoId = 0;
            colaboradorPagamentoModel.Agencia = "";
            colaboradorPagamentoModel.Conta = "";
            colaboradorPagamentoModel.ContaBancariaTipoId = 0;

            var result = _repositoryColaboradorPagamentoDadoPrincipalCustom.GetColaboradorPagamento(colaboradorPagamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ColaboradorPagamento_SUCESS()
        {
            var colaboradorPagamentoModel = new ColaboradorPagamentoModel();
            colaboradorPagamentoModel.ColaboradorId = 1;
            colaboradorPagamentoModel.BancoId = 20;
            colaboradorPagamentoModel.Agencia = "0001";
            colaboradorPagamentoModel.Conta = "0001248-5";
            colaboradorPagamentoModel.ContaBancariaTipoId = 1;
            colaboradorPagamentoModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorPagamentoDadoPrincipalDefault.Add(colaboradorPagamentoModel);

            _unitOfWork.Commit();
        }
    }
}
