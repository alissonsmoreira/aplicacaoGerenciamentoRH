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
    public class DependenteRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<DependenteModel> _repositoryDependenteDefault;
        public static IDependenteRepository<DependenteModel> _repositoryDependenteCustom;

        public DependenteRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryDependenteDefault = new Repository<DependenteModel>(_unitOfWork);
            _repositoryDependenteCustom = new DependenteRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetDependente_SUCESS()
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

            var result = _repositoryDependenteCustom.GetDependente(dependenteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDependenteByIds_SUCESS()
        {
            int[] dependenteIds = new int[] {1,2,4 };

            var result = _repositoryDependenteCustom.GetDependentebyIds(dependenteIds);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Dependente_SUCESS()
        {
            var dependenteModel = new DependenteModel();
            dependenteModel.Nome = "Dependente 1";
            dependenteModel.CPF = "123456789101";
            dependenteModel.Sexo= "Masculino";
            dependenteModel.DataNascimento = Convert.ToDateTime("2000-01-01");
            dependenteModel.NomeMae = "Mãe";
            dependenteModel.GrauDependencia= "Filho";
            dependenteModel.DocumentoNome = @"C:\teste\123.jpg";
            dependenteModel.ColaboradorId = 1;
            dependenteModel.DataCadastro = DateTime.Now;

            _repositoryDependenteDefault.Add(dependenteModel);

            _unitOfWork.Commit();
        }
    }
}
