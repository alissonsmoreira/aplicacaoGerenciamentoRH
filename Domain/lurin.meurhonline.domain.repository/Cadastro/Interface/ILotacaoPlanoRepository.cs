using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface ILotacaoPlanoRepository<T> : IRepositoryCustom<T>
    {
        T GetLotacaoPlanobyId(int id);
        IEnumerable<T> GetLotacaoPlano(T lotacaoPlano);
        T GetLotacaoPlanoValidation(T lotacaoPlano);
    }
}