using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class EmpresaEmpresaFuncionalidadeModel
    {
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public EmpresaModel Empresa { get; set; }
        public int EmpresaFuncionalidadeId { get; set; }
        public EmpresaFuncionalidadeModel EmpresaFuncionalidade { get; set; }

    }
}