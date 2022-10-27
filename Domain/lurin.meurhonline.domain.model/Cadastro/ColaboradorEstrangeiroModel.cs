using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class ColaboradorEstrangeiroModel
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public ColaboradorModel Colaborador { get; set; }
        public string Origem { get; set; }
        public int ColaboradorEstrangeiroTipoVistoId { get; set; }
        public ColaboradorEstrangeiroTipoVistoModel ColaboradorEstrangeiroTipoVisto { get; set; }
        public string Passaporte { get; set; }
        public string OrgaoEmissorPassaporte { get; set; }
        public string PaisEmissorPassaporte { get; set; }
        public string UFPassaporte { get; set; }
        public DateTime? DataEmissaoPassaporte{ get; set; }
        public string PortariaNaturalizacao { get; set; }
        public string IdentidadeEstrangeira { get; set; }
        public string ValidadeIdentidadeEstrangeira { get; set; }
        public string AnoChegada { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}