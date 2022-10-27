using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IUsuarioRepository<T> : IRepositoryCustom<T>
    {
        T GetUsuariobyId(int id);
        IEnumerable<T> GetUsuario(T usuario);
        T GetUsuarioValidation(T usuario);
    }
}