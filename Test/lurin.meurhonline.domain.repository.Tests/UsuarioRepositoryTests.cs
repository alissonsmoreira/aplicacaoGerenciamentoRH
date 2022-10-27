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
    public class UsuarioRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static IUsuarioRepository<UsuarioModel> cargoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<UsuarioModel> _repositoryUsuarioDefault;

        public static IUsuarioRepository<UsuarioModel> _repositoryUsuarioCustom;

        public UsuarioRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryUsuarioDefault = new Repository<UsuarioModel>(_unitOfWork);
            _repositoryUsuarioCustom = new UsuarioRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetUsuario_SUCESS()
        {
            var usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "us";
            usuarioModel.CPF = "25";
            //usuarioModel.Senha = "";
            usuarioModel.Endereco = "";
            usuarioModel.Complemento = "";
            usuarioModel.Bairro = "";
            usuarioModel.CEP = "";
            usuarioModel.UF = "";
            usuarioModel.Cidade = "";
            usuarioModel.TelefoneResidencial = "";
            usuarioModel.TelefoneCelular = "";
            usuarioModel.TelefoneComercial = "";
            usuarioModel.Email = "";

            var result = _repositoryUsuarioCustom.GetUsuario(usuarioModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Adicionar_Usuario_SUCESS()
        {
            var usuarioModel = new UsuarioModel();
            usuarioModel.Nome = "Usuario";
            usuarioModel.CPF = "25555";
            //usuarioModel.Senha = "Senh@UsuaIrio";
            usuarioModel.Endereco = "Rua xxxx, 123";
            usuarioModel.Complemento = "Casa 1";
            usuarioModel.Bairro = "Bairoo";
            usuarioModel.CEP = "06000-123";
            usuarioModel.UF = "SP";
            usuarioModel.Cidade = "São Paulo";
            usuarioModel.TelefoneResidencial = "(xx) 1234-5678";
            usuarioModel.TelefoneCelular = "(xx) 91234-5678";
            usuarioModel.TelefoneComercial = "(xx) 4567-8910";
            usuarioModel.Email = "usuario@teste.com";
            usuarioModel.DataCadastro = DateTime.Now;

            _repositoryUsuarioDefault.Add(usuarioModel);

            _unitOfWork.Commit();
        }

    }
}
