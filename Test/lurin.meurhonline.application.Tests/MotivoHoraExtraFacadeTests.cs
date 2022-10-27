using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class MotivoHoraExtraFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static MotivoHoraExtraFacade MotivoHoraExtraFacade;

        public MotivoHoraExtraFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            MotivoHoraExtraFacade = new MotivoHoraExtraFacade();
        }

        [TestMethod]
        public void BuscarMotivoHoraExtra_SUCESS()
        {
            var MotivoHoraExtraModel = new MotivoHoraExtraModel();
            MotivoHoraExtraModel.Motivo = "Mot";

            var result = MotivoHoraExtraFacade.BuscarMotivoHoraExtra(MotivoHoraExtraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarMotivoHoraExtra_SUCESS()
        {
            var MotivoHoraExtraModel = new MotivoHoraExtraModel();
            MotivoHoraExtraModel.Motivo = "Motivo 5555";

            var result = MotivoHoraExtraFacade.AdicionarMotivoHoraExtra(MotivoHoraExtraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarMotivoHoraExtra_SUCESS()
        {
            var MotivoHoraExtraModel = new MotivoHoraExtraModel();
            MotivoHoraExtraModel.Id = 2;
            MotivoHoraExtraModel.Motivo = "Motivo1233333";

            var result = MotivoHoraExtraFacade.EditarMotivoHoraExtra(MotivoHoraExtraModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirMotivoHoraExtra_SUCESS()
        {
            var result = MotivoHoraExtraFacade.ExcluirMotivoHoraExtra(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
