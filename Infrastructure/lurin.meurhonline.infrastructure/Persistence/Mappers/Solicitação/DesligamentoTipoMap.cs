using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DesligamentoTipoMap : EntityTypeConfiguration<DesligamentoTipoModel>
    {
        public DesligamentoTipoMap()
        {
            ToTable("DesligamentoTipo");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Id).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
