using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class AbsenteismoLogModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string LogErro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
