using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class TipoMaoObraRepository : ITipoMaoObraRepository<TipoMaoObraModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public TipoMaoObraRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public TipoMaoObraModel GetTipoMaoObrabyId(int id)
        {
            var result = _db.TipoMaoObra
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<TipoMaoObraModel> GetTipoMaoObra(TipoMaoObraModel tipoMaoObra)
        {
            var result = _db.TipoMaoObra                            
                            .Where(x => tipoMaoObra.Codigo != 0 ? x.Codigo == tipoMaoObra.Codigo : x.Codigo != 0 || x.Codigo == 0)
                            .Where(x => !string.IsNullOrEmpty(tipoMaoObra.Nome) ? x.Nome.Contains(tipoMaoObra.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public TipoMaoObraModel GetTipoMaoObraValidation(TipoMaoObraModel tipoMaoObra)
        {
            var result = _db.TipoMaoObra
                            .Where(x => tipoMaoObra.Id != 0 ? x.Id != tipoMaoObra.Id : x.Id != 0)
                            .Where(x => x.Codigo == tipoMaoObra.Codigo)
                            .Where(x => x.Nome == tipoMaoObra.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}