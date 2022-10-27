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
    public class EquipeGestorRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<EquipeGestorModel> _repositoryEquipeGestorDefault;
        public static IEquipeGestorRepository<EquipeGestorModel> _repositoryEquipeGestorCustom;

        public EquipeGestorRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryEquipeGestorDefault = new Repository<EquipeGestorModel>(_unitOfWork);
            _repositoryEquipeGestorCustom = new EquipeGestorRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetEquipeGestor_SUCESS()
        {
            var equipeGestorModel = new EquipeGestorModel();
            equipeGestorModel.ColaboradorId = 1;
            equipeGestorModel.LotacaoUnidadeInicialId = 1;
            equipeGestorModel.LotacaoUnidadeFinalId = 0;

            var result = _repositoryEquipeGestorCustom.GetEquipeGestor(equipeGestorModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void Adicionar_EquipeGestor_SUCESS()
        {
            var equipeGestorModel = new EquipeGestorModel();
            equipeGestorModel.ColaboradorId = 1;
            equipeGestorModel.LotacaoUnidadeInicialId = 1;
            equipeGestorModel.LotacaoUnidadeFinalId =5;
            equipeGestorModel.DataCadastro = DateTime.Now;

            _repositoryEquipeGestorDefault.Add(equipeGestorModel);

            _unitOfWork.Commit();
        }
    }
}
