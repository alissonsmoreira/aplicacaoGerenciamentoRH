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
    public class FeriasRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<FeriasModel> _repositoryFerias;
        public static IRepository<FeriasLogModel> _repositoryFeriasLog;
        public static IFeriasRepository<FeriasModel> _repositoryFeriasCustom;

        public FeriasRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryFerias = new Repository<FeriasModel>(_unitOfWork);
            _repositoryFeriasLog = new Repository<FeriasLogModel>(_unitOfWork);
            _repositoryFeriasCustom = new FeriasRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetFeriasById_SUCESS()
        {
            var feriasModel = new FeriasModel();
            feriasModel.Id = 1;

            var result = _repositoryFeriasCustom.GetFeriasById(feriasModel.Id);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFeriasByEmpresaMatricula_SUCESS()
        {
            var feriasModel = new FeriasModel();
            feriasModel.EmpresaId = 1;
            feriasModel.Matricula = "1";

            var result = _repositoryFeriasCustom.GetFeriasByEmpresaId(feriasModel.EmpresaId.Value);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Ferias_SUCESS()
        {
            var feriasModel = new FeriasModel();
            feriasModel.Estabelecimento = "";
            feriasModel.Matricula = "1";
            feriasModel.DataCadastro = DateTime.Now;

            _repositoryFerias.Add(feriasModel);

            //_unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_FeriasLog_SUCESS()
        {
            var feriasLogModel = new FeriasLogModel();
            feriasLogModel.LogErro = "CPF não encontrado";
            feriasLogModel.Matricula = "99999999999";
            feriasLogModel.DataCadastro = DateTime.Now;
            
            _repositoryFeriasLog.Add(feriasLogModel);

            //_unitOfWork.Commit();
        }
    }
}
