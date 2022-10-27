using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class DesligamentoRepository : IDesligamentoRepository<DesligamentoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public DesligamentoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public DesligamentoModel GetDesligamentobyId(int id)
        {
            var result = _db.Desligamento
                            .Include(x => x.DesligamentoTipo)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<DesligamentoModel> GetDesligamento(DesligamentoModel desligamento)
        {
            var result = _db.Desligamento
                            .Include(x => x.DesligamentoTipo)
                            .Where(x => desligamento.GestorId != 0 ? x.GestorId == desligamento.GestorId : x.GestorId == x.GestorId)
                            .Where(x => desligamento.ColaboradorId != 0 ? x.ColaboradorId == desligamento.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => desligamento.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == desligamento.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<DesligamentoModel> GetDesligamentobyColaboradorId(int id)
        {
            var result = _db.Desligamento
                            .Include(x => x.DesligamentoTipo)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public DesligamentoModel GetDesligamentoValidation(DesligamentoModel Desligamento)
        {
            var result = _db.Desligamento
                            .Where(x => Desligamento.Id != 0 ? x.Id != Desligamento.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == Desligamento.ColaboradorId)
                            .Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}