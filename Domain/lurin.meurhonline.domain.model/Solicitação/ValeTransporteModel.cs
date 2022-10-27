using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ValeTransporteModel
    {
        public int Id { get; set; }
        
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int OperadoraVTId { get; set; }
        [NotMapped]
        public OperadoraVTModel OperadoraVT { get; set; }
        public int LinhaVTId { get; set; }
        [NotMapped]
        public LinhaVTModel LinhaVT { get; set; }
        public int ValeTransporteUtilizacaoId { get; set; }
        public ValeTransporteUtilizacaoModel ValeTransporteUtilizacao { get; set; }
        public int ValeTransporteSituacaoId { get; set; }
        public ValeTransporteSituacaoModel ValeTransporteSituacao { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public string DiasSemana { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}