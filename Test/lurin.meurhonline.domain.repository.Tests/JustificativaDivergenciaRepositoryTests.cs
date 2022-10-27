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
    public class JustificativaDivergenciaRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<JustificativaDivergenciaModel> _repositoryJustificativaDivergenciaDefault;
        public static IJustificativaDivergenciaRepository<JustificativaDivergenciaModel> _repositoryJustificativaDivergenciaCustom;

        public JustificativaDivergenciaRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryJustificativaDivergenciaDefault = new Repository<JustificativaDivergenciaModel>(_unitOfWork);
            _repositoryJustificativaDivergenciaCustom = new JustificativaDivergenciaRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetJustificativaDivergencia_SUCESS()
        {
            var JustificativaDivergenciaModel = new JustificativaDivergenciaModel();
            JustificativaDivergenciaModel.Tipo = "1";

            var result = _repositoryJustificativaDivergenciaCustom.GetJustificativaDivergencia(JustificativaDivergenciaModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_Beneficio_SUCESS()
        {
            var JustificativaDivergenciaModel = new JustificativaDivergenciaModel();
            JustificativaDivergenciaModel.Tipo = "Justificativa1";
            JustificativaDivergenciaModel.DataCadastro = DateTime.Now;

            _repositoryJustificativaDivergenciaDefault.Add(JustificativaDivergenciaModel);

            _unitOfWork.Commit();
        }
    }
}
