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
    public class CargoUnidadeRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ICargoUnidadeRepository<CargoUnidadeModel> cargoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CargoUnidadeModel> _repositoryCargoDefault;        
        public static ICargoUnidadeRepository<CargoUnidadeModel> _repositoryCargoCustom;
        public static ICargoPlanoUnidadeRepository<CargoPlanoUnidadeModel> _repositoryCargoPlanoUnidadeCustom;

        public CargoUnidadeRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCargoDefault = new Repository<CargoUnidadeModel>(_unitOfWork);
            _repositoryCargoCustom = new CargoUnidadeRepository(_unitOfWork);
            _repositoryCargoPlanoUnidadeCustom = new CargoPlanoUnidadeRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetCargoUnidade_SUCESS()
        {
            var cargoUnidadeModel = new CargoUnidadeModel();
            cargoUnidadeModel.Codigo = 1;
            cargoUnidadeModel.Nome = "Analis";

            var result = _repositoryCargoCustom.GetCargoUnidade(cargoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllCargoUnidade_SUCESS()
        {
            var result = _repositoryCargoDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCargoUnidadeByEmpresaId_SUCESS()
        {
            var result = _repositoryCargoPlanoUnidadeCustom.GetCargoUnidadeByEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CargoUnidade_SUCESS()
        {
            var cargoUnidadeModel = new CargoUnidadeModel();
            cargoUnidadeModel.Codigo = 1;
            cargoUnidadeModel.Nome = "Analista";
            cargoUnidadeModel.DataCadastro = DateTime.Now;

            _repositoryCargoDefault.Add(cargoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
