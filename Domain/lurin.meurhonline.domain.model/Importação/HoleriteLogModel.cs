using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class HoleriteLogModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string LogErro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}