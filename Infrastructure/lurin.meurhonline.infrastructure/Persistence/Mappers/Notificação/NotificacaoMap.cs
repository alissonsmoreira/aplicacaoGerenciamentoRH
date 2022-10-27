using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class NotificacaoMap : EntityTypeConfiguration<NotificacaoModel>
    {
        public NotificacaoMap()
        {
            ToTable("Notificacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NotificacaoDetalheId).IsRequired();
            Property(x => x.NotificacaoStatusLeituraId).IsRequired();
            Property(x => x.ById).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
