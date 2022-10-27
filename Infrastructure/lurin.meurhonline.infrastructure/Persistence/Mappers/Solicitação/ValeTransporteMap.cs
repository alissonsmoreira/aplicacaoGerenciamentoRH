using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ValeTransporteMap : EntityTypeConfiguration<ValeTransporteModel>
    {
        public ValeTransporteMap()
        {
            ToTable("ValeTransporte");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.OperadoraVTId).IsRequired();
            Property(x => x.LinhaVTId).IsRequired();
            Property(x => x.ValeTransporteUtilizacaoId).IsRequired();
            Property(x => x.ValeTransporteSituacaoId).IsRequired();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
            Property(x => x.DiasSemana).IsOptional();
        }
    }
}
