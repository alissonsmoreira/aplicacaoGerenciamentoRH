using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ITurnoRepository<T> : IRepositoryCustom<T>
    {
        T GetTurnobyId(int id);
        IEnumerable<T> GetTurno(T turno);
        T GetTurnoDetalhebyTurnoId(int id);
    }

}