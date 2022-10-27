using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICentroCustoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetCentroCustoUnidadebyId(int id);
        IEnumerable<T> GetCentroCustoUnidade(T centroCustoUnidade);
        T GetCentroCustoUnidadeValidation(T centroCustoUnidade);
    }
}