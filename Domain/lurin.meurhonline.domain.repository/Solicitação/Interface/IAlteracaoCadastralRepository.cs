using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IAlteracaoCadastralRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetAlteracaoCadastral(T alteracaoCadastral);
        T GetAlteracaoCadastralbyId(int id);
        IEnumerable<T> GetAlteracaoCadastralbyColaboradorId(int id);
        T GetAlteracaoCadastralValidation(T alteracaoCadastral);
    }
}