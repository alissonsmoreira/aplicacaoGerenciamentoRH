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
    public class NotificacaoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<NotificacaoModel> _repositoryNotificacaoDefault;
        public static IRepository<NotificacaoDetalheModel> _repositoryNotificacaoTipoDefault;
        public static INotificacaoRepository<NotificacaoModel> _repositoryNotificacaoCustom;

        public NotificacaoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryNotificacaoDefault = new Repository<NotificacaoModel>(_unitOfWork);
            _repositoryNotificacaoCustom = new NotificacaoRepository(_unitOfWork);
        }

        [TestMethod]
        public void GetNotificacaoGestor_SUCESS()
        {
            var notificacaoModel = new NotificacaoModel();
            notificacaoModel.NotificacaoStatusLeituraId = 2;

            var result = _repositoryNotificacaoCustom.GetNotificacaoGestor(1);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        [Ignore]
        public void Adicionar_Notificacao_SUCESS()
        {
            var notificacaoModel = new NotificacaoModel();
            notificacaoModel.NotificacaoDetalheId = 1;
            notificacaoModel.NotificacaoStatusLeituraId = 2;
            notificacaoModel.ById = 1;
            notificacaoModel.DataCadastro = DateTime.Now;

            _repositoryNotificacaoDefault.Add(notificacaoModel);

            _unitOfWork.Commit();
        }
    }
}
