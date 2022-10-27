using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class JustificativaDivergenciaMap : EntityTypeConfiguration<JustificativaDivergenciaModel>
    {
        public JustificativaDivergenciaMap()
        {
            ToTable("JustificativaDivergencia");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Tipo).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
