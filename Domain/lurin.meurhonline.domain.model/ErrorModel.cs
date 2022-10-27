using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    [NotMapped]
    public class ErrorModel
    {        
        public int Codigo { get; set; }
        public string Descricao { get; set; }

    }
}