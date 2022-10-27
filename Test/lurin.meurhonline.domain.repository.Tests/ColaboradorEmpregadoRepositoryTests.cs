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
    public class ColaboradorEmpregadorRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ColaboradorEmpregadorModel> _repositoryColaboradorEmpregadorDadoPrincipalDefault;
        public static IColaboradorEmpregadorRepository<ColaboradorEmpregadorModel> _repositoryColaboradorEmpregadorDadoPrincipalCustom;

        public ColaboradorEmpregadorRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryColaboradorEmpregadorDadoPrincipalDefault = new Repository<ColaboradorEmpregadorModel>(_unitOfWork);
            _repositoryColaboradorEmpregadorDadoPrincipalCustom = new ColaboradorEmpregadorRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetColaboradorEmpregador_SUCESS()
        {
            var colaboradorEmpregadorModel = new ColaboradorEmpregadorModel();
            colaboradorEmpregadorModel.ColaboradorId = 1;
            colaboradorEmpregadorModel.CargoUnidadeId = 0;
            colaboradorEmpregadorModel.CentroCustoUnidadeId = 0;
            colaboradorEmpregadorModel.LotacaoUnidadeId =0;
            colaboradorEmpregadorModel.TipoRegistroId = 0;
            colaboradorEmpregadorModel.TipoMaoObraId = 0;
            colaboradorEmpregadorModel.UnidadeNegocioId = 0;
            colaboradorEmpregadorModel.NumeroCartaoPonto = "";
            colaboradorEmpregadorModel.Situacao = "";
            colaboradorEmpregadorModel.TurnoId = 0;
            colaboradorEmpregadorModel.CategoriaSalarialId = 0;
            colaboradorEmpregadorModel.Salario = Convert.ToDecimal(0);
            colaboradorEmpregadorModel.DataAdmissao = DateTime.MinValue;
            colaboradorEmpregadorModel.SindicatoId = 1;


            var result = _repositoryColaboradorEmpregadorDadoPrincipalCustom.GetColaboradorEmpregador(colaboradorEmpregadorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ColaboradorEmpregador_SUCESS()
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
            colaboradorEmpregadorModel.DataCadastro = System.DateTime.Now;

            _repositoryColaboradorEmpregadorDadoPrincipalDefault.Add(colaboradorEmpregadorModel);

            _unitOfWork.Commit();
        }
    }
}
