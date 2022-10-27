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
    public class MotivoHoraExtraRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static IMotivoHoraExtraRepository<MotivoHoraExtraModel> MotivoHoraExtraRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<MotivoHoraExtraModel> _repositoryMotivoHoraExtraDefault;
        public static IMotivoHoraExtraRepository<MotivoHoraExtraModel> _repositoryMotivoHoraExtraCustom;

        public MotivoHoraExtraRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryMotivoHoraExtraDefault = new Repository<MotivoHoraExtraModel>(_unitOfWork);
            _repositoryMotivoHoraExtraCustom = new MotivoHoraExtraRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetMotivoHoraExtra_SUCESS()
        {
            var MotivoHoraExtraModel = new MotivoHoraExtraModel();
            MotivoHoraExtraModel.Motivo = "Motivo";

            var result = _repositoryMotivoHoraExtraCustom.GetMotivoHoraExtra(MotivoHoraExtraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_MotivoHoraExtra_SUCESS()
        {
            var MotivoHoraExtraModel = new MotivoHoraExtraModel();
            MotivoHoraExtraModel.Motivo = "Motivo 123";
            MotivoHoraExtraModel.DataCadastro = DateTime.Now;

            _repositoryMotivoHoraExtraDefault.Add(MotivoHoraExtraModel);

            _unitOfWork.Commit();
        }
    }
}
