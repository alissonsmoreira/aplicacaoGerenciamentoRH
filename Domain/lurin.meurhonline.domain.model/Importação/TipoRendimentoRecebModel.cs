using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class TipoRendimentoRecebModel
    {
        public int Id { get; set; }
        public string DescricaoTipoEvento { get; set; }
        public string Valor{ get; set; }
        public string Processo { get; set; }
        public string NaturezaRendimento { get; set; }
        
        public int InformeRendimentoId { get; set; }
        [JsonIgnore]
        public InformeRendimentoModel InformeRendimento { get; set; }
    }
}