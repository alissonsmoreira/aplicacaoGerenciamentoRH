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
    public class ColaboradorDocumentacaoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorDocumentacaoFacade ColaboradorDocumentacaoFacade;

        public ColaboradorDocumentacaoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorDocumentacaoFacade = new ColaboradorDocumentacaoFacade();
        }

        [TestMethod]
        public void BuscarDocumentacaoColaborador_SUCESS()
        {
            var colaboradorDocumentacaoModel = new ColaboradorDocumentacaoModel();
            colaboradorDocumentacaoModel.ColaboradorId = 1;
            colaboradorDocumentacaoModel.RG = "125";
            colaboradorDocumentacaoModel.OrgaoEmissorRG = "";
            colaboradorDocumentacaoModel.UFEmissaoRG = "SP";
            colaboradorDocumentacaoModel.DataEmissaoRG = DateTime.MinValue;
            colaboradorDocumentacaoModel.RIC = "";
            colaboradorDocumentacaoModel.UFEmissaoRIC = "SP";
            colaboradorDocumentacaoModel.CidadeEmissaoRIC = "São Paulo";
            colaboradorDocumentacaoModel.DataExpedicaoRIC = DateTime.MinValue;
            colaboradorDocumentacaoModel.CartaoNacionalSaude = "";
            colaboradorDocumentacaoModel.NumeroReservista = "";
            colaboradorDocumentacaoModel.TituloEleitor = "";
            colaboradorDocumentacaoModel.ZonaEleitoral = "";
            colaboradorDocumentacaoModel.SecaoEleitoral = "";
            colaboradorDocumentacaoModel.UFEleitoral = "AC";
            colaboradorDocumentacaoModel.CidadeEleitoral = "";
            colaboradorDocumentacaoModel.CarteiraHabilitacao = "";
            colaboradorDocumentacaoModel.CategoriaHabilitacao = "B";
            colaboradorDocumentacaoModel.DataVencimentoHabilitacao = DateTime.MinValue;
            colaboradorDocumentacaoModel.NumeroCTPS = "";
            colaboradorDocumentacaoModel.SerieCTPS = "0";
            colaboradorDocumentacaoModel.UFCTPS = "SP";
            colaboradorDocumentacaoModel.DataEmissaoCTPS = DateTime.MinValue;
            colaboradorDocumentacaoModel.PISNITNIS = "";
            colaboradorDocumentacaoModel.DataEmissaoPISNITNIS = DateTime.MinValue;

            var result = ColaboradorDocumentacaoFacade.BuscarDocumentacaoColaborador(colaboradorDocumentacaoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }



        [TestMethod]
        [Ignore]
        public void AdicionarDocumentacaoColaborador_SUCESS()
        {
            var colaboradorDocumentacaoModel = new ColaboradorDocumentacaoModel();
            colaboradorDocumentacaoModel.ColaboradorId = 1;
            colaboradorDocumentacaoModel.RG = "1235";
            colaboradorDocumentacaoModel.OrgaoEmissorRG = "SSP";
            colaboradorDocumentacaoModel.UFEmissaoRG = "SP";
            colaboradorDocumentacaoModel.DataEmissaoRG = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.RIC = "1235";
            colaboradorDocumentacaoModel.UFEmissaoRIC = "SP";
            colaboradorDocumentacaoModel.CidadeEmissaoRIC = "São Paulo";
            colaboradorDocumentacaoModel.DataExpedicaoRIC = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.CartaoNacionalSaude = "12333";
            colaboradorDocumentacaoModel.NumeroReservista = "12345678";
            colaboradorDocumentacaoModel.TituloEleitor = "56789632";
            colaboradorDocumentacaoModel.ZonaEleitoral = "912";
            colaboradorDocumentacaoModel.SecaoEleitoral = "425";
            colaboradorDocumentacaoModel.UFEleitoral = "AC";
            colaboradorDocumentacaoModel.CidadeEleitoral = "Rio Branco";
            colaboradorDocumentacaoModel.CarteiraHabilitacao = "1234567";
            colaboradorDocumentacaoModel.CategoriaHabilitacao = "B";
            colaboradorDocumentacaoModel.DataVencimentoHabilitacao = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.NumeroCTPS = "125-A";
            colaboradorDocumentacaoModel.SerieCTPS = "001A";
            colaboradorDocumentacaoModel.UFCTPS = "SP";
            colaboradorDocumentacaoModel.DataEmissaoCTPS = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.PISNITNIS = "1234";
            colaboradorDocumentacaoModel.DataEmissaoPISNITNIS = Convert.ToDateTime("2000-01-01");

            var result = ColaboradorDocumentacaoFacade.AdicionarDocumentacaoColaborador(colaboradorDocumentacaoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarDocumentacaoColaborador_SUCESS()
        {
            var colaboradorDocumentacaoModel = new ColaboradorDocumentacaoModel();
            colaboradorDocumentacaoModel.Id = 1;
            colaboradorDocumentacaoModel.ColaboradorId = 1;
            colaboradorDocumentacaoModel.RG = "12345678911";
            colaboradorDocumentacaoModel.OrgaoEmissorRG = "SSP";
            colaboradorDocumentacaoModel.UFEmissaoRG = "RJ";
            colaboradorDocumentacaoModel.DataEmissaoRG = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.RIC = "";
            colaboradorDocumentacaoModel.UFEmissaoRIC = "MG";
            colaboradorDocumentacaoModel.CidadeEmissaoRIC = "";
            colaboradorDocumentacaoModel.DataExpedicaoRIC = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.CartaoNacionalSaude = "2458487480";
            colaboradorDocumentacaoModel.NumeroReservista = "";
            colaboradorDocumentacaoModel.TituloEleitor = "5465456";
            colaboradorDocumentacaoModel.ZonaEleitoral = "125";
            colaboradorDocumentacaoModel.SecaoEleitoral = "14";
            colaboradorDocumentacaoModel.UFEleitoral = "AC";
            colaboradorDocumentacaoModel.CidadeEleitoral = "";
            colaboradorDocumentacaoModel.CarteiraHabilitacao = "";
            colaboradorDocumentacaoModel.CategoriaHabilitacao = "B";
            colaboradorDocumentacaoModel.DataVencimentoHabilitacao = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.NumeroCTPS = "123333";
            colaboradorDocumentacaoModel.SerieCTPS = "454489";
            colaboradorDocumentacaoModel.UFCTPS = "SP";
            colaboradorDocumentacaoModel.DataEmissaoCTPS = Convert.ToDateTime("2000-01-01");
            colaboradorDocumentacaoModel.PISNITNIS = "";
            colaboradorDocumentacaoModel.DataEmissaoPISNITNIS = Convert.ToDateTime("2000-01-01");

            var result = ColaboradorDocumentacaoFacade.EditarDocumentacaoColaborador(colaboradorDocumentacaoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
