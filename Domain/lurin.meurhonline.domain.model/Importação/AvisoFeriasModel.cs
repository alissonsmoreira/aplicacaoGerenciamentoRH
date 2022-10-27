using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class AvisoFeriasModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string Ano { get; set; }
        public string Estabelecimento { get; set; }
        public string CPNJ { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Texto { get; set; }
        public string LocalData { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
