using System.ComponentModel;

namespace lurin.meurhonline.domain.model.enumerator
{
    public enum SolicitacaoStatusEnum
    {
        [Description("Em Análise")]
        EM_ANALISE = 1,
        [Description("Aprovado")]
        APROVADO = 2,
        [Description("Reprovado")]
        REPROVADO = 3,
    }
}