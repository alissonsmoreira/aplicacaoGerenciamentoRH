using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DesligamentoMap : EntityTypeConfiguration<DesligamentoModel>
    {
        public DesligamentoMap()
        {
            ToTable("Desligamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.GestorId).IsRequired();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.DataSugerida).IsRequired();
            Property(x => x.DesligamentoTipoId).IsRequired();
            Property(x => x.Motivo).IsRequired();
            Property(x => x.Substituir).IsRequired();
            Property(x => x.Recontrataria).IsRequired();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
            Property(x => x.DataDesligamento).IsOptional();
        }
    }
}
