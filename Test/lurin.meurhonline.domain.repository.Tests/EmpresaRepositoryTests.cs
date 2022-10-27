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
    public class EmpresaRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<EmpresaModel> _repositoryEmpresaDefault;
        public static IRepository<EmpresaFuncionalidadeModel> _repositoryFuncionalidadeDefault;
        public static IEmpresaRepository<EmpresaModel> _repositoryEmpresaCustom;

        public EmpresaRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryEmpresaDefault = new Repository<EmpresaModel>(_unitOfWork);
            _repositoryFuncionalidadeDefault = new Repository<EmpresaFuncionalidadeModel>(_unitOfWork);

            _repositoryEmpresaCustom = new EmpresaRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetEmpresa_SUCESS()
        {
            var empresaModel = new EmpresaModel();
            empresaModel.Nome = "Empre";
            empresaModel.CNPJ = "1234";
            empresaModel.InscricaoEstadual = "";
            empresaModel.InscricaoMunicipal = "";
            empresaModel.Endereco = "";
            empresaModel.Numero = "";
            empresaModel.Bairro = "";
            empresaModel.CEP = "";
            empresaModel.UF = "";
            empresaModel.Cidade = "";
            empresaModel.TelefoneContato1 = "";
            empresaModel.EmailContato1 = "";
            empresaModel.TelefoneContato2 = "";
            empresaModel.EmailContato2 = "";
            empresaModel.TelefoneContato3 = "";
            empresaModel.EmailContato3 = "";

            var result = _repositoryEmpresaCustom.GetEmpresa(empresaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetEmpresaByNome_SUCESS()
        {
            var result = _repositoryEmpresaCustom.GetEmpresaByNome("Empre");

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetEmpresaGrupoByEmpresaId_SUCESS()
        {
            var result = _repositoryEmpresaCustom.GetEmpresaGrupoByEmpresaMatrizId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFuncionalidade_SUCESS()
        {
            var result = _repositoryFuncionalidadeDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Empresa_SUCESS()
        {
            var empresaModel = new EmpresaModel();
            empresaModel.Nome = "Empresa 1";
            empresaModel.CNPJ = "12345678910001";
            empresaModel.InscricaoEstadual = "123";
            empresaModel.InscricaoMunicipal = "456";
            empresaModel.Endereco = "Rua 123";
            empresaModel.Numero = "XX";
            empresaModel.Bairro = "Bairooo";
            empresaModel.CEP = "06000123";
            empresaModel.UF = "SP";
            empresaModel.Cidade = "São Paulo";
            empresaModel.TelefoneContato1 = "123";
            empresaModel.EmailContato1 = "email1@empresa1.com";
            empresaModel.TelefoneContato2 = "456";
            empresaModel.EmailContato2 = "email2@empresa1.com";
            empresaModel.TelefoneContato3 = "789";
            empresaModel.EmailContato3 = "email3@empresa1";
            empresaModel.EmpresaTipoId = 1;
            empresaModel.DataCadastro = DateTime.Now;

            _repositoryEmpresaDefault.Add(empresaModel);

            _unitOfWork.Commit();
        }
    }
}
