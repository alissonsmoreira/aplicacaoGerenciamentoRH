using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class TurnoDetalheMap : EntityTypeConfiguration<TurnoDetalheModel>
    {
        public TurnoDetalheMap()
        {
            ToTable("TurnoDetalhe");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DiaSemana).IsRequired();
            Property(x => x.HorarioInicial).IsRequired();
            Property(x => x.HorarioFinal).IsRequired();
            Property(x => x.TurnoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
