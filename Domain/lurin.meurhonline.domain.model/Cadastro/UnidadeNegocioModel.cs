using System;

namespace lurin.meurhonline.domain.model
{
    public class UnidadeNegocioModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}