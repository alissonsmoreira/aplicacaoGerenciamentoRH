using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ILotacaoPlanoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetLotacaoPlanoUnidadeById(int lotacaoPlanoId, int lotacaoUnidadeId);
        IEnumerable<T> GetLotacaoPlanoUnidade(T lotacaoPlanoUnidade);
        IEnumerable<T> GetLotacaoPlanoUnidadeByLotacaoPlanoId(int lotacaoPlanoId);
        IEnumerable<T> GetLotacaoUnidadeByEmpresaId(int empresaId);
    }
}