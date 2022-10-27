using System.ComponentModel;

namespace lurin.meurhonline.domain.model.enumerator
{
    public enum SolicitacaoBeneficioDependenteStatusEnum
    {
        [Description("Em Análise Aprovação")]
        EM_ANALISE_APROVACAO = 1,
        [Description("Aprovado")]
        APROVADO = 2,
        [Description("Reprovado")]
        REPROVADO = 3,
        [Description("Em Análise Cancelamento")]
        EM_ANALISE_CANCELAMENTO = 4,
    }
}