using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lurin.meurhonline.domain.Interface
{
    public interface IReciboFeriasDomain<T> : IOperation<T>
    {
        IList<T> ImportarReciboFerias(ReciboFeriasModel reciboFerias);
    }
}
