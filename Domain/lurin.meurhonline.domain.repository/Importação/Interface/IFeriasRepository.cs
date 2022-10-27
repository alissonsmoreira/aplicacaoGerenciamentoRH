using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IFeriasRepository<T> : IRepositoryCustom<T>
    {
        T GetFeriasById(int id);
        IEnumerable<T> GetFeriasByEmpresaId(int empresaId);

        IEnumerable<T> GetFeriasByColaboradorId(int colaboradorId);
    }
}