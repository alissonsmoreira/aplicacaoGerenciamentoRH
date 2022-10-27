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
    public class ColaboradorDocumentacaoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorDocumentacaoModel> _repositoryColaboradorDocumentacaoDadoPrincipalDefault;
        public static IColaboradorDocumentacaoRepository<ColaboradorDocumentacaoModel> _repositoryColaboradorDocumentacaoDadoPrincipalCustom;

        public ColaboradorDocumentacaoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorDocumentacaoDadoPrincipalDefault = new Repository<ColaboradorDocumentacaoModel>(_unitOfWork);
            _repositoryColaboradorDocumentacaoDadoPrincipalCustom = new ColaboradorDocumentacaoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaboradorDocumentacao_SUCESS()
        {
            var colaboradorDocumentacaoModel = new ColaboradorDocumentacaoModel();
            colaboradorDocumentacaoModel.ColaboradorId = 1;
            colaboradorDocumentacaoModel.RG = "12345678911";
            colaboradorDocumentacaoModel.OrgaoEmissorRG = "";
            colaboradorDocumentacaoModel.UFEmissaoRG = "";
            colaboradorDocumentacaoModel.DataEmissaoRG = DateTime.MinValue;
            colaboradorDocumentacaoModel.RIC = "";
            colaboradorDocumentacaoModel.UFEmissaoRIC = "";
            colaboradorDocumentacaoModel.CidadeEmissaoRIC = "";
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
            colaboradorDocumentacaoModel.SerieCTPS = "";
            colaboradorDocumentacaoModel.UFCTPS = "SP";
            colaboradorDocumentacaoModel.DataEmissaoCTPS = DateTime.MinValue;
            colaboradorDocumentacaoModel.PISNITNIS = "";
            colaboradorDocumentacaoModel.DataEmissaoPISNITNIS = DateTime.MinValue;


            var result = _repositoryColaboradorDocumentacaoDadoPrincipalCustom.GetColaboradorDocumentacao(colaboradorDocumentacaoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ColaboradorDocumentacao_SUCESS()
        {
            var colaboradorDocumentacaoModel = new ColaboradorDocumentacaoModel();
            colaboradorDocumentacaoModel.ColaboradorId = 1;
            colaboradorDocumentacaoModel.RG = "12345678911";
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
            colaboradorDocumentacaoModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorDocumentacaoDadoPrincipalDefault.Add(colaboradorDocumentacaoModel);

            _unitOfWork.Commit();
        }
    }
}
