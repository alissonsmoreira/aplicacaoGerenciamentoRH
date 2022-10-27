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
    public class ColaboradorFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorFacade ColaboradorDadoPrincipalFacade;

        public ColaboradorFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorDadoPrincipalFacade = new ColaboradorFacade();
        }

        [TestMethod]
        public void BuscarColaboradorDadoPrincipal_SUCESS()
        {
            var colaboradorModel = new ColaboradorModel();
            colaboradorModel.Nome = "Colaborador1";
            colaboradorModel.EmpresaId = 2;
            colaboradorModel.ColaboradorTipoId = 0;
            colaboradorModel.CPF = "";
            colaboradorModel.Sexo = "";
            colaboradorModel.Endereco = "";
            colaboradorModel.Numero = "";
            colaboradorModel.Complemento = "";
            colaboradorModel.Bairro = "";
            colaboradorModel.CEP = "";
            colaboradorModel.UF = "";
            colaboradorModel.Cidade = "";
            colaboradorModel.DataNascimento = DateTime.MinValue; // Convert.ToDateTime("2000-01-01");
            colaboradorModel.Telefone1 = "";
            colaboradorModel.Telefone2 = "";
            colaboradorModel.Telefone3 = "";
            colaboradorModel.Email = "";
            colaboradorModel.NomePai = "";
            colaboradorModel.NomeMae = "";
            colaboradorModel.MatriculaInterna = "";
            colaboradorModel.MatriculaeSocial = "";
            colaboradorModel.PaisNascimento = "";
            colaboradorModel.UFNascimento = "";
            colaboradorModel.CidadeNascimento = "";
            colaboradorModel.GrauInstrucaoId = 0;
            colaboradorModel.EstadoCivilId = 0;
            colaboradorModel.ColaboradorStatusId = 0;

            var result = ColaboradorDadoPrincipalFacade.BuscarColaboradorDadoPrincipal(colaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarColaboradorPorGestorId_SUCESS()
        {
           
            var result = ColaboradorDadoPrincipalFacade.BuscarColaboradorPorGestorId(11);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarColaboradorDadoPrincipal_SUCESS()
        {
            var colaboradorModel = new ColaboradorModel();
            colaboradorModel.Nome = "LIGIA VARANELLI DE SOUZA";
            colaboradorModel.EmpresaId = 2;
            colaboradorModel.ColaboradorTipoId = 1;
            colaboradorModel.CPF = "0000123345";
            colaboradorModel.Sexo = "Masculino";
            colaboradorModel.Endereco = "Rua xxx";
            colaboradorModel.Endereco = "123 A";
            colaboradorModel.Complemento = "";
            colaboradorModel.Bairro = "Bairro 1";
            colaboradorModel.CEP = "01234-123";
            colaboradorModel.UF = "SP";
            colaboradorModel.Cidade = "São Paulo";
            colaboradorModel.DataNascimento = Convert.ToDateTime("2000-01-01");
            colaboradorModel.Telefone1 = "1234-5678";
            colaboradorModel.Telefone2 = "5678-9632";
            colaboradorModel.Telefone3 = "91234-5897";
            colaboradorModel.Email = "teste@123.com";
            colaboradorModel.NomePai = "Pai";
            colaboradorModel.NomeMae = "Mãe";
            colaboradorModel.MatriculaInterna = "2925";
            colaboradorModel.MatriculaeSocial = "000013333";
            colaboradorModel.PaisNascimento = "Brasil";
            colaboradorModel.UFNascimento = "SP";
            colaboradorModel.CidadeNascimento = "São Paulo";
            colaboradorModel.GrauInstrucaoId = 5;
            colaboradorModel.EstadoCivilId = 1;
            colaboradorModel.ColaboradorStatusId = 1;

            var result = ColaboradorDadoPrincipalFacade.AdicionarColaboradorDadoPrincipal(colaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarColaboradorDadoPrincipal_SUCESS()
        {
            var colaboradorModel = new ColaboradorModel();
            colaboradorModel.Id = 2;
            colaboradorModel.Nome = "Colaborador222";
            colaboradorModel.EmpresaId = 2;
            colaboradorModel.ColaboradorTipoId = 2;
            colaboradorModel.CPF = "00001233";
            colaboradorModel.Sexo = "Masculino";
            colaboradorModel.Endereco = "Rua xxx";
            colaboradorModel.Numero = "Numero xxx";
            colaboradorModel.Complemento = "";
            colaboradorModel.Bairro = "Bairro 1";
            colaboradorModel.CEP = "01234-123";
            colaboradorModel.UF = "SP";
            colaboradorModel.Cidade = "São Paulo";
            colaboradorModel.DataNascimento = Convert.ToDateTime("2000-01-01");
            colaboradorModel.Telefone1 = "1234-5678";
            colaboradorModel.Telefone2 = "5678-9632";
            colaboradorModel.Telefone3 = "91234-5897";
            colaboradorModel.Email = "teste@123.com";
            colaboradorModel.NomePai = "Pai";
            colaboradorModel.NomeMae = "Mãe";
            colaboradorModel.MatriculaInterna = "1234567";
            colaboradorModel.MatriculaeSocial = "000013333";
            colaboradorModel.PaisNascimento = "Brasil";
            colaboradorModel.UFNascimento = "SP";
            colaboradorModel.CidadeNascimento = "São Paulo";
            colaboradorModel.GrauInstrucaoId = 5;
            colaboradorModel.EstadoCivilId = 3;
            colaboradorModel.ColaboradorStatusId = 1;

            var result = ColaboradorDadoPrincipalFacade.EditarColaboradorDadoPrincipal(colaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarColaboradorPorNome_SUCESS()
        {

            var result = ColaboradorDadoPrincipalFacade.BuscarColaboradorPorNome("Colaborador");

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarColaboradorPreAdmissaoPorNome_SUCESS()
        {

            var result = ColaboradorDadoPrincipalFacade.BuscarColaboradorPreAdmissaoPorNome("Colaborador");

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
