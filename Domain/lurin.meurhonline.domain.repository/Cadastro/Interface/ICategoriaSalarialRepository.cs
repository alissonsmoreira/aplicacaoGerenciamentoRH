using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ICategoriaSalarialRepository<T> : IRepositoryCustom<T>
    {
        T GetCategoriaSalarialbyId(int id);
        IEnumerable<T> GetCategoriaSalarial(T categoriaSalarial);
        T GetCategoriaSalarialValidation(T categoriaSalarial);
    }
}