using System;
using System.Collections.Generic;

namespace lurin.meurhonline.domain.model
{
    public class CentroCustoPlanoModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public DateTime DataCadastro { get; set; }
        public ICollection<CentroCustoPlanoUnidadeModel> CentroCustoPlanosUnidades { get; set; }
    }
}