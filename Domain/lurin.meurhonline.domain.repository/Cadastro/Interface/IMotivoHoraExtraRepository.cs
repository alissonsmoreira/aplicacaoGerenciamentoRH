using System.Collections.Generic;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.repository.interfaces
{
    public interface IMotivoHoraExtraRepository<T> : IRepositoryCustom<T>
    {
        T GetMotivoHoraExtrabyId(int id);
        IEnumerable<T> GetMotivoHoraExtra(T MotivoHoraExtra);
        T GetMotivoHoraExtraValidation(T MotivoHoraExtra);
    }
}