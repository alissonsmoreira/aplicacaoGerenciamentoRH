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
    public class AlteracaoCadastralRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<AlteracaoCadastralModel> _repositoryAlteracaoCadastralDadoPrincipalDefault;
        public static IAlteracaoCadastralRepository<AlteracaoCadastralModel> _repositoryAlteracaoCadastralDadoPrincipalCustom;

        public AlteracaoCadastralRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryAlteracaoCadastralDadoPrincipalDefault = new Repository<AlteracaoCadastralModel>(_unitOfWork);
            _repositoryAlteracaoCadastralDadoPrincipalCustom = new AlteracaoCadastralRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetAlteracaoCadastralbyColaboradorId_SUCESS()
        {

            var result = _repositoryAlteracaoCadastralDadoPrincipalCustom.GetAlteracaoCadastralbyId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Solicitar_AlteracaoCadastral_SUCESS()
        {
            var alteracaoCadastralModel = new AlteracaoCadastralModel();
            alteracaoCadastralModel.ColaboradorId = 1;
            alteracaoCadastralModel.Nome = "Colaborador 1";
            alteracaoCadastralModel.Endereco = "Rua xxx";
            alteracaoCadastralModel.Numero = "20";
            alteracaoCadastralModel.Complemento = "";
            alteracaoCadastralModel.Bairro = "Bairro 1";
            alteracaoCadastralModel.CEP = "0000020";
            alteracaoCadastralModel.UF = "SP";
            alteracaoCadastralModel.Cidade = "Cidade1";
            alteracaoCadastralModel.Pais = "Brasil";
            alteracaoCadastralModel.Telefone1 = "(xx) 123545-2454";
            alteracaoCadastralModel.Telefone2 = "(xx)123545 - 24555";
            alteracaoCadastralModel.Telefone3 = "(xx) 123545-245466";
            alteracaoCadastralModel.Email = "aaa@aaa.caa";
            alteracaoCadastralModel.CategoriaHabilitacao = "B";
            alteracaoCadastralModel.DataVencimentoHabilitacao = DateTime.Now;
            alteracaoCadastralModel.BancoId = 20;
            alteracaoCadastralModel.Agencia = "0001";
            alteracaoCadastralModel.Conta = "0001248-5";
            alteracaoCadastralModel.ContaBancariaTipoId = 1;
            alteracaoCadastralModel.SolicitacaoStatusId = 1;
            alteracaoCadastralModel.DataSolicitacao = DateTime.Now;

            _repositoryAlteracaoCadastralDadoPrincipalDefault.Add(alteracaoCadastralModel);

            _unitOfWork.Commit();
        }
    }
}
