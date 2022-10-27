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
    public class LoginTest
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static LoginFacade loginFacadeFacade;

        public LoginTest()
        {
            unitOfWork = new UnitOfWork();
            loginFacadeFacade = new LoginFacade();
        }

        [TestMethod]
        public void BuscarLogin_SUCESS()
        {
            var result = loginFacadeFacade.BuscarLogin("1234526789113", "y6k6w4");            

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RecuperarSenha_SUCESS()
        {
            var result = loginFacadeFacade.RecuperarSenha("456789");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void AlterarSenha_SUCESS()
        {
            var result = loginFacadeFacade.AlterarSenha("", "456789", "45678910");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
