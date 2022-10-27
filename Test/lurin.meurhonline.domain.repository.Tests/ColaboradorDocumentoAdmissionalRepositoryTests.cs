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
    public class ColaboradorDocumentoAdmissionalRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorDocumentoAdmissionalModel> _repositoryColaboradorDocumentoAdmissionalDadoPrincipalDefault;
        public static IColaboradorDocumentoAdmissionalRepository<ColaboradorDocumentoAdmissionalModel> _repositoryColaboradorDocumentoAdmissionalDadoPrincipalCustom;

        public ColaboradorDocumentoAdmissionalRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorDocumentoAdmissionalDadoPrincipalDefault = new Repository<ColaboradorDocumentoAdmissionalModel>(_unitOfWork);
            _repositoryColaboradorDocumentoAdmissionalDadoPrincipalCustom = new ColaboradorDocumentoAdmissionalRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaboradorDocumentoAdmissional_SUCESS()
        {
            var colaboradorDocumentoAdmissionalModel = new ColaboradorDocumentoAdmissionalModel();
            colaboradorDocumentoAdmissionalModel.ColaboradorId = 1;
            colaboradorDocumentoAdmissionalModel.DocumentoAdmissionalId = 0;

            var result = _repositoryColaboradorDocumentoAdmissionalDadoPrincipalCustom.GetColaboradorDocumentoAdmissional(colaboradorDocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ColaboradorDocumentoAdmissional_SUCESS()
        {
            var colaboradorDocumentoAdmissionalModel = new ColaboradorDocumentoAdmissionalModel();
            colaboradorDocumentoAdmissionalModel.ColaboradorId = 1;
            colaboradorDocumentoAdmissionalModel.DocumentoAdmissionalId = 3;
            colaboradorDocumentoAdmissionalModel.DocumentoNome = "AAAAAA.jpg";
            colaboradorDocumentoAdmissionalModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorDocumentoAdmissionalDadoPrincipalDefault.Add(colaboradorDocumentoAdmissionalModel);

            _unitOfWork.Commit();
        }
    }
}
