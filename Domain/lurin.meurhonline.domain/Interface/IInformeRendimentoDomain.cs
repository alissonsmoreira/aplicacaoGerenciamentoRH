using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lurin.meurhonline.domain.Interface
{
    public interface IInformeRendimentoDomain<T> : IOperation<T>
    {
        //IList<T> BuscarBeneficio(T beneficio);
        //T AdicionarBeneficio(T beneficio);        
        //T ExcluirBeneficio(int id);
        IList<T> ImportarInformeRendimento(InformeRendimentoModel infomeRendimento);
    }
}
