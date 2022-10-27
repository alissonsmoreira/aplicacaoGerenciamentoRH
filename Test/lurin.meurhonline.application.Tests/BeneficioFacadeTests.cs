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
    public class BeneficioFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static BeneficioFacade beneficioFacade;

        public BeneficioFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            beneficioFacade = new BeneficioFacade();
        }

        [TestMethod]
        public void BuscarBeneficio_SUCESS()
        {
            var beneficioModel = new BeneficioModel();
            beneficioModel.Nome = "Data";
            beneficioModel.RegraDesconto = "T";
            beneficioModel.CustoBeneficio = 0M;
            beneficioModel.BeneficioTipoId = 0;

            var result = beneficioFacade.BuscarBeneficio(beneficioModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarBeneficioTipo_SUCESS()
        {
            var result = beneficioFacade.BuscarBeneficioTipo();

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarBeneficio_SUCESS()
        {
            var beneficioModel = new BeneficioModel();
            beneficioModel.Nome = "TesteData";
            beneficioModel.RegraDesconto = "Teste400";
            beneficioModel.CustoBeneficio = 20.05M;
            beneficioModel.BeneficioTipoId = 1;

            var result = beneficioFacade.AdicionarBeneficio(beneficioModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarBeneficio_SUCESS()
        {
            var beneficioModel = new BeneficioModel();
            beneficioModel.Id = 2;
            beneficioModel.Nome = "TesteData2";
            beneficioModel.RegraDesconto = "Teste450";
            beneficioModel.CustoBeneficio = Convert.ToDecimal("100.500,05");
            beneficioModel.BeneficioTipoId = 2;

            var result = beneficioFacade.EditarBeneficio(beneficioModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirBeneficio_SUCESS()
        {
            var result = beneficioFacade.ExcluirBeneficio(54);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
