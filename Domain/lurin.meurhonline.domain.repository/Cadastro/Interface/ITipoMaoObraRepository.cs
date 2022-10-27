using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ITipoMaoObraRepository<T> : IRepositoryCustom<T>
    {
        T GetTipoMaoObrabyId(int id);
        IEnumerable<T> GetTipoMaoObra(T tipoMaoObra);
        T GetTipoMaoObraValidation(T tipoMaoObra);
    }
}