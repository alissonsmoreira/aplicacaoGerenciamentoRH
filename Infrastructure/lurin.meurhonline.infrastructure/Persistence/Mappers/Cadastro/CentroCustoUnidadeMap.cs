using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CentroCustoUnidadeMap : EntityTypeConfiguration<CentroCustoUnidadeModel>
    {
        public CentroCustoUnidadeMap()
        {
            ToTable("CentroCustoUnidade");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Codigo).IsRequired();
            Property(x => x.Nome).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
