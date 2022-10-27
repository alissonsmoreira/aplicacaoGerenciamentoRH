using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IEmpresaRepository<T> : IRepositoryCustom<T>
    {
        T GetEmpresabyId(int id);
        IEnumerable<T> GetEmpresa(T empresa);
        IEnumerable<T> GetEmpresaByNome(string nomeEmpresa);
        IEnumerable<T> GetEmpresaMatrizByNome(string nomeEmpresa);
        T GetEmpresaValidation(T empresa);
        IEnumerable<T> GetEmpresaGrupoByEmpresaMatrizId(int id);
    }
}