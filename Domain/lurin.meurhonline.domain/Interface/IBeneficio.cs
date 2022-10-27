using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface IBeneficio<T> : IOperation<T>
    {
        //IList<T> BuscarBeneficio(T beneficio);
        //T AdicionarBeneficio(T beneficio);        
        //T ExcluirBeneficio(int id);
    }
}