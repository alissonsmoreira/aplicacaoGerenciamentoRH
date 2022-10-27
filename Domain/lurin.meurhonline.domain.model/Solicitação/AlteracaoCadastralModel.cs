using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class AlteracaoCadastralModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string Email { get; set; }
        public string CategoriaHabilitacao { get; set; }
        public DateTime DataVencimentoHabilitacao { get; set; }
        public int BancoId { get; set; }
        public BancoModel Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public int ContaBancariaTipoId { get; set; }
        public ContaBancariaTipoModel ContaBancariaTipo { get; set; }
        public string FotoNome { get; set; }
        [NotMapped]
        public string FotoBase64 { get; set; }
        public string CarteiraHabilitacaoNome { get; set; }
        [NotMapped]
        public string CarteiraHabilitacaoBase64 { get; set; }
        public string ComprovanteResidenciaNome { get; set; }
        [NotMapped]
        public string ComprovanteResidenciaBase64 { get; set; }
        public int SolicitacaoStatusId { get; set; }
        [NotMapped]
        public SolicitacaoStatusModel SolicitacaoStatus { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}