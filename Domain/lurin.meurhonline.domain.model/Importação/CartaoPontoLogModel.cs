using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class CartaoPontoLogModel
    {
        public int Id { get; set; }

        public string Matricula { get; set; }

        public string LogErro { get; set; }

        [JsonIgnore]
        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
