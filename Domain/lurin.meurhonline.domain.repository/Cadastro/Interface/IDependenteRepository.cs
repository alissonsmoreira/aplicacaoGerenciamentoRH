using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDependenteRepository<T> : IRepositoryCustom<T>
    {
        T GetDependentebyId(int id);
        IEnumerable<T> GetDependentebyIds(IEnumerable<int> ids);
        IEnumerable<T> GetDependente(T dependente);
        T GetDependenteValidation(T dependente);
    }
}