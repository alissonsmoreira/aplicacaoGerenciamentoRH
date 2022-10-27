using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class FeriasPeriodoModel
    {
        public FeriasPeriodoModel()
        {
            Concessao = new List<FeriasConcessaoModel>();
        }
        public int Id { get; set; }
        public string InicioPeriodo { get; set; }
        public string FimPeriodo { get; set; }
        public string Situacao { get; set; }
        public string DiasDireito { get; set; }
        public string DiasConcedidos { get; set; }
        public string DiasProgramados { get; set; }        
        public ICollection<FeriasConcessaoModel> Concessao { get; set; }
        public int? SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime? DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int FeriasId { get; set; }
        [JsonIgnore]
        public FeriasModel Ferias { get; set; } 
        public string Saldo { get; set; }
    }
}