using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class DivergenciaDetalheModel
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Dia { get; set; }
        public string Horario1 { get; set; }
        public string Horario2 { get; set; }
        public string Horario3 { get; set; }
        public string Horario4 { get; set; }
        public string InicioJornada { get; set; }
        public string FimJornada { get; set; }
        public string DiferencaHoras { get; set; }
        public string Descricao { get; set; }
        public int DivergenciaId { get; set; }
        [JsonIgnore]
        public DivergenciaModel Divergencia { get; set; }
        public string MotivoAprovacao { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public int? JustificativaDivergenciaId { get; set; }
        public JustificativaDivergenciaModel JustificativaDivergencia { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}