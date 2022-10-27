using System.Collections.Generic;

using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IInformeRendimentoRepository<T> : IRepositoryCustom<T>
    {
        T GetInformeRendimentoById(int id);
        IEnumerable<T> GetInformeRendimentoByColaboradorId(int colaboradorId);
        T GetInformeRendimentoByColaboradorIdAno(int colaboradorId, string ano);
    }
}