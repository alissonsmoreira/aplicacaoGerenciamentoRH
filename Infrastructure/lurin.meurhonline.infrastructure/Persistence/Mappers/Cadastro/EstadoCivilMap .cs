using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EstadoCivilMap : EntityTypeConfiguration<EstadoCivilModel>
    {
        public EstadoCivilMap()
        {
            ToTable("EstadoCivil");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Id).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
