using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorEmail
    {
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public string Nome { get; set; }
        [NotMapped]
        public string Cpf { get; set; }
    }
}
