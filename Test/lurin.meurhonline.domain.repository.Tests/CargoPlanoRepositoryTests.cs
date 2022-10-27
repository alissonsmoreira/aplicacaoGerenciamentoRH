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
    public class CargoPlanoRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ICargoPlanoRepository<CargoPlanoModel> cargoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CargoPlanoModel> _repositoryCargoPlanoDefault;
        public static IRepository<CargoPlanoUnidadeModel> _repositoryCargoPlanoUnidadeDefault;

        public static ICargoPlanoRepository<CargoPlanoModel> _repositoryCargoPlanoCustom;

        public CargoPlanoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCargoPlanoDefault = new Repository<CargoPlanoModel>(_unitOfWork);
            _repositoryCargoPlanoUnidadeDefault = new Repository<CargoPlanoUnidadeModel>(_unitOfWork);

            _repositoryCargoPlanoCustom = new CargoPlanoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetCargoPlano_SUCESS()
        {
            var CargoPlanoModel = new CargoPlanoModel();
            CargoPlanoModel.Codigo = 1;
            CargoPlanoModel.Nome = "Pl";

            var result = _repositoryCargoPlanoCustom.GetCargoPlano(CargoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CargoPlano_SUCESS()
        {
            var cargoPlanoModel = new CargoPlanoModel();
            cargoPlanoModel.Codigo = 1;
            cargoPlanoModel.Nome = "Plano 123";
            cargoPlanoModel.EmpresaId = 1;
            cargoPlanoModel.DataCadastro = DateTime.Now;

            _repositoryCargoPlanoDefault.Add(cargoPlanoModel);

            _unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CargoPlanoUnidade_SUCESS()
        {
            var cargoPlanoUnidadeModel = new CargoPlanoUnidadeModel();
            cargoPlanoUnidadeModel.CargoPlanoId = 1;
            cargoPlanoUnidadeModel.CargoUnidadeId = 1;

            _repositoryCargoPlanoUnidadeDefault.Add(cargoPlanoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
