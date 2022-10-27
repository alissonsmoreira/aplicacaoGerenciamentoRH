using System;

namespace lurin.meurhonline.domain.model
{
    public class SindicatoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string DataBaseMes { get; set; }
        public string DataBaseAno { get; set; }
        public string Representante { get; set; }
        public string TelefoneComercial { get; set; }
        public string TelefoneCelular { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}