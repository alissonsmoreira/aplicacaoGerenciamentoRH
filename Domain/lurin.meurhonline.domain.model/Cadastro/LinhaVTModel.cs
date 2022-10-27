using System;

namespace lurin.meurhonline.domain.model
{
    public class LinhaVTModel
    {
        public int Id { get; set; }
        public string NomeLinha { get; set; }
        public decimal ValorLinha { get; set; }
        public int OperadoraVTId { get; set; }
        public OperadoraVTModel OperadoraVT { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}