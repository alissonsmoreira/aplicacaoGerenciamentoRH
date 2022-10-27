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
    public class ValeTransporteRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<ValeTransporteModel> _repositoryValeTransporteDadoPrincipalDefault;
        public static IValeTransporteRepository<ValeTransporteModel> _repositoryValeTransporteDadoPrincipalCustom;

        public ValeTransporteRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryValeTransporteDadoPrincipalDefault = new Repository<ValeTransporteModel>(_unitOfWork);
            _repositoryValeTransporteDadoPrincipalCustom = new ValeTransporteRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetValeTransporte_SUCESS()
        {

            var ValeTransporteModel = new ValeTransporteModel();
            ValeTransporteModel.ColaboradorId = 1;
            ValeTransporteModel.SolicitacaoStatusId = 1;

            var result = _repositoryValeTransporteDadoPrincipalCustom.GetValeTransporte(ValeTransporteModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void Solicitar_ValeTransporte_SUCESS()
        {
            var valeTransporteModel = new ValeTransporteModel();
            valeTransporteModel.ColaboradorId = 1;
            valeTransporteModel.OperadoraVTId = 1;
            valeTransporteModel.LinhaVTId = 1;
            valeTransporteModel.ValeTransporteUtilizacaoId = 2;
            valeTransporteModel.ValeTransporteSituacaoId = 2;
            valeTransporteModel.SolicitacaoStatusId = 1;
            valeTransporteModel.DataSolicitacao = DateTime.Now;

            _repositoryValeTransporteDadoPrincipalDefault.Add(valeTransporteModel);

            _unitOfWork.Commit();
        }
    }
}
