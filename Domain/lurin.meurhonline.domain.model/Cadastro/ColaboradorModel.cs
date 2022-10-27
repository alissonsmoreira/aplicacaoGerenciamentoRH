using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public int ColaboradorTipoId { get; set; }
        public ColaboradorTipoModel ColaboradorTipo { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string FotoNome { get; set; }
        [NotMapped]
        public string FotoBase64 { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string Email { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string MatriculaInterna { get; set; }
        public string MatriculaeSocial { get; set; }
        public string PaisNascimento { get; set; }
        public string UFNascimento { get; set; }
        public string CidadeNascimento { get; set; }
        public int? GrauInstrucaoId { get; set; }
        public GrauInstrucaoModel GrauInstrucao { get; set; }
        public int? EstadoCivilId { get; set; }
        public EstadoCivilModel EstadoCivil { get; set; }
        public int ColaboradorStatusId { get; set; }
        [NotMapped]
        public ColaboradorStatusModel ColaboradorStatus { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}