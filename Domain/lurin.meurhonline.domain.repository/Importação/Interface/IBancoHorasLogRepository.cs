using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IBancoHorasLogRepository<T> : IRepositoryCustom<T>
    {
        T GetBancoHorasLogById(int id);
        IEnumerable<T> GetBancoHorasLogByEmpresaId(int empresaId);
    }
}