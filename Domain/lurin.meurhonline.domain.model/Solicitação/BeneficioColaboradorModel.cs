using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class BeneficioColaboradorModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int BeneficioId { get; set; }
        public BeneficioModel Beneficio { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}