using System.Collections.Generic;
using System.Web;
using lurin.meurhonline.domain.model;
using lurin.meurhonline.infrastructure.factory.interfaces;

namespace lurin.meurhonline.domain.Interface
{
    public interface IAbsenteismoDomain<T> : IOperation<T>
    {
        IList<T> ConverterArquivoExcel(string excelBase64);
    }
}