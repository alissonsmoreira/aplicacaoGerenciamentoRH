using System;
using System.Collections.Generic;

namespace lurin.meurhonline.domain.model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
       //public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public string TelefoneComercial { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}