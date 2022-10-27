using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    [NotMapped]
    public class ColaboradorFuncionarioModel
    {
        public int Id { get; set; }
        public string NomeColaborador { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cargo { get; set; }
        public string CentroDeCusto { get; set; }
        public string UnidadeDeLotacao { get; set; }
        public string UnidadeDeNegocio { get; set; }
        public string Salario { get; set; }
        public string Turno { get; set; }
        public string DataAdmissao { get; set; }
        public string TipoRegistro { get; set; }

    }
}