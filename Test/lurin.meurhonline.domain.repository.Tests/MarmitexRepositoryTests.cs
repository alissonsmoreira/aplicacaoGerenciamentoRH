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
    public class MarmitexRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static IMarmitexRepository<MarmitexModel> MarmitexRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<MarmitexModel> _repositoryMarmitexDefault;
        public static IMarmitexRepository<MarmitexModel> _repositoryMarmitexCustom;

        public MarmitexRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryMarmitexDefault = new Repository<MarmitexModel>(_unitOfWork);
            _repositoryMarmitexCustom = new MarmitexRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetMarmitex_SUCESS()
        {
            var MarmitexModel = new MarmitexModel();
            MarmitexModel.Tipo = "1";

            var result = _repositoryMarmitexCustom.GetMarmitex(MarmitexModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Marmitex_SUCESS()
        {
            var MarmitexModel = new MarmitexModel();
            MarmitexModel.Tipo = "Marmitex1";
            MarmitexModel.DataCadastro = DateTime.Now;

            _repositoryMarmitexDefault.Add(MarmitexModel);

            _unitOfWork.Commit();
        }
    }
}
