using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IAtestadoRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetAtestado(T atestado);
        T GetAtestadobyId(int id);
        IEnumerable<T> GetAtestadobyColaboradorId(int id);
        T GetAtestadoValidation(T atestado);
    }
}