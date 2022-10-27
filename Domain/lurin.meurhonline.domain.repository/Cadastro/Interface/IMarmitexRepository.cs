using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IMarmitexRepository<T> : IRepositoryCustom<T>
    {
        T GetMarmitexbyId(int id);
        IEnumerable<T> GetMarmitex(T marmitex);
        T GetMarmitexValidation(T marmitex);
    }
}