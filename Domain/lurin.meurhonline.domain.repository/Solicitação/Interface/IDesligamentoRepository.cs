using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IDesligamentoRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetDesligamento(T desligamento);
        T GetDesligamentobyId(int id);
        IEnumerable<T> GetDesligamentobyColaboradorId(int id);
        T GetDesligamentoValidation(T desligamento);
    }
}