using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class MovimentacaoContratualModel
    {
        public int Id { get; set; }
        public int GestorId { get; set; }
        [NotMapped]
        public ColaboradorModel Gestor { get; set; }
        public int ColaboradorId { get; set; }
        [NotMapped]
        public ColaboradorModel Colaborador { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int LotacaoUnidadeId { get; set; }
        public LotacaoUnidadeModel LotacaoUnidade { get; set; }
        public int CentroCustoUnidadeId { get; set; }
        public CentroCustoUnidadeModel CentroCustoUnidade { get; set; }
        public int CargoUnidadeId { get; set; }
        public CargoUnidadeModel CargoUnidade { get; set; }
        public int TurnoId { get; set; }
        public TurnoModel Turno { get; set; }
        public int UnidadeNegocioId { get; set; }
        public UnidadeNegocioModel UnidadeNegocio { get; set; }
        public string NumeroCartaoPonto { get; set; }
        public int TipoMaoObraId { get; set; }
        public TipoMaoObraModel TipoMaoObra { get; set; }
        public decimal Salario { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}