using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class AbsenteismoMap : EntityTypeConfiguration<AbsenteismoModel>
    {
        public AbsenteismoMap()
        {
            ToTable("Absenteismo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Cpf).IsOptional();
            Property(x => x.Nome).IsOptional();
            Property(x => x.HorasTotais).IsOptional();
            Property(x => x.HorasNaoTrabalhadas).IsOptional();
            Property(x => x.Absenteismo).IsOptional();
        }
    }
}
