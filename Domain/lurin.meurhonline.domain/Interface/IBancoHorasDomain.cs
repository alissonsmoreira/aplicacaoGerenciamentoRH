using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface IBancoHorasDomain<T> : IOperation<T>
    {
        ICollection<BancoHorasModel> AdicionarBancoHorasDetahes(BancoHorasModel BancoHoras);
    }
}