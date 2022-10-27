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
    public class DivergenciaRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<DivergenciaModel> _repositoryDivergencia;
        public static IRepository<DivergenciaLogModel> _repositoryDivergenciaLog;
        public static IDivergenciaRepository<DivergenciaModel> _repositoryDivergenciaCustom;

        public DivergenciaRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryDivergencia = new Repository<DivergenciaModel>(_unitOfWork);
            _repositoryDivergenciaLog = new Repository<DivergenciaLogModel>(_unitOfWork);
            _repositoryDivergenciaCustom = new DivergenciaRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetDivergenciaById_SUCESS()
        {
            var DivergenciaModel = new DivergenciaModel();
            DivergenciaModel.Id = 1;
            
            var result = _repositoryDivergenciaCustom.GetDivergenciaById(DivergenciaModel.Id);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDivergenciaByColaboradorIdData_SUCESS()
        {
            var DivergenciaModel = new DivergenciaModel();
            DivergenciaModel.ColaboradorId = 1;
            DateTime inicio = new DateTime(2020,01,01);
            DateTime fim = new DateTime(2020, 03, 01);

            var result = _repositoryDivergenciaCustom.GetDivergenciaByColaboradorIdData(DivergenciaModel.ColaboradorId, inicio, fim);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Divergencia_SUCESS()
        {
            var DivergenciaModel = new DivergenciaModel();
            DivergenciaModel.EmpresaId = 1;
            DivergenciaModel.ColaboradorId = 1;
            DivergenciaModel.Matricula = "5";
            DivergenciaModel.DataCadastro = DateTime.Now;

            _repositoryDivergencia.Add(DivergenciaModel);

            //_unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_DivergenciaLog_SUCESS()
        {
            var DivergenciaLogModel = new DivergenciaLogModel();
            DivergenciaLogModel.LogErro = "CPF não encontrado";
            DivergenciaLogModel.Matricula = "6";
            DivergenciaLogModel.DataCadastro = DateTime.Now;
            
            _repositoryDivergenciaLog.Add(DivergenciaLogModel);

            //_unitOfWork.Commit();
        }
    }
}
