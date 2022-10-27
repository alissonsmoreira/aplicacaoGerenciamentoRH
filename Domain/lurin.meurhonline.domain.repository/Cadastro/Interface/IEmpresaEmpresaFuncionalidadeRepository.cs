using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IEmpresaEmpresaFuncionalidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetEmpresaEmpresaFuncionalidadeById(int empresaId, int empresaEmpresaFuncionalidadeId);
        IEnumerable<T> GetEmpresaEmpresaFuncionalidade(T empresaEmpresaFuncionalidadeI);
        IEnumerable<T> GetEmpresaEmpresaFuncionalidadeByEmpresaId(int empresaId);
    }
}