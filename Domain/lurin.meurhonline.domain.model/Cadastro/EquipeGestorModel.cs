using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace lurin.meurhonline.domain.model
{
    public class EquipeGestorModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int LotacaoUnidadeInicialId { get; set; }
        public int LotacaoUnidadeFinalId { get; set; }

        [NotMapped]
        public LotacaoUnidadeModel LotacaoUnidadeInicial { get; set; }        
        
        [NotMapped]
        public LotacaoUnidadeModel LotacaoUnidadeFinal { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}