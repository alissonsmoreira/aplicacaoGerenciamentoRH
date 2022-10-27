using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class FeriasPeriodoMap : EntityTypeConfiguration<FeriasPeriodoModel>
    {
        public FeriasPeriodoMap()
        {
            ToTable("FeriasPeriodo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.InicioPeriodo).IsRequired();
            Property(x => x.FimPeriodo).IsOptional();
            Property(x => x.Situacao).IsOptional();
            Property(x => x.DiasDireito).IsOptional();
            Property(x => x.DiasConcedidos).IsOptional();
            Property(x => x.DiasProgramados).IsOptional();
            Property(x => x.Saldo).IsOptional();
            Property(x => x.FeriasId).IsRequired();
        }
    }
}
