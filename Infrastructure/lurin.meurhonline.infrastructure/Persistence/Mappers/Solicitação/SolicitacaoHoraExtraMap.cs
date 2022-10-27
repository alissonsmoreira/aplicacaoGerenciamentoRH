using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class SolicitacaoHoraExtraMap : EntityTypeConfiguration<SolicitacaoHoraExtraModel>
    {
        public SolicitacaoHoraExtraMap()
        {
            ToTable("SolicitacaoHoraExtra");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.GestorId).IsRequired();
            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.Data).IsRequired();
            Property(x => x.HoraInicio).IsRequired();
            Property(x => x.HoraFim).IsRequired();
            Property(x => x.Motivo).IsOptional();
            Property(x => x.TemCafeManha).IsRequired();
            Property(x => x.TemRefeicao).IsRequired();
            Property(x => x.TemMarmitex).IsRequired();
            Property(x => x.MarmitexId).IsOptional();
            Property(x => x.DataSolicitacao).IsOptional();
        }
    }
}