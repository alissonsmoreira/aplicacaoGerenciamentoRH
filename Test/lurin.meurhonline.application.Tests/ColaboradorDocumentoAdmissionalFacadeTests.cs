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
    public class ColaboradorDocumentoAdmissionalFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorDocumentoAdmissionalFacade ColaboradorDocumentoAdmissionalFacade;

        public ColaboradorDocumentoAdmissionalFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorDocumentoAdmissionalFacade = new ColaboradorDocumentoAdmissionalFacade();
        }

        [TestMethod]
        public void BuscarDocumentoAdmissionalColaborador_SUCESS()
        {
            var colaboradorDocumentoAdmissionalModel = new ColaboradorDocumentoAdmissionalModel();
            colaboradorDocumentoAdmissionalModel.ColaboradorId = 1;
            colaboradorDocumentoAdmissionalModel.DocumentoAdmissionalId = 0;

            var result = ColaboradorDocumentoAdmissionalFacade.BuscarDocumentoAdmissionalColaborador(colaboradorDocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }



        [TestMethod]
        [Ignore]
        public void AdicionarDocumentoAdmissionalColaborador_SUCESS()
        {
            var colaboradorDocumentoAdmissionalModel = new ColaboradorDocumentoAdmissionalModel();
            colaboradorDocumentoAdmissionalModel.ColaboradorId = 2;
            colaboradorDocumentoAdmissionalModel.DocumentoAdmissionalId = 1;
            colaboradorDocumentoAdmissionalModel.DocumentoBase64 = "AAAAAAAAAA";

            var result = ColaboradorDocumentoAdmissionalFacade.SalvarDocumentoAdmissionalColaborador(colaboradorDocumentoAdmissionalModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
