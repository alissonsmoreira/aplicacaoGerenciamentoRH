using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class FeriasConcessaoModel
    {
        public int Id { get; set; }
        public string InicioFerias { get; set; }
        public string DiasGozo { get; set; }
        public string DiasAbono { get; set; }
        public string DiasLicenca { get; set; }
        public int FeriasPeriodoId { get; set; }
        [JsonIgnore]
        public FeriasPeriodoModel FeriasPeriodo { get; set; }
    }
}