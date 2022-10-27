using System;
using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDivergenciaDetalheRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetDivergenciaDetalheByColaboradorIdData(int colaboradorId, DateTime inicio, DateTime fim);
    }
}