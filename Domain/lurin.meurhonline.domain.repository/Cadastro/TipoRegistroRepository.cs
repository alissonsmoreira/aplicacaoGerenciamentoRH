using System.Linq;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class TipoRegistroRepository : ITipoRegistroRepository<TipoRegistroModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public TipoRegistroRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public TipoRegistroModel GetTipoRegistrobyId(int id)
        {
            var result = _db.TipoRegistro
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<TipoRegistroModel> GetTipoRegistro(TipoRegistroModel tipoRegistro)
        {
            var result = _db.TipoRegistro
                            .Where(x => !string.IsNullOrEmpty(tipoRegistro.Nome) ? x.Nome.Contains(tipoRegistro.Nome) : x.Nome != string.Empty)
                            .ToList();

            return result;
        }

        public TipoRegistroModel GetTipoRegistroValidation(TipoRegistroModel tipoRegistro)
        {
            var result = _db.TipoRegistro
                            .Where(x => tipoRegistro.Id != 0 ? x.Id != tipoRegistro.Id : x.Id != 0)
                            .Where(x => x.Nome == tipoRegistro.Nome)
                            .FirstOrDefault();

            return result;
        }
    }
}