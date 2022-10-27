using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IMovimentacaoContratualRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetMovimentacaoContratual(T movimentacaoContratual);
        T GetMovimentacaoContratualbyId(int id);
        IEnumerable<T> GetMovimentacaoContratualbyColaboradorId(int id);
        T GetMovimentacaoContratualValidation(T movimentacaoContratual);
    }
}