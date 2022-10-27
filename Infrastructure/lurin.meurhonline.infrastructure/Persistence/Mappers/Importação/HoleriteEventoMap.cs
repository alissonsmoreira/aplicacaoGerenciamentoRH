using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class HoleriteEventoMap : EntityTypeConfiguration<HoleriteEventoModel>
    {
        public HoleriteEventoMap()
        {
            ToTable("HoleriteEvento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.HoleriteId).IsRequired();
            Property(x => x.Evento).IsOptional();
            Property(x => x.Descricao).IsOptional();
            Property(x => x.Quantidade).IsOptional();
            Property(x => x.ValoresPositivos).IsOptional();
            Property(x => x.ValoresNegativos).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}