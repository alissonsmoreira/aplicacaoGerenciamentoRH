using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CentroCustoPlanoRepository : ICentroCustoPlanoRepository<CentroCustoPlanoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CentroCustoPlanoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CentroCustoPlanoModel GetCentroCustoPlanobyId(int id)
        {
            var result = _db.CentroCustoPlano
                            .Where(x => x.Id == id)
                            .Include(x => x.Empresa)
                            .Include(x => x.CentroCustoPlanosUnidades.Select(u => u.CentroCustoUnidade))
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CentroCustoPlanoModel> GetCentroCustoPlano(CentroCustoPlanoModel centroCustoPlano)
        {
            var result = _db.CentroCustoPlano
                            .Where(x => centroCustoPlano.Codigo != 0 ? x.Codigo == centroCustoPlano.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(centroCustoPlano.Nome) ? x.Nome.Contains(centroCustoPlano.Nome) : x.Nome != string.Empty)
                            .Where(x => centroCustoPlano.EmpresaId != 0 ? x.EmpresaId == centroCustoPlano.EmpresaId : x.EmpresaId != 0 || x.EmpresaId == 0)
                            .Include(x => x.Empresa)
                            .Include(x => x.CentroCustoPlanosUnidades.Select(u => u.CentroCustoUnidade))
                            .ToList();

            return result;
        }

        public CentroCustoPlanoModel GetCentroCustoPlanoValidation(CentroCustoPlanoModel CentroCustoPlano)
        {
            var result = _db.CentroCustoPlano
                            .Where(x => CentroCustoPlano.Id != 0 ? x.Id != CentroCustoPlano.Id : x.Id != 0)
                            .Where(x => x.EmpresaId == CentroCustoPlano.EmpresaId)
                            //.Where(x => x.Codigo == CentroCustoPlano.Codigo)
                            //.Where(x => x.Nome == CentroCustoPlano.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}