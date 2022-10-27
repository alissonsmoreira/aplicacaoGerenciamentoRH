using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CartaoPontoCabecalhoRepository : ICartaoPontoCabecalhoRepository<CartaoPontoCabecalhoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CartaoPontoCabecalhoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public IEnumerable<CartaoPontoCabecalhoModel> GetByCartaoPontoId(int id)
        {
            var result = _db.CartaoPontoCabecalho
                            .Where(x => x.CartaoPontoId == id)
                            .ToList();

            return result;
        }

    }
}
