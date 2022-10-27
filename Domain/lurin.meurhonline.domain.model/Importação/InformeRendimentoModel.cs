using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class InformeRendimentoModel
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Ministerio { get; set; }
        public string TipoDocumento { get; set; }
        public string Secretaria { get; set; }
        public string Documento { get; set; }
        public string Exercicio { get; set; }
        public string AnoCalendario { get; set; }
        public string FontePagadora { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string CNPJ { get; set; }
        public string DadosPessoaFisica { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public string DescricaoCPF { get; set; }
        public string CPF { get; set; }
        public string DescricaoNome { get; set; }
        public string Nome { get; set; }
        public string DescricaoNatureza { get; set; }
        public string Natureza { get; set; }
        public string TipoRendimento1 { get; set; }
        public string MoedaRendimento1 { get; set; }
        public ICollection<TipoRendimentoTributaveisModel> TipoRendimentosTributaveis { get; set; }
        
        public string TipoRendimento2 { get; set; }
        public string MoedaRendimento2 { get; set; }
        public ICollection<TipoRendimentoIsentosModel> TipoRendimentosIsentos { get; set; }
        public string TipoRendimento3 { get; set; }
        public string MoedaRendimento3 { get; set; }
        public ICollection<TipoRendimentoSujeitosTribModel> TipoRendimentosSujeitosTrib { get; set; }

        public string TipoRendimento4 { get; set; }
        public string MoedaRendimento4 { get; set; }
        public string Processo { get; set; }
        public string NaturezaRendimento { get; set; }
        public ICollection<TipoRendimentoRecebModel> TipoRendimentosReceb { get; set; }
        public string InformacoesComplementares { get; set; }
        public string DadosResponsavel { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}