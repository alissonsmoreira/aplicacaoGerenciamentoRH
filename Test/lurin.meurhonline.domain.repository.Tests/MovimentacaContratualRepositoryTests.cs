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
    public class MovimentacaoContratualRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<MovimentacaoContratualModel> _repositoryMovimentacaoContratualDadoPrincipalDefault;
        public static IMovimentacaoContratualRepository<MovimentacaoContratualModel> _repositoryMovimentacaoContratualDadoPrincipalCustom;

        public MovimentacaoContratualRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryMovimentacaoContratualDadoPrincipalDefault = new Repository<MovimentacaoContratualModel>(_unitOfWork);
            _repositoryMovimentacaoContratualDadoPrincipalCustom = new MovimentacaoContratualRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetMovimentacaoContratual_SUCESS()
        {

            var movimentacaoContratualModel = new MovimentacaoContratualModel();
            movimentacaoContratualModel.ColaboradorId = 1;
            movimentacaoContratualModel.EmpresaId = 0;
            movimentacaoContratualModel.SolicitacaoStatusId = 1;

            var result = _repositoryMovimentacaoContratualDadoPrincipalCustom.GetMovimentacaoContratual(movimentacaoContratualModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Solicitar_MovimentacaoContratual_SUCESS()
        {
            var movimentacaoContratualModel = new MovimentacaoContratualModel();
            movimentacaoContratualModel.GestorId = 1;
            movimentacaoContratualModel.ColaboradorId = 1;
            movimentacaoContratualModel.EmpresaId = 1;
            movimentacaoContratualModel.LotacaoUnidadeId = 1;
            movimentacaoContratualModel.CentroCustoUnidadeId = 1;
            movimentacaoContratualModel.CargoUnidadeId = 1;
            movimentacaoContratualModel.TurnoId = 1;
            movimentacaoContratualModel.UnidadeNegocioId = 1;
            movimentacaoContratualModel.NumeroCartaoPonto = "545450";
            movimentacaoContratualModel.TipoMaoObraId = 1;
            movimentacaoContratualModel.Salario = 1000;
            movimentacaoContratualModel.SolicitacaoStatusId = 1;
            movimentacaoContratualModel.DataSolicitacao = DateTime.Now;

            _repositoryMovimentacaoContratualDadoPrincipalDefault.Add(movimentacaoContratualModel);

            _unitOfWork.Commit();
        }
    }
}
