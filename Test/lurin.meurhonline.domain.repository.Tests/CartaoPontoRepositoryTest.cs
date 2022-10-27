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
    public class CartaoPontoRepositoryTest
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<CartaoPontoModel> _repositoryCartaoPontoDefault;
        public static ICartaoPontoRepository<CartaoPontoModel> _repositoryCartaoPontoCustom;

        public CartaoPontoRepositoryTest()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryCartaoPontoDefault = new Repository<CartaoPontoModel>(_unitOfWork);
            _repositoryCartaoPontoCustom = new CartaoPontoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetAll_SUCESS()
        {
            int cartaoPontoId = 3;
            var result = _repositoryCartaoPontoCustom.GetCartaoPontoById(cartaoPontoId);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetBeneficioTipo_SUCESS()
        {
            int colaboradorId = 3;
            string Mes = "03";
            string Ano = "2021";

            var result = _repositoryCartaoPontoCustom.GetCartaoPontoByColaboradorIdMesAno(colaboradorId, Mes, Ano);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }
    }
}


