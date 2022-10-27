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
    public class TipoMaoObraRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ITipoMaoObraRepository<TipoMaoObraModel> TipoMaoObraRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<TipoMaoObraModel> _repositoryTipoMaoObraDefault;
        public static ITipoMaoObraRepository<TipoMaoObraModel> _repositoryTipoMaoObraCustom;

        public TipoMaoObraRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryTipoMaoObraDefault = new Repository<TipoMaoObraModel>(_unitOfWork);
            _repositoryTipoMaoObraCustom = new TipoMaoObraRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetTipoMaoObra_SUCESS()
        {
            var TipoMaoObraModel = new TipoMaoObraModel();
            TipoMaoObraModel.Codigo = 1;
            TipoMaoObraModel.Nome = "Tipo1";

            var result = _repositoryTipoMaoObraCustom.GetTipoMaoObra(TipoMaoObraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_TipoMaoObra_SUCESS()
        {
            var TipoMaoObraModel = new TipoMaoObraModel();
            TipoMaoObraModel.Codigo = 1;
            TipoMaoObraModel.Nome = "TipoMaodeObra1";
            TipoMaoObraModel.DataCadastro = DateTime.Now;

            _repositoryTipoMaoObraDefault.Add(TipoMaoObraModel);

            _unitOfWork.Commit();
        }
    }
}
