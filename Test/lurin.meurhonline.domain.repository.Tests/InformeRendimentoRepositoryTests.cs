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
    public class InformeRendimentoRepositoryTests
    {
        public static IUnitOfWorkCustom _unitOfWork;
        public static IRepository<InformeRendimentoModel> _repositoryInformeRendimento;
        public static IRepository<InformeRendimentoLogModel> _repositoryInformeRendimentoLog;
        public static IInformeRendimentoRepository<InformeRendimentoModel> _repositoryInformeRendimentoCustom;

        public InformeRendimentoRepositoryTests()
        {
            _unitOfWork = new UnitOfWork();

            _repositoryInformeRendimento = new Repository<InformeRendimentoModel>(_unitOfWork);
            _repositoryInformeRendimentoLog = new Repository<InformeRendimentoLogModel>(_unitOfWork);
            _repositoryInformeRendimentoCustom = new InformeRendimentoRepository(_unitOfWork);            
        }

        [TestMethod]
        public void GetInformeRendimentoById_SUCESS()
        {
            var informeRendimentoModel = new InformeRendimentoModel();
            informeRendimentoModel.Id = 1;
            
            var result = _repositoryInformeRendimentoCustom.GetInformeRendimentoById(informeRendimentoModel.Id);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetInformeRendimentoByCpf_SUCESS()
        {
            var informeRendimentoModel = new InformeRendimentoModel();
            informeRendimentoModel.ColaboradorId = 1;
            informeRendimentoModel.Ano = "2020";

            var result = _repositoryInformeRendimentoCustom.GetInformeRendimentoByColaboradorIdAno(informeRendimentoModel.ColaboradorId, informeRendimentoModel.Ano);

            if (result == null)
                Assert.IsNull(result);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_InformeRendimento_SUCESS()
        {
            var informeRendimentoModel = new InformeRendimentoModel();
            informeRendimentoModel.Ministerio = "";
            informeRendimentoModel.TipoDocumento = "Teste1000";
            informeRendimentoModel.CPF = "999.999.999-99";
            informeRendimentoModel.Nome = "Teste";
            informeRendimentoModel.DataCadastro = DateTime.Now;

            _repositoryInformeRendimento.Add(informeRendimentoModel);

            //_unitOfWork.Commit();
        }

        [TestMethod]
        [Ignore]
        public void Adicionar_InformeRendimentoLog_SUCESS()
        {
            var informeRendimentoLogModel = new InformeRendimentoLogModel();
            informeRendimentoLogModel.LogErro = "CPF não encontrado";
            informeRendimentoLogModel.CPF = "999.999.999-99";
            informeRendimentoLogModel.DataCadastro = DateTime.Now;
            
            _repositoryInformeRendimentoLog.Add(informeRendimentoLogModel);

            //_unitOfWork.Commit();
        }
    }
}
