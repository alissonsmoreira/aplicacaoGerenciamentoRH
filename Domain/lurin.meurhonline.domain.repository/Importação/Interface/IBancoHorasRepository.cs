using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IBancoHorasRepository<T> : IRepositoryCustom<T>
    {
        T GetBancoHorasById(int id);
        IEnumerable<T> GetBancoHorasByEmpresaId(int empresaId);
    }
}