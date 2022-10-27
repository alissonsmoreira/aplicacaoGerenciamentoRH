using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface ICartaoPontoDomain<T> : IOperation<T>
    {
        List<CartaoPontoModel> AdicionarCartaoPonto(CartaoPontoModel cartaoPonto);
    }
}