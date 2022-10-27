using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class DependenteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string GrauDependencia { get; set; }
        public string DocumentoNome { get; set; }
        [NotMapped]
        public string DocumentoBase64 { get; set; }        
        public int ColaboradorId { get; set; }
        [NotMapped]
        public int TitularId { get; set; }
        [NotMapped]
        public string TitularNome { get; set; }
        public DateTime DataCadastro { get; set; }
        
    }
}