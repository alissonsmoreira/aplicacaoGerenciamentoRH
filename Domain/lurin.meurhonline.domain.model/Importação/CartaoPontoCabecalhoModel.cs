using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class CartaoPontoCabecalhoModel
    {
        public int Id { get; set; }
        public int CartaoPontoId { get; set; }
        [JsonIgnore]
        public CartaoPontoModel CartaoPonto { get; set; }
        public string Estabelecimento { get; set; }
        public string Matricula { get; set; }
        public string DataInicioPeriodo { get; set; }
        public string DataTerminoPeriodo { get; set; }
        public string PeriodoBancoHoras { get; set; }
        public string HorasPositivas1 { get; set; }
        public string HorasNegativas1 { get; set; }
        public string SaldoMes1 { get; set; }
        public string PeriodoDiaPonte { get; set; }
        public string HorasPositivas2 { get; set; }
        public string HorasNegativas2 { get; set; }
        public string SaldoMes2 { get; set; }
        public string CodigoEvento1 { get; set; }
        public string DescricaoEvento1 { get; set; }
        public string QuantidadeHoras1 { get; set; }
        public string HorasPositivasBancoHoras { get; set; }
        public string HorasPositivasDiaPonte { get; set; }
        public string CodigoEvento2 { get; set; }
        public string DescricaoEvento2 { get; set; }
        public string QuantidadeHoras2 { get; set; }
        public string HorasNegativasBancoHoras { get; set; }
        public string HorasNegativasDiaPonte { get; set; }
        public string CodigoEvento3 { get; set; }
        public string DescricaoEvento3 { get; set; }
        public string QuantidadeHoras3 { get; set; }
        public string SaldoBancoHoras { get; set; }
        public string SaldoDiaPonte { get; set; }
        public string CodigoEvento4 { get; set; }
        public string DescricaoEvento4 { get; set; }
        public string QuantidadeHoras4 { get; set; }
        public string HrsPagasBancoHoras { get; set; }
        public string HrsPagasDiaPonte { get; set; }
        public string CodigoEvento5 { get; set; }
        public string DescricaoEvento5 { get; set; }
        public string QuantidadeHoras5 { get; set; }
        public string HrsDescontadasBancoHoras { get; set; }
        public string HrsDescontadasDiaPonte { get; set; }
        public string CodigoEvento6 { get; set; }
        public string DescricaoEvento6 { get; set; }
        public string QuantidadeHoras6 { get; set; }
        public string HrsCompensadasBancoHoras { get; set; }
        public string HrsCompensadasDiaPonte { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}