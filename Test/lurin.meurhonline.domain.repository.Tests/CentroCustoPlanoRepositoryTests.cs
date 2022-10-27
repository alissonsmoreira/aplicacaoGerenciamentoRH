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
    public class CentroCustoPlanoRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ICentroCustoPlanoRepository<CentroCustoPlanoModel> cargoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CentroCustoPlanoModel> _repositoryCentroCustoPlanoDefault;
        public static IRepository<CentroCustoPlanoUnidadeModel> _repositoryCentroCustoPlanoUnidadeDefault;

        public static ICentroCustoPlanoRepository<CentroCustoPlanoModel> _repositoryCentroCustoPlanoCustom;

        public CentroCustoPlanoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCentroCustoPlanoDefault = new Repository<CentroCustoPlanoModel>(_unitOfWork);
            _repositoryCentroCustoPlanoUnidadeDefault = new Repository<CentroCustoPlanoUnidadeModel>(_unitOfWork);

            _repositoryCentroCustoPlanoCustom = new CentroCustoPlanoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetCentroCustoPlano_SUCESS()
        {
            var centroCustoPlanoModel = new CentroCustoPlanoModel();
            centroCustoPlanoModel.Codigo = 1;
            centroCustoPlanoModel.Nome = "Pl";

            var result = _repositoryCentroCustoPlanoCustom.GetCentroCustoPlano(centroCustoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CentroCustoPlano_SUCESS()
        {
            var centroCustoPlanoModel = new CentroCustoPlanoModel();
            centroCustoPlanoModel.Codigo = 1;
            centroCustoPlanoModel.Nome = "Plano 123";
            centroCustoPlanoModel.EmpresaId = 1;
            centroCustoPlanoModel.DataCadastro = DateTime.Now;

            _repositoryCentroCustoPlanoDefault.Add(centroCustoPlanoModel);

            _unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CentroCustoPlanoUnidade_SUCESS()
        {
            var CentroCustoPlanoUnidadeModel = new CentroCustoPlanoUnidadeModel();
            CentroCustoPlanoUnidadeModel.CentroCustoPlanoId = 1;
            CentroCustoPlanoUnidadeModel.CentroCustoUnidadeId = 2;

            _repositoryCentroCustoPlanoUnidadeDefault.Add(CentroCustoPlanoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
