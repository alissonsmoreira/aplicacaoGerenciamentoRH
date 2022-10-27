using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICentroCustoPlanoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetCentroCustoPlanoUnidadeById(int centroCustoPlanoId, int centroCustoUnidadeId);
        IEnumerable<T> GetCentroCustoPlanoUnidade(T centroCustoPlanoUnidade);
        IEnumerable<T> GetCentroCustoPlanoUnidadeByCentroCustoPlanoId(int centroCustoPlanoId);
        IEnumerable<T> GetCentroCustoUnidadeByEmpresaId(int empresaId);
    }
}