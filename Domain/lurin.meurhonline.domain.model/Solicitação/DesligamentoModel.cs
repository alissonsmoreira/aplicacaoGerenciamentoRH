using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class DesligamentoModel
    {
        public int Id { get; set; }
        public int GestorId { get; set; }
        [NotMapped]
        public ColaboradorModel Gestor { get; set; }
        public int ColaboradorId { get; set; }
        [NotMapped]
        public ColaboradorModel Colaborador { get; set; }
        public DateTime DataSugerida { get; set; }
        public int DesligamentoTipoId { get; set; }
        public DesligamentoTipoModel DesligamentoTipo { get; set; }
        public string Motivo { get; set; }
        public bool Substituir { get; set; }
        public bool Recontrataria { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataDesligamento { get; set; }
    }
}