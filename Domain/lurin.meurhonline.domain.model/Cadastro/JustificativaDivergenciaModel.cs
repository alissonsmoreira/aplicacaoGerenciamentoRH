using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class JustificativaDivergenciaModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}