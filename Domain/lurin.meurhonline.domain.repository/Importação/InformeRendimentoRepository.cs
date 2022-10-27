using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class InformeRendimentoRepository : IInformeRendimentoRepository<InformeRendimentoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public InformeRendimentoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public InformeRendimentoModel GetInformeRendimentoById(int id)
        {
            var result = _db.InformeRendimento
                            .Where(x => x.Id == id)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.TipoRendimentosTributaveis)
                            .Include(x => x.TipoRendimentosIsentos)
                            .Include(x => x.TipoRendimentosSujeitosTrib)
                            .Include(x => x.TipoRendimentosReceb)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<InformeRendimentoModel> GetInformeRendimentoByColaboradorId(int colaboradorId)
        {
            var result = _db.InformeRendimento
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.TipoRendimentosTributaveis)
                            .Include(x => x.TipoRendimentosIsentos)
                            .Include(x => x.TipoRendimentosSujeitosTrib)
                            .Include(x => x.TipoRendimentosReceb)
                            .OrderByDescending(x => x.Ano)
                            .ToList();

            return result;
        }

        public InformeRendimentoModel GetInformeRendimentoByColaboradorIdAno(int colaboradorId, string ano)
        {
            var result = _db.InformeRendimento
                            .Where(x => x.ColaboradorId == colaboradorId && x.Ano == ano)
                            .Include(x => x.Colaborador)
                            .Include(x => x.Empresa)
                            .Include(x => x.TipoRendimentosTributaveis)
                            .Include(x => x.TipoRendimentosIsentos)
                            .Include(x => x.TipoRendimentosSujeitosTrib)
                            .Include(x => x.TipoRendimentosReceb)
                            .FirstOrDefault();

            return result;
        }
    }
}