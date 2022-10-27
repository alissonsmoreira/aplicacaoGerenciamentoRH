using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.interfaces
{
    public interface IHoleriteDomain<T> : IOperation<T>
    {
        bool DecodeArquivoTxtHolerite(HoleriteModel holeriteModel);
        bool DecodeArquivoXlsHolerite(HoleriteModel holeriteModel);
        List<HoleriteModel> AdicionarHolerite(HoleriteModel holeriteModel);
    }
}
