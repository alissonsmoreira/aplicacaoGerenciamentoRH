using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorPagamentoMap : EntityTypeConfiguration<ColaboradorPagamentoModel>
    {
        public ColaboradorPagamentoMap()
        {
            ToTable("ColaboradorPagamento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.BancoId).IsRequired();
            Property(x => x.Agencia).IsRequired();
            Property(x => x.Conta).IsRequired();
            Property(x => x.ContaBancariaTipoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
