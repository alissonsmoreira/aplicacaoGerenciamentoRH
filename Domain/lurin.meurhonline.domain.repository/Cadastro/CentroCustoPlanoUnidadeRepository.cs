using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CentroCustoPlanoUnidadeRepository : ICentroCustoPlanoUnidadeRepository<CentroCustoPlanoUnidadeModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CentroCustoPlanoUnidadeRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CentroCustoPlanoUnidadeModel GetCentroCustoPlanoUnidadeById(int centroCustoPlanoId, int centroCustoUnidadeId)
        {
            var result = _db.CentroCustoPlanoUnidade
                            .Where(x => x.CentroCustoPlanoId == centroCustoPlanoId)
                            .Where(x => x.CentroCustoUnidadeId == centroCustoUnidadeId)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CentroCustoPlanoUnidadeModel> GetCentroCustoPlanoUnidade(CentroCustoPlanoUnidadeModel centroCustoPlanoUnidade)
        {
            var result = _db.CentroCustoPlanoUnidade
                            .Where(x => centroCustoPlanoUnidade.CentroCustoPlanoId != 0 ? x.CentroCustoPlanoId == centroCustoPlanoUnidade.CentroCustoPlanoId : x.CentroCustoPlanoId != 0 || x.CentroCustoPlanoId == 0)
                            .Where(x => centroCustoPlanoUnidade.CentroCustoUnidadeId != 0 ? x.CentroCustoUnidadeId == centroCustoPlanoUnidade.CentroCustoUnidadeId : x.CentroCustoUnidadeId != 0)
                            .ToList();

            return result;
        }

        public IEnumerable<CentroCustoPlanoUnidadeModel> GetCentroCustoPlanoUnidadeByCentroCustoPlanoId(int centroCustoPlanoId)
        {
            var result = _db.CentroCustoPlanoUnidade
                            .Where(x => x.CentroCustoPlanoId == centroCustoPlanoId)
                            .ToList();

            return result;
        }

        public IEnumerable<CentroCustoPlanoUnidadeModel> GetCentroCustoUnidadeByEmpresaId(int empresaId)
        {
            var result = _db.CentroCustoPlanoUnidade
                            .Include(x => x.CentroCustoUnidade)
                            .Where(x => x.CentroCustoPlano.EmpresaId == empresaId)
                            .ToList();

            return result;
        }

        public CentroCustoPlanoUnidadeModel GetCentroCustoPlanoUnidadeValidation(CentroCustoPlanoUnidadeModel centroCustoPlanoUnidade)
        {
            var result = _db.CentroCustoPlanoUnidade
                            .Where(x => x.CentroCustoPlanoId == centroCustoPlanoUnidade.CentroCustoPlanoId)
                            .Where(x => x.CentroCustoUnidadeId == centroCustoPlanoUnidade.CentroCustoUnidadeId)
                            .FirstOrDefault();

            return result;
        }
    }
}