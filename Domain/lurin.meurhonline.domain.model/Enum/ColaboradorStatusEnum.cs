using System.ComponentModel;

namespace lurin.meurhonline.domain.model.enumerator
{
    public enum ColaboradorStatusEnum
    {
        [Description("Pré-Admissão")]
        PRE_ADMISSAO = 1,
        [Description("Ativo")]
        ATIVO = 2,
        [Description("Afastado")]
        AFASTADO = 3,
        [Description("Desligado")]
        DESLIGADO = 4
    }
}