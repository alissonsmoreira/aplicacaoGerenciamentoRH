using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ISindicatoRepository<T> : IRepositoryCustom<T>
    {
        T GetSindicatobyId(int id);
        IEnumerable<T> GetSindicato(T sindicato);
        T GetSindicatoValidation(T sindicato);
    }
}