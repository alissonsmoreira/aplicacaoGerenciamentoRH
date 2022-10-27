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
    public class BeneficioRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<BeneficioModel> _repositoryBeneficioDefault;
        public static IRepository<BeneficioTipoModel> _repositoryBeneficioTipoDefault;
        public static IBeneficioRepository<BeneficioModel> _repositoryBeneficioCustom;

        public BeneficioRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryBeneficioDefault = new Repository<BeneficioModel>(_unitOfWork);
            _repositoryBeneficioTipoDefault = new Repository<BeneficioTipoModel>(_unitOfWork);

            _repositoryBeneficioCustom = new BeneficioRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetBeneficio_SUCESS()
        {
            var beneficioModel = new BeneficioModel();
            beneficioModel.Nome = "50";
            beneficioModel.RegraDesconto = "T";
            beneficioModel.CustoBeneficio = 20.05M;
            beneficioModel.BeneficioTipoId = 0;

            var result = _repositoryBeneficioCustom.GetBeneficio(beneficioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBeneficioTipo_SUCESS()
        {
            var result = _repositoryBeneficioTipoDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Beneficio_SUCESS()
        {
            var beneficioModel = new BeneficioModel();
            beneficioModel.Nome = "Teste1003";
            beneficioModel.RegraDesconto = "Teste1000";
            beneficioModel.CustoBeneficio = Convert.ToDecimal("3.25");
            beneficioModel.BeneficioTipoId = 1;
            beneficioModel.DataCadastro = DateTime.Now;

            _repositoryBeneficioDefault.Add(beneficioModel);

            _unitOfWork.Commit();
        }
    }
}
