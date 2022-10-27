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
    public class SindicatoRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ISindicatoRepository<SindicatoModel> SindicatoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<SindicatoModel> _repositorySindicatoDefault;
        public static ISindicatoRepository<SindicatoModel> _repositorySindicatoCustom;

        public SindicatoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositorySindicatoDefault = new Repository<SindicatoModel>(_unitOfWork);
            _repositorySindicatoCustom = new SindicatoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetSindicato_SUCESS()
        {
            var SindicatoModel = new SindicatoModel();
            SindicatoModel.Nome = "Sindicato1";
            SindicatoModel.Cnpj = "0000011225555";
            //SindicatoModel.DataBase = System.DateTime.Now;
            SindicatoModel.Representante = "Representante";
            SindicatoModel.TelefoneComercial = "(00)1234-5678";
            SindicatoModel.TelefoneCelular = "(00)12345-6789";

            var result = _repositorySindicatoCustom.GetSindicato(SindicatoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Sindicato_SUCESS()
        {
            var SindicatoModel = new SindicatoModel();
            SindicatoModel.Nome = "Sindicato1";
            SindicatoModel.Cnpj = "0000011225555";
            SindicatoModel.DataBaseMes = "06";
            SindicatoModel.DataBaseMes = "1990";
            SindicatoModel.Representante = "Representante";
            SindicatoModel.TelefoneComercial = "(00)1234-5678";
            SindicatoModel.TelefoneCelular = "(00)12345-6789";
            SindicatoModel.DataCadastro = DateTime.Now;

            _repositorySindicatoDefault.Add(SindicatoModel);

            _unitOfWork.Commit();
        }
    }
}
