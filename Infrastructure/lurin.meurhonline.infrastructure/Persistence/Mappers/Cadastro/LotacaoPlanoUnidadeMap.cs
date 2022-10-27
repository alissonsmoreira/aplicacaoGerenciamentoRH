using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class LotacaoPlanoUnidadeMap : EntityTypeConfiguration<LotacaoPlanoUnidadeModel>
    {
        public LotacaoPlanoUnidadeMap()
        {
            ToTable("LotacaoPlanoUnidade");
            HasKey(pu => new { pu.LotacaoPlanoId, pu.LotacaoUnidadeId });

        }
    }
}
