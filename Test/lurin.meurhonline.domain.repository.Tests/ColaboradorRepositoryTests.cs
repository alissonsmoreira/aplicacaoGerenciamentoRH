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
    public class ColaboradorRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorModel> _repositoryColaboradorDadoPrincipalDefault;
        public static IColaboradorRepository<ColaboradorModel> _repositoryColaboradorDadoPrincipalCustom;

        public ColaboradorRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorDadoPrincipalDefault = new Repository<ColaboradorModel>(_unitOfWork);
            _repositoryColaboradorDadoPrincipalCustom = new ColaboradorRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaborador_SUCESS()
        {
            var colaboradorModel = new ColaboradorModel();
            colaboradorModel.Nome = "Colaborador1";
            colaboradorModel.EmpresaId = 2;
            colaboradorModel.ColaboradorTipoId = 0;
            colaboradorModel.CPF = "";
            colaboradorModel.Sexo = "";
            colaboradorModel.Endereco = "";
            colaboradorModel.Endereco = "";
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


            var result = _repositoryColaboradorDadoPrincipalCustom.GetColaborador(colaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Colaborador_SUCESS()
        {
            var colaboradorModel = new ColaboradorModel();
            colaboradorModel.Nome = "Colaborador1";
            colaboradorModel.EmpresaId = 1;
            colaboradorModel.ColaboradorTipoId = 1;
            colaboradorModel.CPF = "123456789";
            colaboradorModel.Sexo = "Masculino";
            colaboradorModel.Endereco = "Rua xxx";
            colaboradorModel.Numero = "1234 A";
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
            colaboradorModel.FotoNome = "aaaaaa.jpg";
            colaboradorModel.GrauInstrucaoId = 5;
            colaboradorModel.EstadoCivilId = 1;
            colaboradorModel.ColaboradorStatusId = 1;
            colaboradorModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorDadoPrincipalDefault.Add(colaboradorModel);

            _unitOfWork.Commit();
        }
    }
}
