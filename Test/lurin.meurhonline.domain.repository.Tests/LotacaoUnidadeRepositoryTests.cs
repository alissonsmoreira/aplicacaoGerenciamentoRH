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
    public class LotacaoUnidadeRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ILotacaoUnidadeRepository<LotacaoUnidadeModel> LotacaoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<LotacaoUnidadeModel> _repositoryLotacaoDefault;
        public static ILotacaoUnidadeRepository<LotacaoUnidadeModel> _repositoryLotacaoCustom;
        public static ILotacaoPlanoUnidadeRepository<LotacaoPlanoUnidadeModel> _repositoryLotacaoPlanoUnidadeCustom;

        public LotacaoUnidadeRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryLotacaoDefault = new Repository<LotacaoUnidadeModel>(_unitOfWork);
            _repositoryLotacaoCustom = new LotacaoUnidadeRepository(_unitOfWork);
            _repositoryLotacaoPlanoUnidadeCustom = new LotacaoPlanoUnidadeRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetLotacaoUnidade_SUCESS()
        {
            var lotacaoUnidadeModel = new LotacaoUnidadeModel();
            lotacaoUnidadeModel.Codigo = 1;
            lotacaoUnidadeModel.Nome = "lot";

            var result = _repositoryLotacaoCustom.GetLotacaoUnidade(lotacaoUnidadeModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllLotacaoUnidade_SUCESS()
        {
            var result = _repositoryLotacaoDefault.GetAll();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLotacaoUnidadeByEmpresaId_SUCESS()
        {
            var result = _repositoryLotacaoPlanoUnidadeCustom.GetLotacaoUnidadeByEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_LotacaoUnidade_SUCESS()
        {
            var lotacaoUnidadeModel = new LotacaoUnidadeModel();
            lotacaoUnidadeModel.Codigo = 1;
            lotacaoUnidadeModel.Nome = "Lotacao1";
            lotacaoUnidadeModel.DataCadastro = DateTime.Now;

            _repositoryLotacaoDefault.Add(lotacaoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
