using System;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class EmpresaDocumentoAdmissionalModel
    {
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public EmpresaModel Empresa{ get; set; }
        public int DocumentoAdmissionalId { get; set; }
        public DocumentoAdmissionalModel DocumentoAdmissional { get; set; }

    }
}