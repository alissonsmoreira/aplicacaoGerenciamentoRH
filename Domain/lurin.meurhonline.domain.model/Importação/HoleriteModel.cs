using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class HoleriteModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public ICollection<HoleriteEventoModel> HoleriteEventos { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string TotalProventos { get; set; }
        public string TotalDescontos { get; set; }
        public string Liquido { get; set; }
        public string SalarioBase { get; set; }
        public string SalarioContrINSS { get; set; }
        public string BaseCalcFGTS { get; set; }
        public string FTGSMes { get; set; }
        public string BaseCalcIRRF { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}