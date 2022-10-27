using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lurin.meurhonline.application;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class BancoHorasFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static BancoHorasFacade BancoHorasFacade;

        public BancoHorasFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            BancoHorasFacade = new BancoHorasFacade();
        }

        [TestMethod]
        public void BuscarTudoBancoHoras_SUCESS()
        {

            var result = BancoHorasFacade.BuscarTudoBancoHoras();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarBancoHorasPorEmpresaId_SUCESS()
        {

            var result = BancoHorasFacade.BuscarBancoHorasPorEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarBancoHorasPorGestorId_SUCESS()
        {

            var result = BancoHorasFacade.BuscarBancoHorasPorGestorId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarTudoBancoHorasLog_SUCESS()
        {

            var result = BancoHorasFacade.BuscarTudoBancoHorasLog();

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarBancoHorasLogPorEmpresaId_SUCESS()
        {

            var result = BancoHorasFacade.BuscarBancoHorasLogPorEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        //[Ignore]
        public void ImportarBancoHoras_SUCESS()
        {
            var bancoHorasModel = new BancoHorasModel();
            bancoHorasModel.EmpresaId = 1;
            bancoHorasModel.DocumentoBase64 = "LS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQpJTkRVU1RSSUEgRSBDT01FUkNJTyBKT0xJVEVYIExUREEgICAgICAgICAgICAgICAgQmFuY28gZGUgSG9yYXMgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBQYWdpbmE6ICAgIDENCi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tIDA2LzA1LzIwMTYgLSAxMTo1MjoxOQ0KDQpFc3RhYmVsZWNpbWVudG86ICAgMiAgICAgIElORFVTVFJJQSBFIENPTUVSQ0lPIEpPTElURVggTFREQS4gICAgICAgICBDZW50cm8gQ3VzdG86ICAxMDIxMA0KREVTRU5WT0xWSU1FTlRPIC0gVEFQRVRFUy9DT0JFUlRPUkVTL0RFQw0KVGlwbyBjb21wZW5zYe+/ve+/vW86ICAgIDEgIEJhbmNvIGRlIEhvcmFzICAgICAgICAgICAgICAgICBDb250cmF0byA6ICBFbXByZXNhDQoNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgLS0tLS0tLS0tLS0tLS0tLS0tLS0tIEhvcmFzICAtLS0tLS0tLS0tLS0tLS0tLS0tLQ0KTWF0cmljdWxhICAgICAgIE5vbWUgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBQb3NpdGl2YXMgICAgICAgICBOZWdhdGl2YXMgICAgICAgICBTYWxkbw0KLS0tLS0tLS0tLSAgICAgIC0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0gICAgICAtLS0tLS0tLS0tLS0gICAgICAtLS0tLS0tLS0tLS0gICAgICAtLS0tLS0tLS0tLS0tDQogICAgMjkyNi0yICAgICAgR0FCUklFTExBIE1BWVVNSSBUQU5BS0EgICAgICAgICAgICAgICAgICAgICAgICAgIDA6NDEgICAgICAgICAgICAgICAwOjAwICAgICAgICAgICAgICAwOjQxDQogICAgMjkyNS00ICAgICAgTElHSUEgVkFSQU5FTExJIERFIFNPVVpBICAgICAgICAgICAgICAgICAgICAgICAgIDA6MjIgICAgICAgICAgICAgICAwOjAwICAgICAgICAgICAgICAwOjIyDQogICAgMjkyNC02ICAgICAgTUFSSUFOQSBaT0JPTEkgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDA6MjYgICAgICAgICAgICAgICAwOjAwICAgICAgICAgICAgICAwOjI2DQogICAgMjk3OC01ICAgICAgUEFNRUxBIFJPRFJJR1VFUyBEQSBTSUxWQSAgICAgICAgICAgICAgICAgICAgICAgIDM6MDEgICAgICAgICAgICAgICAwOjAwICAgICAgICAgICAgICAzOjAxDQoNCiAgICAgICAgICAgICAgICBUb3RhbCBkbyBDZW50cm8gZGUgQ3VzdG8gICAgICAgICAgICAgICAgICAgICAgICA0OjMwICAgICAgICAgICAgICAgMDowMCAgICAgICAgICAgICAgNDozMA0KDQoNCg0KDQoNCg0KDQo=";

            var result = BancoHorasFacade.AdicionarBancoHoras(bancoHorasModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

      

    }
}
