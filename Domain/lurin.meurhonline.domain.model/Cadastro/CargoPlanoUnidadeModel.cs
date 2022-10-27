using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class CargoPlanoUnidadeModel
    {
        public int CargoPlanoId { get; set; }
        [JsonIgnore]
        public CargoPlanoModel CargoPlano { get; set; }
        public int CargoUnidadeId { get; set; }
        public CargoUnidadeModel CargoUnidade { get; set; }

    }
}