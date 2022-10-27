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
    public class UnidadeNegocioRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static IUnidadeNegocioRepository<UnidadeNegocioModel> UnidadeNegocioRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<UnidadeNegocioModel> _repositoryUnidadeNegocioDefault;
        public static IUnidadeNegocioRepository<UnidadeNegocioModel> _repositoryUnidadeNegocioCustom;

        public UnidadeNegocioRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryUnidadeNegocioDefault = new Repository<UnidadeNegocioModel>(_unitOfWork);
            _repositoryUnidadeNegocioCustom = new UnidadeNegocioRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetUnidadeNegocio_SUCESS()
        {
            var UnidadeNegocioModel = new UnidadeNegocioModel();
            UnidadeNegocioModel.Codigo = 1;
            UnidadeNegocioModel.Nome = "Unidade1";

            var result = _repositoryUnidadeNegocioCustom.GetUnidadeNegocio(UnidadeNegocioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_UnidadeNegocio_SUCESS()
        {
            var UnidadeNegocioModel = new UnidadeNegocioModel();
            UnidadeNegocioModel.Codigo = 1;
            UnidadeNegocioModel.Nome = "Unidade1";
            UnidadeNegocioModel.DataCadastro = DateTime.Now;

            _repositoryUnidadeNegocioDefault.Add(UnidadeNegocioModel);

            _unitOfWork.Commit();
        }
    }
}
