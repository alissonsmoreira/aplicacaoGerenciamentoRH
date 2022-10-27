using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICargoPlanoUnidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetCargoPlanoUnidadeById(int cargoPlanoId, int cargoUnidadeId);
        IEnumerable<T> GetCargoPlanoUnidade(T cargoPlanoUnidade);
        IEnumerable<T> GetCargoPlanoUnidadeByCargoPlanoId(int cargoPlanoId);
        IEnumerable<T> GetCargoUnidadeByEmpresaId(int empresaId);
    }
}