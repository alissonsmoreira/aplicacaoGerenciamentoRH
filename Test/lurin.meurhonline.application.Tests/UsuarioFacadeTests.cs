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
    public class UsuarioFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static UsuarioFacade UsuarioFacade;

        public UsuarioFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            UsuarioFacade = new UsuarioFacade();
        }

        [TestMethod]
        public void BuscarUsuario_SUCESS()
        {
            var usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "usu";
            usuarioModel.CPF = "1234";
            usuarioModel.Endereco = "";
            usuarioModel.Complemento = "";
            usuarioModel.Bairro = "";
            usuarioModel.CEP = "";
            usuarioModel.UF = "SP";
            usuarioModel.Cidade = "";
            usuarioModel.TelefoneResidencial = "";
            usuarioModel.TelefoneCelular = "";
            usuarioModel.TelefoneComercial = "";
            usuarioModel.Email = "usuario@t";

            var result = UsuarioFacade.BuscarUsuario(usuarioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void AdicionarUsuario_SUCESS()
        {
            var usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "Usuario 4";
            usuarioModel.CPF = "12345264789113";
            usuarioModel.Endereco = "Rua xxxx, 1579";
            usuarioModel.Complemento = "Casa 15";
            usuarioModel.Bairro = "Bairo 123";
            usuarioModel.CEP = "06000-789";
            usuarioModel.UF = "SP";
            usuarioModel.Cidade = "São Paulo";
            usuarioModel.TelefoneResidencial = "(xx) 1234-5678";
            usuarioModel.TelefoneCelular = "(xx) 91234-5678";
            usuarioModel.TelefoneComercial = "(xx) 4567-8910";
            usuarioModel.Email = "teste@hotmail.com";

            var result = UsuarioFacade.AdicionarUsuario(usuarioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void EditarUsuario_SUCESS()
        {
            var usuarioModel = new UsuarioModel();
            usuarioModel.Id = 2;
            usuarioModel.Nome = "Usuario 333";
            usuarioModel.CPF = "12345678911";
            usuarioModel.Endereco = "Rua xxxx, 1579";
            usuarioModel.Complemento = "Casa 15";
            usuarioModel.Bairro = "Bairo 123";
            usuarioModel.CEP = "06000-789";
            usuarioModel.UF = "SP";
            usuarioModel.Cidade = "São Paulo";
            usuarioModel.TelefoneResidencial = "(xx) 1234-5678";
            usuarioModel.TelefoneCelular = "(xx) 91234-5678";
            usuarioModel.TelefoneComercial = "(xx) 4567-8910";
            usuarioModel.Email = "usuario@teste2.com";

            var result = UsuarioFacade.EditarUsuario(usuarioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void ExcluirUsuario_SUCESS()
        {
            var result = UsuarioFacade.ExcluirUsuario(2);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}
