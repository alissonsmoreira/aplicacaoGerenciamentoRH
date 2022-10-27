using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class FeriasModel
    {
        public FeriasModel()
        {
            Periodo = new List<FeriasPeriodoModel>();
        }
        public int Id { get; set; }
        public int? ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string Estabelecimento { get; set; }
        [NotMapped]
        public string Matricula { get; set; }
        public ICollection<FeriasPeriodoModel> Periodo { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}