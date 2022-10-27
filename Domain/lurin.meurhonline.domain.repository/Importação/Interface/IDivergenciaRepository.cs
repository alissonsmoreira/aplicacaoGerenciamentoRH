using System;
using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDivergenciaRepository<T> : IRepositoryCustom<T>
    {
        T GetDivergenciaById(int id);
        IEnumerable<T> GetDivergenciaByColaboradorIdData(int? colaboradorId, DateTime inicio, DateTime fim);
    }
}