using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.model.enumerator;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class EmpresaFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static EmpresaFacade EmpresaFacade;

        public EmpresaFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            EmpresaFacade = new EmpresaFacade();
        }

        [TestMethod]
        public void BuscarEmpresa_SUCESS()
        {
            var empresaModel = new EmpresaModel();
            empresaModel.Nome = "";
            empresaModel.CNPJ = "";
            empresaModel.InscricaoEstadual = "";
            empresaModel.InscricaoMunicipal = "";
            empresaModel.Endereco   = "";
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
            empresaModel.EmpresaTipoId = 0;
            empresaModel.EmpresaMatrizId = 0;

            var result = EmpresaFacade.BuscarEmpresa(empresaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarEmpresaFuncionalidade_SUCESS()
        {
            var result = EmpresaFacade.BuscarEmpresaFuncionalidade();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarEmpresaGrupoByEmpresaId_SUCESS()
        {
            var result = EmpresaFacade.BuscarEmpresaGrupoPorIdEmpresa(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarEmpresa_SUCESS()
        {
            var empresaModel = new EmpresaModel();
            empresaModel.Nome = "Emmmmm";
            empresaModel.CNPJ = "454678998211679";
            empresaModel.InscricaoEstadual = "11";
            empresaModel.InscricaoMunicipal = "555";
            empresaModel.Endereco = "Rua xXXX";
            empresaModel.Numero = "185-B";
            empresaModel.Bairro = "Bairoo";
            empresaModel.CEP = "000000";
            empresaModel.UF = "AC";
            empresaModel.Cidade = "Rio Branco";
            empresaModel.TelefoneContato1 = "(xx) 1234-5789";
            empresaModel.EmailContato1 = "aaa@emaiol.com";
            empresaModel.TelefoneContato2 = "";
            empresaModel.EmailContato2 = "";
            empresaModel.TelefoneContato3 = "";
            empresaModel.EmailContato3 = "";
            empresaModel.EmpresaTipoId = 2;
            empresaModel.EmpresaStatusId = 1;
            empresaModel.EmpresaMatrizId = 1;

            var result = EmpresaFacade.AdicionarEmpresa(empresaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarEmpresaDocumentoAdmissional_SUCESS()
        {
            var empresaDocumento = new List<EmpresaDocumentoAdmissionalModel>();

            var empresaDocumentoAdmissionalModel = new EmpresaDocumentoAdmissionalModel();
            empresaDocumentoAdmissionalModel.EmpresaId = 1;
            empresaDocumentoAdmissionalModel.DocumentoAdmissionalId = 1;
            
            empresaDocumento.Add(empresaDocumentoAdmissionalModel);

            var result = EmpresaFacade.AdicionarEmpresaDocumentoAdmissional(empresaDocumento);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarEmpresaFuncionalidade_SUCESS()
        {
            var empresaFuncionalidades = new List<EmpresaEmpresaFuncionalidadeModel>();

            var empresaEmpresaFuncionalidadeModel = new EmpresaEmpresaFuncionalidadeModel();
            empresaEmpresaFuncionalidadeModel.EmpresaId = 1;
            empresaEmpresaFuncionalidadeModel.EmpresaFuncionalidadeId = 6;

            empresaFuncionalidades.Add(empresaEmpresaFuncionalidadeModel);

            var result = EmpresaFacade.AdicionarEmpresaFuncionalidade(empresaFuncionalidades);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarEmpresaFuncionalidade_SUCESS()
        {
            var empresaFuncionalidades = new List<EmpresaEmpresaFuncionalidadeModel>();

            var empresaEmpresaFuncionalidadeModel = new EmpresaEmpresaFuncionalidadeModel();
            empresaEmpresaFuncionalidadeModel.EmpresaId = 1;
            empresaEmpresaFuncionalidadeModel.EmpresaFuncionalidadeId = 6;

            empresaFuncionalidades.Add(empresaEmpresaFuncionalidadeModel);

            var result = EmpresaFacade.EditarEmpresaFuncionalidade(empresaFuncionalidades);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarEmpresa_SUCESS()
        {
            var empresaModel = new EmpresaModel();
            empresaModel.Id = 2;
            empresaModel.Nome = "Empresa 555";
            empresaModel.CNPJ = "4546789982";
            empresaModel.InscricaoEstadual = "11";
            empresaModel.InscricaoMunicipal = "555";
            empresaModel.Endereco = "Rua xXXX";
            empresaModel.Numero = "185-B";
            empresaModel.Bairro = "Bairoo";
            empresaModel.CEP = "000000";
            empresaModel.UF = "AC";
            empresaModel.Cidade = "Rio Branco";
            empresaModel.TelefoneContato1 = "(xx) 1234-5789";
            empresaModel.EmailContato1 = "aaa@emaiol.com";
            empresaModel.TelefoneContato2 = "";
            empresaModel.EmailContato2 = "";
            empresaModel.TelefoneContato3 = "";
            empresaModel.EmailContato3 = "";
            empresaModel.EmpresaTipoId = 1;

            var result = EmpresaFacade.EditarEmpresa(empresaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
