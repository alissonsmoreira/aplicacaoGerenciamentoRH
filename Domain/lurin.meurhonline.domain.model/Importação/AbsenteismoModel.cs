using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class AbsenteismoModel
    {
        public int Id { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string HorasTotais { get; set; }
        public string HorasNaoTrabalhadas { get; set; }
        public string Absenteismo { get; set; }
        [NotMapped]
        public ErrorModel Erro { get; set; }

        [NotMapped]
        public string ExcelBase64 { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
