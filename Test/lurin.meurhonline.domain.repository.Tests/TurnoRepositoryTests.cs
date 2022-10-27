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
    public class TurnoRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ITurnoRepository<TurnoModel> TurnoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<TurnoModel> _repositoryTurnoDefault;
        public static ITurnoRepository<TurnoModel> _repositoryTurnoCustom;

        public TurnoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryTurnoDefault = new Repository<TurnoModel>(_unitOfWork);
            _repositoryTurnoCustom = new TurnoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetTurno_SUCESS()
        {
            var TurnoModel = new TurnoModel();
            TurnoModel.Codigo = 1;
            TurnoModel.Descricao = "Turno1";

            var result = _repositoryTurnoCustom.GetTurno(TurnoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTurnoDetalhebyTurnoId_SUCESS()
        {

            var result = _repositoryTurnoCustom.GetTurnoDetalhebyTurnoId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Turno_SUCESS()
        {
            var TurnoModel = new TurnoModel();
            TurnoModel.Codigo = 1;
            TurnoModel.Descricao = "Turno2";
            TurnoModel.DataCadastro = DateTime.Now;

            _repositoryTurnoDefault.Add(TurnoModel);

            _unitOfWork.Commit();
        }


    }
}
