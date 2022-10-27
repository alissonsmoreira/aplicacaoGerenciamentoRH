using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICentroCustoPlanoRepository<T> : IRepositoryCustom<T>
    {
        T GetCentroCustoPlanobyId(int id);
        IEnumerable<T> GetCentroCustoPlano(T centroCustoPlano);
        T GetCentroCustoPlanoValidation(T centroCustoPlano);
    }
}