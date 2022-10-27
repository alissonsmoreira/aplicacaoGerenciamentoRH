using System;
using System.Collections.Generic;

namespace lurin.meurhonline.domain.model
{
    public class TurnoModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public ICollection<TurnoDetalheModel> TurnoDetalhe { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}