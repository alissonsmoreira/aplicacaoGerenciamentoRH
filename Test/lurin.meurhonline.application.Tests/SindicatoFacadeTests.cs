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
    public class SindicatoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static SindicatoFacade SindicatoFacade;

        public SindicatoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            SindicatoFacade = new SindicatoFacade();
        }

        [TestMethod]
        public void BuscarSindicato_SUCESS()
        {
            var SindicatoModel = new SindicatoModel();
            SindicatoModel.Nome = "2";
            SindicatoModel.Cnpj = "191";
            //SindicatoModel.DataBase = DateTime.Now;
            SindicatoModel.Representante = "Representante3";
            SindicatoModel.TelefoneComercial = "5555";
            SindicatoModel.TelefoneCelular = "(11)1233";

            var result = SindicatoFacade.BuscarSindicato(SindicatoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarSindicato_SUCESS()
        {
            var SindicatoModel = new SindicatoModel();
            SindicatoModel.Nome = "Sindicato2";
            SindicatoModel.Cnpj = "00000000000191";
            SindicatoModel.DataBaseMes = "06";
            SindicatoModel.DataBaseAno = "1990";
            SindicatoModel.Representante = "Representante3";
            SindicatoModel.TelefoneComercial = "(11)1234-5555";
            SindicatoModel.TelefoneCelular = "(11)1233-55544";

            var result = SindicatoFacade.AdicionarSindicato(SindicatoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarSindicato_SUCESS()
        {
            var SindicatoModel = new SindicatoModel();
            SindicatoModel.Id = 2;
            SindicatoModel.Nome = "Sindicato3";
            SindicatoModel.Cnpj = "00000000000191";
            SindicatoModel.DataBaseMes = "06";
            SindicatoModel.DataBaseAno = "1990";
            SindicatoModel.Representante = "Representante 555";
            SindicatoModel.TelefoneComercial = "(11)1234-5555";
            SindicatoModel.TelefoneCelular = "(11)1233-55544";

            var result = SindicatoFacade.EditarSindicato(SindicatoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirSindicato_SUCESS()
        {
            var result = SindicatoFacade.ExcluirSindicato(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
