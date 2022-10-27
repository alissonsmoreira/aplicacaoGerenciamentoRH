using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ILinhaVTRepository<T> : IRepositoryCustom<T>
    {
        T GetLinhaVTbyId(int id);
        IEnumerable<T> GetLinhaVT(T LinhaVT);
        T GetLinhaVTValidation(T LinhaVT);
    }
}