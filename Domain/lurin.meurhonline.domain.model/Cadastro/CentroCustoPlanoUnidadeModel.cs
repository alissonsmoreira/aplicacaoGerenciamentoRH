using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class CentroCustoPlanoUnidadeModel
    {
        public int CentroCustoPlanoId { get; set; }
        [JsonIgnore]
        public CentroCustoPlanoModel CentroCustoPlano { get; set; }
        public int CentroCustoUnidadeId { get; set; }
        public CentroCustoUnidadeModel CentroCustoUnidade { get; set; }

    }
}