using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class HoleriteEventoModel
    {
        public int Id { get; set; }
        public int HoleriteId { get; set; }
        [JsonIgnore]
        public HoleriteModel Holerite { get; set; }
        public string Evento { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public string ValoresPositivos { get; set; }
        public string ValoresNegativos { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}