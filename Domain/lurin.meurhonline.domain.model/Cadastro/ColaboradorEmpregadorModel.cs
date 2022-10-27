using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorEmpregadorModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int CargoUnidadeId { get; set; }
        public CargoUnidadeModel CargoUnidade { get; set; }
        public int CentroCustoUnidadeId { get; set; }
        public CentroCustoUnidadeModel CentroCustoUnidade { get; set; }
        public int LotacaoUnidadeId { get; set; }
        public LotacaoUnidadeModel LotacaoUnidade { get; set; }
        public int? TipoRegistroId { get; set; }
        public TipoRegistroModel TipoRegistro { get; set; }
        public int? TipoMaoObraId { get; set; }
        public TipoMaoObraModel TipoMaoObra { get; set; }
        public int? UnidadeNegocioId { get; set; }
        public UnidadeNegocioModel UnidadeNegocio { get; set; }
        public string NumeroCartaoPonto { get; set; }
        public string Situacao { get; set; }
        public int? TurnoId { get; set; }
        public TurnoModel Turno { get; set; }
        public int? CategoriaSalarialId { get; set; }
        public CategoriaSalarialModel CategoriaSalarial { get; set; }
        public decimal Salario { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public int? SindicatoId { get; set; }
        public SindicatoModel Sindicato { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}