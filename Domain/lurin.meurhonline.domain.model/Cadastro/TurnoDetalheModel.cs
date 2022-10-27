using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class TurnoDetalheModel
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public string HorarioInicial{ get; set; }
        public string HorarioFinal { get; set; }
        public int TurnoId { get; set; }
        [JsonIgnore]
        public TurnoModel Turno { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
