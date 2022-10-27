using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CartaoPontoDetalheRepository : ICartaoPontoDetalheRepository<CartaoPontoDetalheModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CartaoPontoDetalheRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public IEnumerable<CartaoPontoDetalheModel> GetByCartaoPontoId(int id)
        {
            var result = _db.CartaoPontoDetalhe
                            .Include(x => x.CartaoPonto)
                            .Where(x => x.CartaoPontoId == id)
                            .ToList();

            return result;
        }
    }
}
