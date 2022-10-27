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
    public class DependenteFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static DependenteFacade DependenteFacade;

        public DependenteFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            DependenteFacade = new DependenteFacade();
        }

        [TestMethod]
        public void BuscarDependente_SUCESS()
        {
            var dependenteModel = new DependenteModel();
            dependenteModel.Nome = "Depe";
            dependenteModel.CPF = "";
            dependenteModel.Sexo = "Masc";
            dependenteModel.DataNascimento = Convert.ToDateTime("2000-01-01");
            dependenteModel.NomeMae = "";
            dependenteModel.GrauDependencia = "";
            dependenteModel.DocumentoNome = "";
            dependenteModel.ColaboradorId = 0;

            var result = DependenteFacade.BuscarDependente(dependenteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarDependentebyIds_SUCESS()
        {
            int[] dependenteIds = new int[] { 1, 2, 4 };

            var result = DependenteFacade.BuscarDependentePorIds(dependenteIds);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarDependente_SUCESS()
        {
            var dependenteModel = new DependenteModel();
            dependenteModel.Nome = "Dependente 2";
            dependenteModel.CPF = "123456789101";
            dependenteModel.Sexo = "Feminino";
            dependenteModel.DataNascimento = Convert.ToDateTime("2000-10-01");
            dependenteModel.NomeMae = "Fulana";
            dependenteModel.GrauDependencia = "Conjuge";
            dependenteModel.DocumentoNome = @"123.jpg";
            dependenteModel.ColaboradorId = 1;
   
            var result = DependenteFacade.AdicionarDependente(dependenteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarDependente_SUCESS()
        {
            var dependenteModel = new DependenteModel();
            dependenteModel.Id = 2;
            dependenteModel.Nome = "Dependente 3";
            dependenteModel.CPF = "123456789101";
            dependenteModel.Sexo = "Masculino";
            dependenteModel.DataNascimento = Convert.ToDateTime("2000-01-01");
            dependenteModel.NomeMae = "Beltrana";
            dependenteModel.GrauDependencia = "Filha";
            dependenteModel.DocumentoNome = @"123.jpg";
            dependenteModel.ColaboradorId = 1;

            var result = DependenteFacade.EditarDependente(dependenteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirDependente_SUCESS()
        {
            var result = DependenteFacade.ExcluirDependente(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
