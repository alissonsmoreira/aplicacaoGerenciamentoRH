using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class LotacaoPlanoUnidadeModel
    {
        public int LotacaoPlanoId { get; set; }
        [JsonIgnore]
        public LotacaoPlanoModel LotacaoPlano { get; set; }
        public int LotacaoUnidadeId { get; set; }
        public LotacaoUnidadeModel LotacaoUnidade { get; set; }

    }
}