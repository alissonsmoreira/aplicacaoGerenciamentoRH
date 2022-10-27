using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class AtestadoRepository : IAtestadoRepository<AtestadoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public AtestadoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public AtestadoModel GetAtestadobyId(int id)
        {
            var result = _db.Atestado
                            .Include(x => x.Colaborador)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<AtestadoModel> GetAtestado(AtestadoModel atestado)
        {
            var result = _db.Atestado
                            .Include(x => x.Colaborador)
                            .Where(x => atestado.ColaboradorId != 0 ? x.ColaboradorId == atestado.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => atestado.LancamentoStatusId != 0 ? x.LancamentoStatusId == atestado.LancamentoStatusId : x.LancamentoStatusId == x.LancamentoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<AtestadoModel> GetAtestadobyColaboradorId(int id)
        {
            var result = _db.Atestado
                            .Include(x => x.Colaborador)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public AtestadoModel GetAtestadoValidation(AtestadoModel atestado)
        {
            var result = _db.Atestado
                            .Where(x => atestado.Id != 0 ? x.Id != atestado.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == atestado.ColaboradorId)
                            .Where(x => x.DataAtestado == atestado.DataAtestado)
                            .Where(x => x.LancamentoStatusId == (int)LancamentoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}