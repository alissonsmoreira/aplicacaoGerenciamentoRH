using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IValeTransporteRepository<T> : IRepositoryCustom<T>
    {
        IEnumerable<T> GetValeTransporte(T ValeTransporte);
        T GetValeTransportebyId(int id);
        IEnumerable<T> GetValeTransportebyColaboradorId(int id);
        T GetValeTransporteValidation(T ValeTransporte);
    }
}