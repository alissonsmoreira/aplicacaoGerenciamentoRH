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
    public class ReciboFeriasRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ReciboFeriasModel> _repositoryReciboFerias;
        public static IRepository<ReciboFeriasLogModel> _repositoryReciboFeriasLog;
        public static IReciboFeriasRepository<ReciboFeriasModel> _repositoryReciboFeriasCustom;

        public ReciboFeriasRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryReciboFerias = new Repository<ReciboFeriasModel>(_unitOfWork);
            _repositoryReciboFeriasLog = new Repository<ReciboFeriasLogModel>(_unitOfWork);
            _repositoryReciboFeriasCustom = new ReciboFeriasRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetReciboFeriasById_SUCESS()
        {
            var ReciboFeriasModel = new ReciboFeriasModel();
            ReciboFeriasModel.Id = 1;

            var result = _repositoryReciboFeriasCustom.GetReciboFeriasById(ReciboFeriasModel.Id);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetReciboFeriasByCpf_SUCESS()
        {
            var ReciboFeriasModel = new ReciboFeriasModel();
            ReciboFeriasModel.Ano = "2020";
            ReciboFeriasModel.ColaboradorId = 1;

            var result = _repositoryReciboFeriasCustom.GetReciboFeriasAnoColaboradorById(ReciboFeriasModel.Ano, ReciboFeriasModel.ColaboradorId);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ReciboFerias_SUCESS()
        {
            var ReciboFeriasModel = new ReciboFeriasModel();
            ReciboFeriasModel.Estabelecimento = "";
            ReciboFeriasModel.CPF = "99999999999";
            ReciboFeriasModel.DataCadastro = DateTime.Now;

            _repositoryReciboFerias.Add(ReciboFeriasModel);

            //_unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_ReciboFeriasLog_SUCESS()
        {
            var ReciboFeriasLogModel = new ReciboFeriasLogModel();
            ReciboFeriasLogModel.LogErro = "CPF não encontrado";
            ReciboFeriasLogModel.CPF = "99999999999";
            ReciboFeriasLogModel.DataCadastro = DateTime.Now;
            
            _repositoryReciboFeriasLog.Add(ReciboFeriasLogModel);

            //_unitOfWork.Commit();
        }
    }
}
