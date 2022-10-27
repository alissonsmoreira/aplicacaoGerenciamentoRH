using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorDocumentoAdmissionalModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public int DocumentoAdmissionalId { get; set; }
        public DocumentoAdmissionalModel DocumentoAdmissional { get; set; }
        public string DocumentoNome { get; set; }
        [NotMapped]
        public string DocumentoBase64 { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}