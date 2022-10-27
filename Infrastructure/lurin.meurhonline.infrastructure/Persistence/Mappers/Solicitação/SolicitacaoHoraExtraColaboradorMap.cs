using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class SolicitacaoHoraExtraColaboradorMap : EntityTypeConfiguration<SolicitacaoHoraExtraColaboradorModel>
    {
        public SolicitacaoHoraExtraColaboradorMap()
        {
            ToTable("SolicitacaoHoraExtraColaborador");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.SolicitacaoHoraExtraId).IsRequired();
            Property(x => x.ColaboradorId).IsOptional();
            Property(x => x.SolicitacaoStatusId).IsOptional();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}