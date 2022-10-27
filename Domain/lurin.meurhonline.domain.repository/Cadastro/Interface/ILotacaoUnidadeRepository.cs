using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ILotacaoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetLotacaoUnidadebyId(int id);
        IEnumerable<T> GetLotacaoUnidade(T lotacaoUnidade);
        T GetLotacaoUnidadeValidation(T lotacaoUnidade);
    }
}