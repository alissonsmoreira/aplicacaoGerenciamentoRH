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
    public class ColaboradorEstrangeiroFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorEstrangeiroFacade ColaboradorEstrangeiroFacade;

        public ColaboradorEstrangeiroFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorEstrangeiroFacade = new ColaboradorEstrangeiroFacade();
        }

        [TestMethod]
        public void BuscarEstrangeiroColaborador_SUCESS()
        {
            var colaboradorEstrangeiroModel = new ColaboradorEstrangeiroModel();
            colaboradorEstrangeiroModel.ColaboradorId = 1;
            colaboradorEstrangeiroModel.Origem = "";
            colaboradorEstrangeiroModel.ColaboradorEstrangeiroTipoVistoId = 0;
            colaboradorEstrangeiroModel.Passaporte = "";
            colaboradorEstrangeiroModel.OrgaoEmissorPassaporte = "";
            colaboradorEstrangeiroModel.PaisEmissorPassaporte = "";
            colaboradorEstrangeiroModel.UFPassaporte = "";
            colaboradorEstrangeiroModel.DataEmissaoPassaporte = DateTime.MinValue;
            colaboradorEstrangeiroModel.PortariaNaturalizacao = "";
            colaboradorEstrangeiroModel.IdentidadeEstrangeira = "";
            colaboradorEstrangeiroModel.ValidadeIdentidadeEstrangeira = "";
            colaboradorEstrangeiroModel.AnoChegada = "";

            var result = ColaboradorEstrangeiroFacade.BuscarEstrangeiroColaborador(colaboradorEstrangeiroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudpEstrangeiroColaboradorTipoVisto_SUCESS()
        {
            var result = ColaboradorEstrangeiroFacade.BuscarTudoEstrangeiroColaboradorTipoVisto();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarEstrangeiroColaborador_SUCESS()
        {
            var colaboradorEstrangeiroModel = new ColaboradorEstrangeiroModel();
            colaboradorEstrangeiroModel.ColaboradorId = 2;
            colaboradorEstrangeiroModel.Origem = "Italia";
            colaboradorEstrangeiroModel.ColaboradorEstrangeiroTipoVistoId = 1;
            colaboradorEstrangeiroModel.Passaporte = "2454654";
            colaboradorEstrangeiroModel.OrgaoEmissorPassaporte = "SSP";
            colaboradorEstrangeiroModel.PaisEmissorPassaporte = "ITA";
            colaboradorEstrangeiroModel.UFPassaporte = "AB";
            colaboradorEstrangeiroModel.DataEmissaoPassaporte = Convert.ToDateTime("2000-01-01");
            colaboradorEstrangeiroModel.PortariaNaturalizacao = "AB44822";
            colaboradorEstrangeiroModel.IdentidadeEstrangeira = "4446";
            colaboradorEstrangeiroModel.ValidadeIdentidadeEstrangeira = "2025";
            colaboradorEstrangeiroModel.AnoChegada = "2000";

            var result = ColaboradorEstrangeiroFacade.AdicionarEstrangeiroColaborador(colaboradorEstrangeiroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarEstrangeiroColaborador_SUCESS()
        {
            var colaboradorEstrangeiroModel = new ColaboradorEstrangeiroModel();
            colaboradorEstrangeiroModel.ColaboradorId = 1;
            colaboradorEstrangeiroModel.Origem = "Alemanha";
            colaboradorEstrangeiroModel.ColaboradorEstrangeiroTipoVistoId = 1;
            colaboradorEstrangeiroModel.Passaporte = "2454654";
            colaboradorEstrangeiroModel.OrgaoEmissorPassaporte = "SSP";
            colaboradorEstrangeiroModel.PaisEmissorPassaporte = "ALE";
            colaboradorEstrangeiroModel.UFPassaporte = "AB";
            colaboradorEstrangeiroModel.DataEmissaoPassaporte = Convert.ToDateTime("2000-01-01");
            colaboradorEstrangeiroModel.PortariaNaturalizacao = "AB44822";
            colaboradorEstrangeiroModel.IdentidadeEstrangeira = "4446";
            colaboradorEstrangeiroModel.ValidadeIdentidadeEstrangeira = "2025";
            colaboradorEstrangeiroModel.AnoChegada = "2000";

            var result = ColaboradorEstrangeiroFacade.EditarEstrangeiroColaborador(colaboradorEstrangeiroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
