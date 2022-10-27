using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface IAvisoFeriasDomain<T> : IOperation<T>
    {
        bool DecodeArquivoTxtAvisoFerias(AvisoFeriasModel avisoFerias);
        List<AvisoFeriasModel> AdicionarAvisoFerias(AvisoFeriasModel AvisoFeriasModel);
    }
}
