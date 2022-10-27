using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IMenuRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetMenuUsuario();
        IEnumerable<T> GetMenuGestor();
        IEnumerable<T> GetMenuFuncionario();
        IEnumerable<T> GetMenuPreAdmissao();        
    }
}