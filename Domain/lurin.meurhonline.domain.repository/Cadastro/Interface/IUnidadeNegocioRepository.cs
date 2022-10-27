using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IUnidadeNegocioRepository<T> : IRepositoryCustom<T>
    {
        T GetUnidadeNegociobyId(int id);
        IEnumerable<T> GetUnidadeNegocio(T unidadeNegocio);
        T GetUnidadeNegocioValidation(T unidadeNegocio);
    }
}