using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IBeneficioRepository<T> : IRepositoryCustom<T>
    {
        T GetBeneficiobyId(int id);
        IEnumerable<T> GetBeneficio(T beneficio);
        T GetBeneficioValidation(T beneficio);
    }
}