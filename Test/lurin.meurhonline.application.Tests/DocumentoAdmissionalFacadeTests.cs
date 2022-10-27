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
    public class DocumentoAdmissionalFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static DocumentoAdmissionalFacade DocumentoAdmissionalFacade;

        public DocumentoAdmissionalFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            DocumentoAdmissionalFacade = new DocumentoAdmissionalFacade();
        }

        [TestMethod]
        public void BuscarDocumentoAdmissional_SUCESS()
        {
            var DocumentoAdmissionalModel = new DocumentoAdmissionalModel();
            DocumentoAdmissionalModel.Nome = "An";

            var result = DocumentoAdmissionalFacade.BuscarDocumentoAdmissional(DocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudoDocumentoAdmissional_SUCESS()
        {

            var result = DocumentoAdmissionalFacade.BuscarTudoDocumentoAdmissional();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarDocumentoAdmissional_SUCESS()
        {
            var DocumentoAdmissionalModel = new DocumentoAdmissionalModel();
            DocumentoAdmissionalModel.Nome = "Carteira de Habilitação";

            var result = DocumentoAdmissionalFacade.AdicionarDocumentoAdmissional(DocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarDocumentoAdmissional_SUCESS()
        {
            var DocumentoAdmissionalModel = new DocumentoAdmissionalModel();
            DocumentoAdmissionalModel.Id = 2;
            DocumentoAdmissionalModel.Nome = "CNH";

            var result = DocumentoAdmissionalFacade.EditarDocumentoAdmissional(DocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirDocumentoAdmissional_SUCESS()
        {
            var result = DocumentoAdmissionalFacade.ExcluirDocumentoAdmissional(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
