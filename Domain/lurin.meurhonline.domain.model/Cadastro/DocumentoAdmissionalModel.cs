using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class DocumentoAdmissionalModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PermiteVisualizar { get; set; }    
        public DateTime DataCadastro { get; set; }
        [JsonIgnore]
        public ICollection<EmpresaDocumentoAdmissionalModel> EmpresaDocumentosAdmissional { get; set; }
    }
}