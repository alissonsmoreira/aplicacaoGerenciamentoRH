using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICartaoPontoRepository<T> : IRepositoryCustom<T>
    {
        T GetCartaoPontoById(int id);
        IEnumerable<T> GetCartaoPontoByColaboradorIdMesAno(int colaboradorId, string mes, string ano);
    }
}