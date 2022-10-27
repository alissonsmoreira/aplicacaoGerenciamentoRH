using System;

namespace lurin.meurhonline.domain.model
{
    public class OperadoraVTModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int OperadoraVTBandeiraCartaoId { get; set; }
        public OperadoraVTBandeiraCartaoModel OperadoraVTBandeiraCartao { get; set; }
        public int OperadoraVTTarifaTipoId { get; set; }
        public OperadoraVTTarifaTipoModel OperadoraVTTarifaTipo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}