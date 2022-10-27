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
    public class NotificacaoFacadeTests
    {
        public static IUnitOfWorkCustom unitOfWork;
        public static NotificacaoFacade NotificacaoFacade;

        public NotificacaoFacadeTests()
        {
            unitOfWork = new UnitOfWork();
            NotificacaoFacade = new NotificacaoFacade();
        }

        [TestMethod]
        public void BuscarNotificacao_SUCESS()
        {
            var result = NotificacaoFacade.BuscarNotificacao(1, 1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AdicionarNotificacao_SUCESS()
        {
            var notificacaoModel = new NotificacaoModel();
            notificacaoModel.NotificacaoDetalheId = 1;
            notificacaoModel.NotificacaoStatusLeituraId = 2;
            notificacaoModel.ById = 1;
            
            var result = NotificacaoFacade.AdicionarNotificacao(notificacaoModel);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void AtualizarStatusLeitura()
        {
            var notificacaoModel = new NotificacaoModel();
            notificacaoModel.Id = 2;
            

            var result = NotificacaoFacade.AtualizarStatusLeituraAsync(notificacaoModel.Id);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

     
    }
}
