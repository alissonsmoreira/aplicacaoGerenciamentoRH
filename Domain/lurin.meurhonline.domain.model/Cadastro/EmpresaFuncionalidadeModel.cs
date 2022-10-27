using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class EmpresaFuncionalidadeModel
    {
        public int Id { get; set; }
        public string Grupo { get; set; }
        public string TipoFuncionario { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<EmpresaEmpresaFuncionalidadeModel> EmpresaEmpresaFuncionalidades { get; set; }
    }
}
