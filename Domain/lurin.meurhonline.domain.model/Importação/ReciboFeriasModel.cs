using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class ReciboFeriasModel
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Estabelecimento { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string CPF { get; set; }
        public string InicioPeriodoAquisitivo { get; set; }
        public string FImPeriodoAquisitivo { get; set; }
        public string InicioPeriodoGozo { get; set; }
        public string FimPeriodoGozo { get; set; }
        public string DiasGozo { get; set; }
        public string InicioPeriodoAbono { get; set; }
        public string FimPeriodoAbono { get; set; }
        public string InicioPeriodoLicenca { get; set; }
        public string FimPeriodoLicenca { get; set; }
        public ICollection<ReciboFeriasVencimentoModel> Vencimentos { get; set; }
        public string TotalVencimento { get; set; }
        public ICollection<ReciboFeriasDescontoModel> Descontos { get; set; }
        public string TotalDescontos { get; set; }
        public string TotalLiquido { get; set; }
        public string Texto { get; set; }
        public string LocalData { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}