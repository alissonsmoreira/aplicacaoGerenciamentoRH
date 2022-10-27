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
    public class SolicitacaoHoraExtraRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<SolicitacaoHoraExtraModel> _repositorySolicitacaoHoraExtraDefault;
        public static ISolicitacaoHoraExtraRepository<SolicitacaoHoraExtraModel> _repositorySolicitacaoHoraExtraCustom;

        public SolicitacaoHoraExtraRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositorySolicitacaoHoraExtraDefault = new Repository<SolicitacaoHoraExtraModel>(_unitOfWork);
            _repositorySolicitacaoHoraExtraCustom = new SolicitacaoHoraExtraRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetSolicitacaoHoraExtrabyGestorId_SUCESS()
        {

            int IdGestor = 6;
            DateTime data = Convert.ToDateTime("2021-03-30");

            var result = _repositorySolicitacaoHoraExtraCustom.GetSolicitacaoHoraExtrabyGestorId(IdGestor, data);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSolicitacaoHoraExtraId_SUCESS()
        {
            int empresaID = 4;

            var result = _repositorySolicitacaoHoraExtraCustom.GetSolicitacaoHoraExtraId(empresaID);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSolicitacaoHoraExtraColaborador_SUCESS()
        {
            SolicitacaoHoraExtraColaboradorModel solicitacaoHoraExtraColaborador = new SolicitacaoHoraExtraColaboradorModel();
            solicitacaoHoraExtraColaborador.SolicitacaoHoraExtraId = 4;
            solicitacaoHoraExtraColaborador.ColaboradorId = 2;

            var result = _repositorySolicitacaoHoraExtraCustom.GetSolicitacaoHoraExtraColaborador(solicitacaoHoraExtraColaborador);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
