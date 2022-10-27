using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IJustificativaDivergenciaRepository<T> : IRepositoryCustom<T>
    {
        T GetJustificativaDivergenciabyId(int id);
        IEnumerable<T> GetJustificativaDivergencia(T justificativaDivergencia);
        T GetJustificativaDivergenciaValidation(T justificativaDivergencia);
    }
}