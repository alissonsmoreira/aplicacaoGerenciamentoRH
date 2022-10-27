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
    public class TipoRegistroRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ITipoRegistroRepository<TipoRegistroModel> TipoRegistroRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<TipoRegistroModel> _repositoryTipoRegistroDefault;
        public static ITipoRegistroRepository<TipoRegistroModel> _repositoryTipoRegistroCustom;

        public TipoRegistroRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryTipoRegistroDefault = new Repository<TipoRegistroModel>(_unitOfWork);
            _repositoryTipoRegistroCustom = new TipoRegistroRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetTipoRegistro_SUCESS()
        {
            var TipoRegistroModel = new TipoRegistroModel();
            TipoRegistroModel.Nome = "1";

            var result = _repositoryTipoRegistroCustom.GetTipoRegistro(TipoRegistroModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_TipoRegistro_SUCESS()
        {
            var TipoRegistroModel = new TipoRegistroModel();
            TipoRegistroModel.Nome = "TipoRegistro1";
            TipoRegistroModel.DataCadastro = DateTime.Now;

            _repositoryTipoRegistroDefault.Add(TipoRegistroModel);

           _unitOfWork.Commit();
        }
    }
}
