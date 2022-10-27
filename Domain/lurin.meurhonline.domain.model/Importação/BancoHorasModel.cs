using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class BancoHorasModel
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        [NotMapped]
        public EmpresaModel Empresa { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string Matricula { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string ColaboradorNome { get; set; }
        public string HorasPositivas { get; set; }
        public string HorasNegativas { get; set; }
        public string HorasSaldo{ get; set; }
        [NotMapped]
        public string DocumentoBase64 { get; set; }
        public DateTime DataImportacao { get; set; }
    }
}