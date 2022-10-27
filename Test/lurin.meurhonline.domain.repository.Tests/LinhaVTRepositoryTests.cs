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
    public class LinhaVTRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<LinhaVTModel> _repositoryLinhaVTDefault;
        public static ILinhaVTRepository<LinhaVTModel> _repositoryLinhaVTCustom;

        public LinhaVTRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryLinhaVTDefault = new Repository<LinhaVTModel>(_unitOfWork);
            _repositoryLinhaVTCustom = new LinhaVTRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetLinhaVT_SUCESS()
        {
            var LinhaVTModel = new LinhaVTModel();
            LinhaVTModel.NomeLinha = "12";
            LinhaVTModel.ValorLinha = 20.05M;
            LinhaVTModel.OperadoraVTId = 0;

            var result = _repositoryLinhaVTCustom.GetLinhaVT(LinhaVTModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_LinhaVT_SUCESS()
        {
            var LinhaVTModel = new LinhaVTModel();
            LinhaVTModel.NomeLinha = "Linha 123";
            LinhaVTModel.ValorLinha = Convert.ToDecimal("3.25");
            LinhaVTModel.OperadoraVTId = 1;
            LinhaVTModel.DataCadastro = DateTime.Now;

            _repositoryLinhaVTDefault.Add(LinhaVTModel);

            _unitOfWork.Commit();
        }
    }
}
