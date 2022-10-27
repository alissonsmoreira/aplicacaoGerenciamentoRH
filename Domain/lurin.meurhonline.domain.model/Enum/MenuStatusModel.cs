using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    [NotMapped]
    public class MenuStatusModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
