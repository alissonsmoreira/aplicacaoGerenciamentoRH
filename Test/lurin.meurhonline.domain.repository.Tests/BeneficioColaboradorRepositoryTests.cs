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
    public class BeneficioColaboradorRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<BeneficioColaboradorModel> _repositoryBeneficioColaboradorDadoPrincipalDefault;
        public static IBeneficioColaboradorRepository<BeneficioColaboradorModel> _repositoryBeneficioColaboradorDadoPrincipalCustom;

        public BeneficioColaboradorRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryBeneficioColaboradorDadoPrincipalDefault = new Repository<BeneficioColaboradorModel>(_unitOfWork);
            _repositoryBeneficioColaboradorDadoPrincipalCustom = new BeneficioColaboradorRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetBeneficioColaborador_SUCESS()
        {

            var BeneficioColaboradorModel = new BeneficioColaboradorModel();
            BeneficioColaboradorModel.ColaboradorId = 1;
            BeneficioColaboradorModel.SolicitacaoStatusId = 1;

            var result = _repositoryBeneficioColaboradorDadoPrincipalCustom.GetBeneficioColaborador(BeneficioColaboradorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Solicitar_BeneficioColaborador_SUCESS()
        {
            var BeneficioColaboradorModel = new BeneficioColaboradorModel();
            BeneficioColaboradorModel.ColaboradorId = 1;
            BeneficioColaboradorModel.BeneficioId = 1;
            BeneficioColaboradorModel.SolicitacaoStatusId = 1;
            BeneficioColaboradorModel.DataSolicitacao = DateTime.Now;

            _repositoryBeneficioColaboradorDadoPrincipalDefault.Add(BeneficioColaboradorModel);

            _unitOfWork.Commit();
        }
    }
}
