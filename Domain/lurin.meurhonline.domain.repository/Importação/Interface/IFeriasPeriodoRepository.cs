using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IFeriasPeriodoRepository<T> : IRepositoryCustom<T>
    {
        T GetFeriasPeriodoById(int id);
    }
}