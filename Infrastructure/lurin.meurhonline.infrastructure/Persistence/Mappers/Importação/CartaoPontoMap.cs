using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CartaoPontoMap : EntityTypeConfiguration<CartaoPontoModel>
    {
        public CartaoPontoMap()
        {
            ToTable("CartaoPonto");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Mes).IsRequired();
            Property(x => x.Ano).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.MotivoReprovacao).IsOptional();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}