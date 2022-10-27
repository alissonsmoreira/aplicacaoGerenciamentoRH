using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.repository.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;

namespace lurin.meurhonline.domain.repository
{
    public class CartaoPontoRepository : ICartaoPontoRepository<CartaoPontoModel>
    {
        private readonly IUnitOfWorkCustom _db;

        public CartaoPontoRepository(IUnitOfWorkCustom unitOfWork)
        {
            _db = unitOfWork;
        }

        public CartaoPontoModel GetCartaoPontoById(int id)
        {
            var result = _db.CartaoPonto
                            .Where(x => x.Id == id)
                            .Include(x => x.Colaborador)
                            .Include(x => x.CartaoPontoDetalhe)
                            .Include(x => x.CartaoPontoCabecalho)
                            .FirstOrDefault();

            return result;
        }

        public IEnumerable<CartaoPontoModel> GetCartaoPontoByColaboradorIdMesAno(int colaboradorId, string mes, string ano)
        {
            var result = _db.CartaoPonto
                            .Where(x => x.ColaboradorId == colaboradorId && x.Mes == mes && x.Ano == ano)
                            .Include(x => x.CartaoPontoCabecalho)
                            .Include(x => x.CartaoPontoDetalhe)
                            .OrderByDescending(x => x.DataCadastro)
                            .ToList();

            return result;
        }

        public IEnumerable<CartaoPontoModel> GetCartaoPontoByColaboradorId(int colaboradorId)
        {
            var result = _db.CartaoPonto
                            .Where(x => x.ColaboradorId == colaboradorId)
                            .Include(x => x.CartaoPontoCabecalho)
                            .Include(x => x.CartaoPontoDetalhe)
                            .OrderByDescending(x => x.Ano)
                            .OrderByDescending(x => x.Mes)
                            .ToList();

            return result;
        }
    }
}