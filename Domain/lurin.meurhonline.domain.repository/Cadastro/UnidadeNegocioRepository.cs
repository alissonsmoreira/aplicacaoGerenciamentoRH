using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class UnidadeNegocioRepository : IUnidadeNegocioRepository<UnidadeNegocioModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public UnidadeNegocioRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public UnidadeNegocioModel GetUnidadeNegociobyId(int id)
        {
            var result = _db.UnidadeNegocio
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<UnidadeNegocioModel> GetUnidadeNegocio(UnidadeNegocioModel unidadeNegocio)
        {
            var result = _db.UnidadeNegocio
                            .Where(x => unidadeNegocio.Codigo != 0 ? x.Codigo == unidadeNegocio.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(unidadeNegocio.Nome) ? x.Nome.Contains(unidadeNegocio.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public UnidadeNegocioModel GetUnidadeNegocioValidation(UnidadeNegocioModel unidadeNegocio)
        {
            var result = _db.UnidadeNegocio
                            .Where(x => unidadeNegocio.Id != 0 ? x.Id != unidadeNegocio.Id : x.Id != 0)
                            .Where(x => x.Codigo== unidadeNegocio.Codigo)
                            .Where(x => x.Nome == unidadeNegocio.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}