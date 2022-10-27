using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class CartaoPontoModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }

        public string Mes { get; set; }
        public string Ano { get; set; }

        public ICollection<CartaoPontoCabecalhoModel> CartaoPontoCabecalho { get; set; }

        public ICollection<CartaoPontoDetalheModel> CartaoPontoDetalhe { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }
        public DateTime DataCadastro { get; set; }
        public string MotivoReprovacao { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}