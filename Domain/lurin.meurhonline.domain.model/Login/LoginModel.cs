using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public int UsuarioColaboradorId { get; set; }
        public int UsuarioColaboradorTipoId { get; set; }

        [NotMapped]
        public UsuarioColaboradorTipoModel UsuarioColaboradorTipo { get; set; }

        [NotMapped]
        public ColaboradorTipoModel ColaboradorTipo { get; set; }

        [NotMapped]
        public ColaboradorStatusModel ColaboradorStatus { get; set; }        

        [NotMapped]
        public TokenModel Token { get; set; }

        [NotMapped]
        public List<MenuModel> Menu { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}