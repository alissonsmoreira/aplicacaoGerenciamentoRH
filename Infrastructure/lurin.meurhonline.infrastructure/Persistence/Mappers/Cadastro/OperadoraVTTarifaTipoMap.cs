using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class OperadoraVTTarifaTipoMap : EntityTypeConfiguration<OperadoraVTTarifaTipoModel>
    {
        public OperadoraVTTarifaTipoMap()
        {
            ToTable("OperadoraVTTarifaTipo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Nome).IsRequired();
        }
    }
}
