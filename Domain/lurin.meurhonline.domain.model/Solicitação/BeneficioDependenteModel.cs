using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class BeneficioDependenteModel
    {
        public int Id { get; set; }
        public int DependenteId { get; set; }
        public DependenteModel Dependente { get; set; }
        public int BeneficioId { get; set; }
        public BeneficioModel Beneficio { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoBeneficioDependenteStatusModel SolicitacaoStatus { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}