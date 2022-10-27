using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class NotificacaoModel
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        public int NotificacaoDetalheId { get; set; }
        public NotificacaoDetalheModel NotificacaoDetalhe { get; set; }

        [JsonIgnore]
        public int NotificacaoStatusLeituraId { get; set; }

        [NotMapped]
        public NotificacaoStatusLeituraModel NotificacaoStatusLeitura { get; set; }
        
        [JsonIgnore]
        public int ById { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
