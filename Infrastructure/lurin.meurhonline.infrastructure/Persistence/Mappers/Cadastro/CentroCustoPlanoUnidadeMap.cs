using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CentroCustoPlanoUnidadeMap : EntityTypeConfiguration<CentroCustoPlanoUnidadeModel>
    {
        public CentroCustoPlanoUnidadeMap()
        {
            ToTable("CentroCustoPlanoUnidade");
            HasKey(pu => new { pu.CentroCustoPlanoId, pu.CentroCustoUnidadeId });

        }
    }
}
