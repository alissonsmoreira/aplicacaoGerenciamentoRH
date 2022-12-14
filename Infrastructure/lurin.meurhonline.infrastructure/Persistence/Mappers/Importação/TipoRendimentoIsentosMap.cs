using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class TipoRendimentoIsentosMap : EntityTypeConfiguration<TipoRendimentoIsentosModel>
    { 
        public TipoRendimentoIsentosMap()
        {
            ToTable("TipoRendimentoIsentos");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.InformeRendimentoId).IsRequired();
            Property(x => x.DescricaoTipoEvento).IsRequired();
            Property(x => x.Valor).IsRequired();
        }
    }
}
