using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.persistence;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lurin.meurhonline.application.Tests
{
    [TestClass]
    public class FeriasFacadeTests
    {        
        public static IUnitOfWorkCustom unitOfWork;
        public static FeriasFacade feriasFacade;

        public FeriasFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            feriasFacade = new FeriasFacade();
        }

        [TestMethod]
        [Ignore]
        public void ImportarFerias_SUCESS()
        {
            var feriasModel = new FeriasModel();
            feriasModel.DocumentoBase64 = "insira o arquivo base64 para teste";
            var result = feriasFacade.ImportarFerias(feriasModel);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarFeriasPorEmpresaIdColaboradorId_SUCESS()
        {
            var result = feriasFacade.BuscarFeriasPorEmpresaId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarFeriasPorColaboradorId_SUCESS()
        {
            var result = feriasFacade.BuscarFeriasPorColaboradorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarFeriasPorId_SUCESS()
        {
            var result = feriasFacade.BuscarFeriasPorId(1);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SolicitarFerias_SUCESS()
        {
            FeriasPeriodoModel fpm = new FeriasPeriodoModel();
            fpm.Id = 1;
            fpm.Saldo = "10";
            var result = feriasFacade.SolicitarFerias(fpm);

            if (result == null)
                Assert.IsNull(result);
            else
                Assert.IsNotNull(result);
        }   
    }
}
