using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IOperadoraVTBandeiraCartaoRepository<T> : IRepositoryCustom<T>
    {
        T GetOperadoraVTBandeiraCartaobyId(int id);
        IEnumerable<T> GetOperadoraVTBandeiraCartao(T operadoraVTBandeiraCartao);
        T GetOperadoraVTBandeiraCartaoValidation(T operadoraVTBandeiraCartao);
    }
}