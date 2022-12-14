using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class MovimentacaoContratualMap : EntityTypeConfiguration<MovimentacaoContratualModel>
    {
        public MovimentacaoContratualMap()
        {
            ToTable("MovimentacaoContratual");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.GestorId).IsRequired();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.LotacaoUnidadeId).IsRequired();
            Property(x => x.CentroCustoUnidadeId).IsRequired();
            Property(x => x.TipoMaoObraId).IsOptional();
            Property(x => x.TurnoId).IsOptional();
            Property(x => x.UnidadeNegocioId).IsOptional();
            Property(x => x.NumeroCartaoPonto).IsOptional();
            Property(x => x.CargoUnidadeId).IsRequired();
            Property(x => x.Salario).IsOptional();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}
