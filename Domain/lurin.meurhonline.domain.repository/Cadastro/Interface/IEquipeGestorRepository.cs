using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IEquipeGestorRepository<T> : IRepositoryCustom<T>
    {
        T GetEquipeGestorbyId(int id);
        IEnumerable<T> GetEquipeGestor(T equipeGestor);
        T GetEquipeGestorValidation(T equipeGestor);
    }
}