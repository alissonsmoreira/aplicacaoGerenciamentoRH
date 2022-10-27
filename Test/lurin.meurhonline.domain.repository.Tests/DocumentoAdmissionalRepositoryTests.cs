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
    public class DocumentoAdmissionalRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static IDocumentoAdmissionalRepository<DocumentoAdmissionalModel> DocumentoAdmissionalRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<DocumentoAdmissionalModel> _repositoryDocumentoAdmissionalDefault;
        public static IDocumentoAdmissionalRepository<DocumentoAdmissionalModel> _repositoryDocumentoAdmissionalCustom;

        public DocumentoAdmissionalRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryDocumentoAdmissionalDefault = new Repository<DocumentoAdmissionalModel>(_unitOfWork);
            _repositoryDocumentoAdmissionalCustom = new DocumentoAdmissionalRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetDocumentoAdmissional_SUCESS()
        {
            var DocumentoAdmissionalModel = new DocumentoAdmissionalModel();
            DocumentoAdmissionalModel.Nome = "Certidão";

            var result = _repositoryDocumentoAdmissionalCustom.GetDocumentoAdmissional(DocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllDocumentoAdmissional_SUCESS()
        {
            var result = _repositoryDocumentoAdmissionalDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_DocumentoAdmissional_SUCESS()
        {
            var DocumentoAdmissionalModel = new DocumentoAdmissionalModel();
            DocumentoAdmissionalModel.Nome = "CPF";
            DocumentoAdmissionalModel.DataCadastro = DateTime.Now;

            _repositoryDocumentoAdmissionalDefault.Add(DocumentoAdmissionalModel);

            _unitOfWork.Commit();
        }

        [TestMethod]
        public void GetDocumentoAdmissionalPadrao_SUCESS()
        {
            var result = _repositoryDocumentoAdmissionalCustom.GetDocumentoAdmissionalPadrao();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
