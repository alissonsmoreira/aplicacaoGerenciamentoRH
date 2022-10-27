using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class UFMap : EntityTypeConfiguration<UFModel>
    {
        public UFMap()
        {
            ToTable("UF");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Id).IsRequired();
            Property(x => x.Sigla).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
