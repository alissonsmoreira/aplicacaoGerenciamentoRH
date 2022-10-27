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
    public class DesligamentoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<DesligamentoModel> _repositoryDesligamentoDadoPrincipalDefault;
        public static IDesligamentoRepository<DesligamentoModel> _repositoryDesligamentoDadoPrincipalCustom;

        public DesligamentoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryDesligamentoDadoPrincipalDefault = new Repository<DesligamentoModel>(_unitOfWork);
            _repositoryDesligamentoDadoPrincipalCustom = new DesligamentoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetDesligamento_SUCESS()
        {

            var desligamentoModel = new DesligamentoModel();
            desligamentoModel.GestorId = 0;
            desligamentoModel.ColaboradorId = 1;
            desligamentoModel.SolicitacaoStatusId = 1;

            var result = _repositoryDesligamentoDadoPrincipalCustom.GetDesligamento(desligamentoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Solicitar_Desligamento_SUCESS()
        {
            var desligamentoModel = new DesligamentoModel();
            desligamentoModel.GestorId = 1;
            desligamentoModel.ColaboradorId = 1;

            desligamentoModel.DataSugerida = Convert.ToDateTime("2021-04-01");
            desligamentoModel.DesligamentoTipoId = 1;
            desligamentoModel.Motivo = "Fim de contrato";
            desligamentoModel.Substituir = true;
            desligamentoModel.Recontrataria = true;

            desligamentoModel.SolicitacaoStatusId = 1;
            desligamentoModel.DataSolicitacao = DateTime.Now;

            _repositoryDesligamentoDadoPrincipalDefault.Add(desligamentoModel);

            _unitOfWork.Commit();
        }
    }
}
