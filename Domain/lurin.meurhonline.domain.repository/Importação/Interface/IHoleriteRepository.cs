using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IHoleriteRepository<T> : IRepositoryCustom<T>
    {
        T GetHoleriteById(int id);
        IEnumerable<T> GetHoleriteByColaboradorIdMesAno(int? colaboradorId, string mes, string ano, int? empresaId);
        bool ExcluirHolerites(List<HoleriteModel> holerites);
    }
}