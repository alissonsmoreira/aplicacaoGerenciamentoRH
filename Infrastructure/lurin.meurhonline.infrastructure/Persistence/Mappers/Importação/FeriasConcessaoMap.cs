using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class FeriasConcessaoMap : EntityTypeConfiguration<FeriasConcessaoModel>
    {
        public FeriasConcessaoMap()
        {
            ToTable("FeriasConcessao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.InicioFerias).IsOptional();
            Property(x => x.DiasGozo).IsOptional();
            Property(x => x.DiasAbono).IsOptional();
            Property(x => x.DiasLicenca).IsOptional();
            Property(x => x.FeriasPeriodoId).IsRequired();
        }
    }
}
