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
    public class OperadoraVTRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<OperadoraVTModel> _repositoryOperadoraVTDefault;
        public static IRepository<OperadoraVTBandeiraCartaoModel> _repositoryOperadoraVTBandeiraCartaoDefault;
        public static IRepository<OperadoraVTTarifaTipoModel> _repositoryOperadoraVTTarifaTipoDefault;
        public static IOperadoraVTRepository<OperadoraVTModel> _repositoryOperadoraVTCustom;

        public OperadoraVTRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryOperadoraVTDefault = new Repository<OperadoraVTModel>(_unitOfWork);
            _repositoryOperadoraVTBandeiraCartaoDefault = new Repository<OperadoraVTBandeiraCartaoModel>(_unitOfWork);
            _repositoryOperadoraVTTarifaTipoDefault = new Repository<OperadoraVTTarifaTipoModel>(_unitOfWork);

            _repositoryOperadoraVTCustom = new OperadoraVTRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetOperadoraVT_SUCESS()
        {
            var OperadoraVTModel = new OperadoraVTModel();
            OperadoraVTModel.Nome = "50";
            OperadoraVTModel.OperadoraVTBandeiraCartaoId = 0;
            OperadoraVTModel.OperadoraVTTarifaTipoId = 0;

            var result = _repositoryOperadoraVTCustom.GetOperadoraVT(OperadoraVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOperadoraVTBandeiraCartao_SUCESS()
        {
            var result = _repositoryOperadoraVTBandeiraCartaoDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOperadoraVTTarifaTipo_SUCESS()
        {
            var result = _repositoryOperadoraVTTarifaTipoDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_OperadoraVT_SUCESS()
        {
            var OperadoraVTModel = new OperadoraVTModel();
            OperadoraVTModel.Nome = "Teste1000";
            OperadoraVTModel.OperadoraVTBandeiraCartaoId = 1;
            OperadoraVTModel.OperadoraVTTarifaTipoId = 2;
            OperadoraVTModel.DataCadastro = DateTime.Now;

            _repositoryOperadoraVTDefault.Add(OperadoraVTModel);

            _unitOfWork.Commit();
        }
    }
}
