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
    public class ColaboradorEstrangeiroRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorEstrangeiroModel> _repositoryColaboradorEstrangeiroDadoPrincipalDefault;
        public static IColaboradorEstrangeiroRepository<ColaboradorEstrangeiroModel> _repositoryColaboradorEstrangeiroDadoPrincipalCustom;

        public ColaboradorEstrangeiroRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorEstrangeiroDadoPrincipalDefault = new Repository<ColaboradorEstrangeiroModel>(_unitOfWork);
            _repositoryColaboradorEstrangeiroDadoPrincipalCustom = new ColaboradorEstrangeiroRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaboradorEstrangeiro_SUCESS()
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


            var result = _repositoryColaboradorEstrangeiroDadoPrincipalCustom.GetColaboradorEstrangeiro(colaboradorEstrangeiroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ColaboradorEstrangeiro_SUCESS()
        {
            var colaboradorEstrangeiroModel = new ColaboradorEstrangeiroModel();
            colaboradorEstrangeiroModel.ColaboradorId = 1;
            colaboradorEstrangeiroModel.Origem = "Portugal";
            colaboradorEstrangeiroModel.ColaboradorEstrangeiroTipoVistoId = 1;
            colaboradorEstrangeiroModel.Passaporte = "2454654";
            colaboradorEstrangeiroModel.OrgaoEmissorPassaporte = "SSP";
            colaboradorEstrangeiroModel.PaisEmissorPassaporte = "PT";
            colaboradorEstrangeiroModel.UFPassaporte = "AB";
            colaboradorEstrangeiroModel.DataEmissaoPassaporte = Convert.ToDateTime("2000-01-01");
            colaboradorEstrangeiroModel.PortariaNaturalizacao = "AB44822";
            colaboradorEstrangeiroModel.IdentidadeEstrangeira = "4446";
            colaboradorEstrangeiroModel.ValidadeIdentidadeEstrangeira = "2025";
            colaboradorEstrangeiroModel.AnoChegada = "2000";
            colaboradorEstrangeiroModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorEstrangeiroDadoPrincipalDefault.Add(colaboradorEstrangeiroModel);

            _unitOfWork.Commit();
        }
    }
}
