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
    public class LotacaoPlanoRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ILotacaoPlanoRepository<LotacaoPlanoModel> LotacaoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<LotacaoPlanoModel> _repositoryLotacaoPlanoDefault;
        public static IRepository<LotacaoPlanoUnidadeModel> _repositoryLotacaoPlanoUnidadeDefault;

        public static ILotacaoPlanoRepository<LotacaoPlanoModel> _repositoryLotacaoPlanoCustom;

        public LotacaoPlanoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryLotacaoPlanoDefault = new Repository<LotacaoPlanoModel>(_unitOfWork);
            _repositoryLotacaoPlanoUnidadeDefault = new Repository<LotacaoPlanoUnidadeModel>(_unitOfWork);

            _repositoryLotacaoPlanoCustom = new LotacaoPlanoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetLotacaoPlano_SUCESS()
        {
            var lotacaoPlanoModel = new LotacaoPlanoModel();
            lotacaoPlanoModel.Codigo = 1;
            lotacaoPlanoModel.Nome = "Pl";

            var result = _repositoryLotacaoPlanoCustom.GetLotacaoPlano(lotacaoPlanoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_LotacaoPlano_SUCESS()
        {
            var lotacaoPlanoModel = new LotacaoPlanoModel();
            lotacaoPlanoModel.Codigo = 1;
            lotacaoPlanoModel.Nome = "Plano 123";
            lotacaoPlanoModel.EmpresaId = 1;
            lotacaoPlanoModel.DataCadastro = DateTime.Now;

            _repositoryLotacaoPlanoDefault.Add(lotacaoPlanoModel);

            _unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_LotacaoPlanoUnidade_SUCESS()
        {
            var LotacaoPlanoUnidadeModel = new LotacaoPlanoUnidadeModel();
            LotacaoPlanoUnidadeModel.LotacaoPlanoId = 1;
            LotacaoPlanoUnidadeModel.LotacaoUnidadeId = 1;

            _repositoryLotacaoPlanoUnidadeDefault.Add(LotacaoPlanoUnidadeModel);

            _unitOfWork.Commit();
        }
    }
}
