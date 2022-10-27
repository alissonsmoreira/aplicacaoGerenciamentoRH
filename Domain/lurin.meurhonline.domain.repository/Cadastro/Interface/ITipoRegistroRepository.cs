using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ITipoRegistroRepository<T> : IRepositoryCustom<T>
    {
        T GetTipoRegistrobyId(int id);
        IEnumerable<T> GetTipoRegistro(T TipoRegistro);
        T GetTipoRegistroValidation(T TipoRegistro);
    }
}