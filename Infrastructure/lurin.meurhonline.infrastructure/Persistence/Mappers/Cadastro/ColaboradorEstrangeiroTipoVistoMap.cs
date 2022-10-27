using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorEstrangeiroTipoVistoMap : EntityTypeConfiguration<ColaboradorEstrangeiroTipoVistoModel>
    {
        public ColaboradorEstrangeiroTipoVistoMap()
        {
            ToTable("ColaboradorEstrangeiroTipoVisto");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Id).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
