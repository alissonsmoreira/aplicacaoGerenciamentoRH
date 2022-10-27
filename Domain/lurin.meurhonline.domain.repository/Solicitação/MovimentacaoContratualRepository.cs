using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.model.enumerator;

namespace lurin.meurhonline.domain.repository
{
    public class MovimentacaoContratualRepository : IMovimentacaoContratualRepository<MovimentacaoContratualModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public MovimentacaoContratualRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public MovimentacaoContratualModel GetMovimentacaoContratualbyId(int id)
        {
            var result = _db.MovimentacaoContratual
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.Turno)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.TipoMaoObra)
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<MovimentacaoContratualModel> GetMovimentacaoContratual(MovimentacaoContratualModel movimentacaoContratual)
        {
            var result = _db.MovimentacaoContratual
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.Turno)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.TipoMaoObra)
                            .Where(x => movimentacaoContratual.GestorId != 0 ? x.GestorId == movimentacaoContratual.GestorId : x.GestorId == x.GestorId)
                            .Where(x => movimentacaoContratual.ColaboradorId != 0 ? x.ColaboradorId == movimentacaoContratual.ColaboradorId : x.ColaboradorId == x.ColaboradorId)
                            .Where(x => movimentacaoContratual.EmpresaId != 0 ? x.EmpresaId == movimentacaoContratual.EmpresaId : x.EmpresaId == x.EmpresaId)
                            .Where(x => movimentacaoContratual.SolicitacaoStatusId != 0 ? x.SolicitacaoStatusId == movimentacaoContratual.SolicitacaoStatusId : x.SolicitacaoStatusId == x.SolicitacaoStatusId)
                            .ToList();

            return result;
        }

        public IEnumerable<MovimentacaoContratualModel> GetMovimentacaoContratualbyColaboradorId(int id)
        {
            var result = _db.MovimentacaoContratual
                            .Include(x => x.LotacaoUnidade)
                            .Include(x => x.CentroCustoUnidade)
                            .Include(x => x.CargoUnidade)
                            .Include(x => x.Turno)
                            .Include(x => x.UnidadeNegocio)
                            .Include(x => x.TipoMaoObra)
                            .Where(x => x.ColaboradorId == id)
                            .ToList();

            return result;
        }

        public MovimentacaoContratualModel GetMovimentacaoContratualValidation(MovimentacaoContratualModel movimentacaoContratual)
        {
            var result = _db.MovimentacaoContratual
                            .Where(x => movimentacaoContratual.Id != 0 ? x.Id != movimentacaoContratual.Id : x.Id != 0)
                            .Where(x => x.ColaboradorId == movimentacaoContratual.ColaboradorId)
                            .Where(x => x.SolicitacaoStatusId == (int)SolicitacaoStatusEnum.EM_ANALISE)
                            .FirstOrDefault();

            return result;
        }
    }
}