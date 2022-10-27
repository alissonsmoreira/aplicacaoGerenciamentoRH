using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorPagamentoModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int BancoId { get; set; }
        public BancoModel Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public int ContaBancariaTipoId { get; set; }
        public ContaBancariaTipoModel ContaBancariaTipo { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}