using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IOperadoraVTRepository<T> : IRepositoryCustom<T>
    {
        T GetOperadoraVTbyId(int id);
        IEnumerable<T> GetOperadoraVT(T operadoraVT);
        IEnumerable<T> GetOperadoraVTByNome(string nomeOperadoraVT);
        T GetOperadoraVTValidation(T operadoraVT);
    }
}