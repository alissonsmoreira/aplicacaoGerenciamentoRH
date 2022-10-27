using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorDocumentacaoModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public string RG { get; set; }
        public string OrgaoEmissorRG { get; set; }
        public string UFEmissaoRG { get; set; }
        public DateTime? DataEmissaoRG { get; set; }
        public string RIC { get; set; }
        public string UFEmissaoRIC { get; set; }
        public string CidadeEmissaoRIC { get; set; }
        public string OrgaoEmissorRIC { get; set; }
        public DateTime? DataExpedicaoRIC { get; set; }
        public string CartaoNacionalSaude { get; set; }
        public string NumeroReservista { get; set; }
        public string TituloEleitor { get; set; }
        public string ZonaEleitoral { get; set; }
        public string SecaoEleitoral { get; set; }
        public string UFEleitoral { get; set; }
        public string CidadeEleitoral { get; set; }
        public string CarteiraHabilitacao { get; set; }
        public string CategoriaHabilitacao { get; set; }
        public DateTime? DataVencimentoHabilitacao { get; set; }
        public string NumeroCTPS { get; set; }
        public string SerieCTPS { get; set; }
        public string UFCTPS { get; set; }
        public DateTime? DataEmissaoCTPS { get; set; }
        public string PISNITNIS { get; set; }
        public DateTime? DataEmissaoPISNITNIS { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}