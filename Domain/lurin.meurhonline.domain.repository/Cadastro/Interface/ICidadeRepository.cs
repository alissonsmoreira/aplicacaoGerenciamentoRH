using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICidadeRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetCidadebyUF(string uf);

    }
}