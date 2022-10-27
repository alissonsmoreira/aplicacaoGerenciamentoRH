using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICargoPlanoRepository<T> : IRepositoryCustom<T>
    {
        T GetCargoPlanobyId(int id);
        IEnumerable<T> GetCargoPlano(T cargoPlano);
        T GetCargoPlanoValidation(T cargoPlano);
    }
}