using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lurin.meurhonline.domain.model
{
    public class DivergenciaLogModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string LogErro { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
