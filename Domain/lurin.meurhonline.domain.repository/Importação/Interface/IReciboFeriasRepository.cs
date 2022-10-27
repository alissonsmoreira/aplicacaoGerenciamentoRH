using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IReciboFeriasRepository<T> : IRepositoryCustom<T>
    {
        T GetReciboFeriasById(int id);
        IEnumerable<T> GetReciboFeriasAnoColaboradorById(string ano, int colaboradorId);
    }
}