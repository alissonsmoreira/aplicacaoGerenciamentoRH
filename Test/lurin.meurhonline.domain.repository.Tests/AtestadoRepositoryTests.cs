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
    public class AtestadoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<AtestadoModel> _repositoryAtestadoDadoPrincipalDefault;
        public static IAtestadoRepository<AtestadoModel> _repositoryAtestadoDadoPrincipalCustom;

        public AtestadoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryAtestadoDadoPrincipalDefault = new Repository<AtestadoModel>(_unitOfWork);
            _repositoryAtestadoDadoPrincipalCustom = new AtestadoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetAtestado_SUCESS()
        {

            var atestadoModel = new AtestadoModel();
            atestadoModel.ColaboradorId = 1;
            atestadoModel.LancamentoStatusId = 1;

            var result = _repositoryAtestadoDadoPrincipalCustom.GetAtestado(atestadoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Lancar_Atestado_SUCESS()
        {
            var atestadoModel = new AtestadoModel();
            atestadoModel.ColaboradorId = 1;
            atestadoModel.DataAtestado = DateTime.Now;
            atestadoModel.HorarioChegada = "08:00";
            atestadoModel.HorarioSaida= "12:00";
            atestadoModel.QuantidadeDias = 10;
            atestadoModel.CID = "Leve";
            atestadoModel.AtestadoNome = "ASDASDASDAS.jpg";
            atestadoModel.ColaboradorId = 1;

            atestadoModel.LancamentoStatusId = 1;
            atestadoModel.DataLancamento = DateTime.Now;

            _repositoryAtestadoDadoPrincipalDefault.Add(atestadoModel);

            _unitOfWork.Commit();
        }
    }
}
