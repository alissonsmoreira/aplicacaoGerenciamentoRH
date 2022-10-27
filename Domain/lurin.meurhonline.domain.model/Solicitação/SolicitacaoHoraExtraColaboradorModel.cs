using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class SolicitacaoHoraExtraColaboradorModel
    {
        public int Id { get; set; }
        public int SolicitacaoHoraExtraId { get; set; }      
        [JsonIgnore]
        public SolicitacaoHoraExtraModel SolicitacaoHoraExtra { get; set; }
        public int? ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int? SolicitacaoStatusId { get; set; }
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}