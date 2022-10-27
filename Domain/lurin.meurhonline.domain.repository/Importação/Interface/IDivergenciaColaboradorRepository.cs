using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDivergenciaColaboradorRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetDivergenciaColaboradorByDivergenciaId(int divergenciaid);
    }
}