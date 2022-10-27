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
    public class AbsenteismoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<AbsenteismoModel> _repositoryAbsenteismo;
        public static IRepository<AbsenteismoLogModel> _repositoryAbsenteismoLog;
        public static IAbsenteismoRepository<AbsenteismoModel> _repositoryAbsenteismoCustom;

        public AbsenteismoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryAbsenteismo = new Repository<AbsenteismoModel>(_unitOfWork);
            _repositoryAbsenteismoLog = new Repository<AbsenteismoLogModel>(_unitOfWork);
            _repositoryAbsenteismoCustom = new AbsenteismoRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetAbsenteismoById_SUCESS()
        {
            var result = _repositoryAbsenteismoCustom.GetAbsenteismoByColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAbsenteismoByColaboradorIdData_SUCESS()
        {
            var result = _repositoryAbsenteismoCustom.GetAbsenteismoByAnoMes("2021","3");

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Absenteismo_SUCESS()
        {
            var AbsenteismoModel = new AbsenteismoModel();
            AbsenteismoModel.ColaboradorId = 1;
            AbsenteismoModel.Ano = "2021";
            AbsenteismoModel.Mes = "3";
            AbsenteismoModel.Nome = "Teste";
            AbsenteismoModel.HorasTotais = "200";
            AbsenteismoModel.HorasNaoTrabalhadas = "10";
            AbsenteismoModel.Absenteismo = "15";
            AbsenteismoModel.DataCadastro = DateTime.Now;

            _repositoryAbsenteismo.Add(AbsenteismoModel);

            //_unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_AbsenteismoLog_SUCESS()
        {
            var AbsenteismoLogModel = new AbsenteismoLogModel();
            AbsenteismoLogModel.LogErro = "CPF não encontrado";
            AbsenteismoLogModel.Cpf = "666.999.000-00";
            AbsenteismoLogModel.DataCadastro = DateTime.Now;
            
            _repositoryAbsenteismoLog.Add(AbsenteismoLogModel);

            //_unitOfWork.Commit();
        }
    }
}
