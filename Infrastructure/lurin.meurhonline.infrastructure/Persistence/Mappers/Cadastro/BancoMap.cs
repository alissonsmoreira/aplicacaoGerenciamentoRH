using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class BancoMap : EntityTypeConfiguration<BancoModel>
    {
        public BancoMap()
        {
            ToTable("Banco");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Id).IsRequired();
            Property(x => x.Codigo).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
