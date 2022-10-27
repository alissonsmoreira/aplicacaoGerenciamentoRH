using Microsoft.VisualStudio.TestTools.UnitTesting;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using System.Web;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class AbsenteismoFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static AbsenteismoFacade AbsenteismoFacade;

        public AbsenteismoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            AbsenteismoFacade = new AbsenteismoFacade();
        }

        [TestMethod]
        [Ignore]
        public void ImportarAbsenteismo_SUCESS()
        {
            var AbsenteismoModel = new AbsenteismoModel();

            //HttpPostedFile file;
            //var result = AbsenteismoFacade.ImportarAbsenteismo(file, "2021", "3");

            //if (result == null)
            //    Assert.IsNull(result);
            //else
            //    Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarAbsenteismoPorColaboradorId_SUCESS()
        {
            var result = AbsenteismoFacade.BuscarAbsenteismoPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarAbsenteismoPorGestor_SUCESS()
        {
            var result = AbsenteismoFacade.BuscarAbsenteismoPorGestorIdAnoMes(1,"2021","3");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarAbsenteismoPorAnoMes_SUCESS()
        {
            var result = AbsenteismoFacade.BuscarAbsenteismoPorAnoMes("2021","3");

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }
    }
}
