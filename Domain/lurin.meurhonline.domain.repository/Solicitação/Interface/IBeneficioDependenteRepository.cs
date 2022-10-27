using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IBeneficioDependenteRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetBeneficioDependente(T beneficioDependente);
        T GetBeneficioDependentebyId(int id);
        IEnumerable<T> GetBeneficioDependentebyDependenteId(int id);
        T GetBeneficioDependenteValidation(T beneficioDependente);
    }
}