using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class FeriasPeriodoRepository : IFeriasPeriodoRepository<FeriasPeriodoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public FeriasPeriodoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public FeriasPeriodoModel GetFeriasPeriodoById(int id)
        {
            var result = _db.FeriasPeriodo
                            .Where(x => x.Id == id)
                            .Include(x => x.Ferias)
                            .Include(x => x.Concessao)
                            .FirstOrDefault();

            return result;
        }
    }
}