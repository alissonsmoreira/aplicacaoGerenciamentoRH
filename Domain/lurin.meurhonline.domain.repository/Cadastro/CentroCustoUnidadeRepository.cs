using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CentroCustoUnidadeRepository : ICentroCustoUnidadeRepository<CentroCustoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CentroCustoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CentroCustoUnidadeModel GetCentroCustoUnidadebyId(int id)
        {
            var result = _db.CentroCustoUnidade
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CentroCustoUnidadeModel> GetCentroCustoUnidade(CentroCustoUnidadeModel centroCustoUnidade)
        {
            var result = _db.CentroCustoUnidade
                            .Where(x => centroCustoUnidade.Codigo != 0 ? x.Codigo == centroCustoUnidade.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(centroCustoUnidade.Nome) ? x.Nome.Contains(centroCustoUnidade.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public CentroCustoUnidadeModel GetCentroCustoUnidadeValidation(CentroCustoUnidadeModel centroCustoUnidade)
        {
            var result = _db.CentroCustoUnidade
                            .Where(x => centroCustoUnidade.Id != 0 ? x.Id != centroCustoUnidade.Id : x.Id != 0)
                            .Where(x => x.Codigo == centroCustoUnidade.Codigo)
                            .Where(x => x.Nome == centroCustoUnidade.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}