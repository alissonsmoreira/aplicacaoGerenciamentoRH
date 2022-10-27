using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IAvisoFeriasRepository<T> : IRepositoryCustom<T>
    {
        T GetAvisoFeriasById(int id);
        IEnumerable<T> GetAvisoFeriasByColaboradorIdAno(int colaboradorId, string ano);
    }
}
