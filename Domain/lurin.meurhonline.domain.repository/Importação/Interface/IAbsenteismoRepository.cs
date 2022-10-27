using System.Collections.Generic;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IAbsenteismoRepository<T> : IRepositoryCustom<T>
    {
        T GetAbsenteismoByColaboradorIdAnoMes(int colaboradorId, string ano, string mes);
        List<T> GetAbsenteismoByAnoMes(string ano, string mes);
        List<T> GetAbsenteismoByColaboradorId(int colaboradorId);
    }
}
