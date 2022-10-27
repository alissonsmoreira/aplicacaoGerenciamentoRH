using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IEmpresaFuncionalidadeRepository<T> : IRepositoryCustom<T>
    {
        T GetEmpresaFuncionalidadebyId(int id);
        IEnumerable<T> GetEmpresaFuncionalidade(T EmpresaFuncionalidade);
        IEnumerable<T> GetEmpresaFuncionalidadePadrao();
        
    }
}