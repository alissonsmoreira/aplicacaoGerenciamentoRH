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
    public class CategoriaSalarialRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CategoriaSalarialModel> _repositoryCategoriaDefault;        
        public static ICategoriaSalarialRepository<CategoriaSalarialModel> _repositoryCategoriaCustom;

        public CategoriaSalarialRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCategoriaDefault = new Repository<CategoriaSalarialModel>(_unitOfWork);
            _repositoryCategoriaCustom = new CategoriaSalarialRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetCategoriaSalarial_SUCESS()
        {
            var categoriaSalarialModel = new CategoriaSalarialModel();
            categoriaSalarialModel.Nome = "Al";

            var result = _repositoryCategoriaCustom.GetCategoriaSalarial(categoriaSalarialModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CategoriaSalarial_SUCESS()
        {
            var categoriaSalarialModel = new CategoriaSalarialModel();
            categoriaSalarialModel.Nome = "Alto";
            categoriaSalarialModel.DataCadastro = DateTime.Now;

            _repositoryCategoriaDefault.Add(categoriaSalarialModel);

            _unitOfWork.Commit();
        }
    }
}
