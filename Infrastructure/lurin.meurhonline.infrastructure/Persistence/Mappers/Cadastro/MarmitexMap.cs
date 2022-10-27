using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class MarmitexMap : EntityTypeConfiguration<MarmitexModel>
    {
        public MarmitexMap()
        {
            ToTable("Marmitex");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Tipo).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
