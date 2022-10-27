using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class CentroCustoUnidadeModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public ICollection<CentroCustoPlanoUnidadeModel> CentroCustoPlanosUnidades { get; set; }
    }
}