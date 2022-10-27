using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class ReciboFeriasVencimentoModel
    {
        public int Id { get; set; }
        public string Evento { get; set; }
        public string Descricao { get; set; }
        public string BaseCalculo { get; set; }
        public string Valor { get; set; }
        public int ReciboFeriasId { get; set;}
        [JsonIgnore]
        public ReciboFeriasModel ReciboFerias { get; set; }
    }
}