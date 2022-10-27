using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IBeneficioColaboradorRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetBeneficioColaborador(T beneficioColaborador);
        T GetBeneficioColaboradorbyId(int id);
        IEnumerable<T> GetBeneficioColaboradorbyColaboradorId(int id);
        T GetBeneficioColaboradorValidation(T beneficioColaborador);
    }
}