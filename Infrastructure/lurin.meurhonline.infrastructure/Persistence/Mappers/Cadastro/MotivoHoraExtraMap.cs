using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class MotivoHoraExtraMap : EntityTypeConfiguration<MotivoHoraExtraModel>
    {
        public MotivoHoraExtraMap()
        {
            ToTable("MotivoHoraExtra");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Motivo).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
