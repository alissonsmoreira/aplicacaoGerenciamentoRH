using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class CartaoPontoDetalheModel
    {
        public int Id { get; set; }
        public int CartaoPontoId { get; set; }
        [JsonIgnore]
        public CartaoPontoModel CartaoPonto { get; set; }
        public string Dia { get; set; }
        public string DiaSemana { get; set; }
        public string NumeroJornada { get; set; }
        public string TipoDia { get; set; }
        public string Marcacao1 { get; set; }
        public string TipoMarcacao1 { get; set; }
        public string Marcacao2 { get; set; }
        public string TipoMarcacao2 { get; set; }
        public string Marcacao3 { get; set; }
        public string TipoMarcacao3 { get; set; }
        public string Marcacao4 { get; set; }
        public string TipoMarcacao4 { get; set; }
        public string Marcacao5 { get; set; }
        public string TipoMarcacao5 { get; set; }
        public string Marcacao6 { get; set; }
        public string TipoMarcacao6 { get; set; }
        public string Marcacao7 { get; set; }
        public string TipoMarcacao7 { get; set; }
        public string Marcacao8 { get; set; }
        public string TipoMarcacao8 { get; set; }
        public string InicioJornada { get; set; }
        public string TerminoJornada { get; set; }
        public string QuantHoras { get; set; }
        public string DescricaoOcorrencia { get; set; }
  
        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}