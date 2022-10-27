using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DivergenciaMap : EntityTypeConfiguration<DivergenciaModel>
    {
        public DivergenciaMap()
        {
            ToTable("Divergencia");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.Estabelecimento).IsRequired();
            Property(x => x.Motivo).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
