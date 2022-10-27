using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class OperadoraVTMap : EntityTypeConfiguration<OperadoraVTModel>
    {
        public OperadoraVTMap()
        {
            ToTable("OperadoraVT");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.OperadoraVTBandeiraCartaoId).IsRequired();
            Property(x => x.OperadoraVTTarifaTipoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
