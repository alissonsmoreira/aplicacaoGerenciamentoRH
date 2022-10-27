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
    public class TurnoDetalheRepositoryTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static ITurnoRepository<TurnoModel> TurnoRepository;

        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<TurnoDetalheModel> _repositoryTurnoDetalheDefault;
        public static ITurnoDetalheRepository<TurnoDetalheModel> _repositoryTurnoDetalheCustom;

        public TurnoDetalheRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryTurnoDetalheDefault = new Repository<TurnoDetalheModel>(_unitOfWork);
            _repositoryTurnoDetalheCustom = new TurnoDetalheRepository(_unitOfWork);
        }        

        [TestMethod]
        public void GetTurnoDetalhe_SUCESS()
        {
            var result = _repositoryTurnoDetalheCustom.GetTurnoDetalhebyId(3);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
      
        [TestMethod]
        [Ignore]
        public void Adicionar_TurnoDetalhe_SUCESS()
        {
            var turnoDetalheModel = new TurnoDetalheModel();
            turnoDetalheModel.DiaSemana = "Segunda";
            turnoDetalheModel.HorarioInicial = "08:15";
            turnoDetalheModel.HorarioFinal = "17:50";
            turnoDetalheModel.TurnoId = 1;
            turnoDetalheModel.DataCadastro = DateTime.Now;

            _repositoryTurnoDetalheDefault.Add(turnoDetalheModel);

            _unitOfWork.Commit();
        }
    }
}
