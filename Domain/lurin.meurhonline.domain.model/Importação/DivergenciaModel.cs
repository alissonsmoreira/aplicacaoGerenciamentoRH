using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class DivergenciaModel
    {
        public DivergenciaModel()
        {
            Detalhes = new List<DivergenciaDetalheModel>();
        }
        public int Id { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public string Estabelecimento { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Matricula { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string Nome { get; set; }
        public ICollection<DivergenciaDetalheModel> Detalhes { get; set; }
        public string Motivo { get; set; }

        [NotMapped]
        public string DocumentoBase64 { get; set; }

        [NotMapped]
        public ErrorModel Erro { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}