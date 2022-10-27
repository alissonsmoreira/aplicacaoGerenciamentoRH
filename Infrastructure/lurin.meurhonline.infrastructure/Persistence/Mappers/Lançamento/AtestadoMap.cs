using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class AtestadoMap : EntityTypeConfiguration<AtestadoModel>
    {
        public AtestadoMap()
        {
            ToTable("Atestado");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.DataAtestado).IsRequired();
            Property(x => x.HorarioChegada).IsRequired();
            Property(x => x.HorarioSaida).IsRequired();
            Property(x => x.QuantidadeDias).IsRequired();
            Property(x => x.CID).IsOptional();
            Property(x => x.AtestadoNome).IsOptional();
            Property(x => x.LancamentoStatusId).IsRequired();
            Property(x => x.DataLancamento).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}
