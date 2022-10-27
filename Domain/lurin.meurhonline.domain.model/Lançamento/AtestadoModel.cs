using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class AtestadoModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public DateTime DataAtestado { get; set; }
        public string HorarioChegada { get; set; }
        public string HorarioSaida { get; set; }
        public int QuantidadeDias { get; set; }
        public string CID { get; set; }
        public string AtestadoNome { get; set; }
        [NotMapped]
        public string AtestadoBase64 { get; set; }
        public int LancamentoStatusId { get; set; }
        [NotMapped]
        public LancamentoStatusModel LancamentoStatus { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}