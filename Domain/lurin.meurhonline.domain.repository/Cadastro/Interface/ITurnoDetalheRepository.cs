using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ITurnoDetalheRepository<T> : IRepositoryCustom<T>
    {
        T GetTurnoDetalhebyId(int id);
        IEnumerable<T> GetTurnoDetalhe(T turnoDetalhe);
    }

}