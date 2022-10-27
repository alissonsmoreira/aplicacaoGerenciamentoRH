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
    public class CentroCustoUnidadeRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ICentroCustoUnidadeRepository<CentroCustoUnidadeModel> CentroCustoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CentroCustoUnidadeModel> _repositoryCentroCustoUnidadeDefault;
        public static ICentroCustoUnidadeRepository<CentroCustoUnidadeModel> _repositoryCentroCustoUnidadeCustom;
        public static ICentroCustoPlanoUnidadeRepository<CentroCustoPlanoUnidadeModel> _repositoryCentroCustoPlanoUnidadeCustom;

        public CentroCustoUnidadeRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCentroCustoUnidadeDefault = new Repository<CentroCustoUnidadeModel>(_unitOfWork);
            _repositoryCentroCustoUnidadeCustom = new CentroCustoUnidadeRepository(_unitOfWork);
            _repositoryCentroCustoPlanoUnidadeCustom = new CentroCustoPlanoUnidadeRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetCentroCustoUnidade_SUCESS()
        {
            var centroCustoUnidadeModel = new CentroCustoUnidadeModel();
            centroCustoUnidadeModel.Codigo = 2;
            centroCustoUnidadeModel.Nome = "T";

            var result = _repositoryCentroCustoUnidadeCustom.GetCentroCustoUnidade(centroCustoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCentroCustoUnidadeByEmpresaId_SUCESS()
        {
            var result = _repositoryCentroCustoPlanoUnidadeCustom.GetCentroCustoUnidadeByEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_CentroCustoUnidade_SUCESS()
        {
            var centroCustoUnidadeModel = new CentroCustoUnidadeModel();
            centroCustoUnidadeModel.Codigo = 25;
            centroCustoUnidadeModel.Nome = "TI";
            centroCustoUnidadeModel.DataCadastro = DateTime.Now;

            _repositoryCentroCustoUnidadeDefault.Add(centroCustoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
