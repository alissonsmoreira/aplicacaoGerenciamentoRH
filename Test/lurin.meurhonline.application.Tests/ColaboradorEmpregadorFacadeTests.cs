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
    public class ColaboradorEmpregadorFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ColaboradorEmpregadorFacade ColaboradorEmpregadorFacade;

        public ColaboradorEmpregadorFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            ColaboradorEmpregadorFacade = new ColaboradorEmpregadorFacade();
        }

        [TestMethod]
        public void BuscarEmpregadorColaborador_SUCESS()
        {
            var colaboradorEmpregadorModel = new ColaboradorEmpregadorModel();
            colaboradorEmpregadorModel.ColaboradorId = 1;
            colaboradorEmpregadorModel.CargoUnidadeId = 0;
            colaboradorEmpregadorModel.CentroCustoUnidadeId = 0;
            colaboradorEmpregadorModel.LotacaoUnidadeId = 0;
            colaboradorEmpregadorModel.TipoRegistroId = 0;
            colaboradorEmpregadorModel.TipoMaoObraId = 0;
            colaboradorEmpregadorModel.UnidadeNegocioId = 0;
            colaboradorEmpregadorModel.NumeroCartaoPonto = "";
            colaboradorEmpregadorModel.Situacao = "Ativo";
            colaboradorEmpregadorModel.TurnoId = 0;
            colaboradorEmpregadorModel.CategoriaSalarialId = 0;
            colaboradorEmpregadorModel.Salario = Convert.ToDecimal(0);
            colaboradorEmpregadorModel.DataAdmissao = DateTime.MinValue;
            colaboradorEmpregadorModel.SindicatoId = 0;

            var result = ColaboradorEmpregadorFacade.BuscarEmpregadorColaborador(colaboradorEmpregadorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarEmpregadorColaboradorPorGestorId_SUCESS()
        {

            var result = ColaboradorEmpregadorFacade.BuscarColaboradorEmpregadorPorGestorId(11);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AdicionarEmpregadorColaborador_SUCESS()
        {
            var colaboradorEmpregadorModel = new ColaboradorEmpregadorModel();
            colaboradorEmpregadorModel.ColaboradorId = 1;
            colaboradorEmpregadorModel.CargoUnidadeId = 1;
            colaboradorEmpregadorModel.CentroCustoUnidadeId = 1;
            colaboradorEmpregadorModel.LotacaoUnidadeId = 1;
            colaboradorEmpregadorModel.TipoRegistroId = 1;
            colaboradorEmpregadorModel.TipoMaoObraId = 1;
            colaboradorEmpregadorModel.UnidadeNegocioId = 1;
            colaboradorEmpregadorModel.NumeroCartaoPonto = "T125487";
            colaboradorEmpregadorModel.Situacao = "Ativo";
            colaboradorEmpregadorModel.TurnoId = 1;
            colaboradorEmpregadorModel.CategoriaSalarialId = 1;
            colaboradorEmpregadorModel.Salario = Convert.ToDecimal(1000);
            colaboradorEmpregadorModel.DataAdmissao = Convert.ToDateTime("2000-01-01");
            colaboradorEmpregadorModel.SindicatoId = 1;

            var result = ColaboradorEmpregadorFacade.AdicionarEmpregadorColaborador(colaboradorEmpregadorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarEmpregadorColaborador_SUCESS()
        {
            var colaboradorEmpregadorModel = new ColaboradorEmpregadorModel();
            colaboradorEmpregadorModel.Id = 5;
            colaboradorEmpregadorModel.ColaboradorId = 1;
            colaboradorEmpregadorModel.CargoUnidadeId = 1;
            colaboradorEmpregadorModel.CentroCustoUnidadeId = 1;
            colaboradorEmpregadorModel.LotacaoUnidadeId = 1;
            colaboradorEmpregadorModel.TipoRegistroId = 1;
            colaboradorEmpregadorModel.TipoMaoObraId = 1;
            colaboradorEmpregadorModel.UnidadeNegocioId = 1;
            colaboradorEmpregadorModel.NumeroCartaoPonto = "T125487";
            colaboradorEmpregadorModel.Situacao = "Inativo";
            colaboradorEmpregadorModel.TurnoId = 1;
            colaboradorEmpregadorModel.CategoriaSalarialId = 1;
            colaboradorEmpregadorModel.Salario = Convert.ToDecimal(1000);
            colaboradorEmpregadorModel.DataAdmissao = Convert.ToDateTime("2000-01-01");
            colaboradorEmpregadorModel.SindicatoId = 1;

            var result = ColaboradorEmpregadorFacade.EditarEmpregadorColaborador(colaboradorEmpregadorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

    }
}
