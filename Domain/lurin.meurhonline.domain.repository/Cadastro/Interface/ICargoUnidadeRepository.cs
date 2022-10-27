using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICargoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetCargoUnidadebyId(int id);
        IEnumerable<T> GetCargoUnidade(T cargoUnidade);
        T GetCargoUnidadeValidation(T cargoUnidade);

    }
}