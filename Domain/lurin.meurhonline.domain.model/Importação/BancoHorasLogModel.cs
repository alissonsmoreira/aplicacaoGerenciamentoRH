using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class BancoHorasLogModel
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string ColaboradorNome { get; set; }
        public string Matricula { get; set; }
        public string Erro { get; set; }
        public DateTime DataImportacao { get; set; }
    }
}