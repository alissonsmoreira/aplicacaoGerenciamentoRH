using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class BeneficioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RegraDesconto{ get; set; }           
        public decimal CustoBeneficio { get; set; }
        public int BeneficioTipoId { get; set; }
        public BeneficioTipoModel BeneficioTipo { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}