using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class NotificacaoDetalheMap : EntityTypeConfiguration<NotificacaoDetalheModel>
    {
        public NotificacaoDetalheMap()
        {
            ToTable("NotificacaoDetalhe");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Nome).IsRequired();
            Property(x => x.URL).IsRequired();
            Property(x => x.API).IsRequired();
            Property(x => x.MensagemSingular).IsRequired();
            Property(x => x.MensagemPlural).IsRequired();
            Property(x => x.UsuarioPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.GestorPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.FuncionarioPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.PreAdmissaoPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.IconeClass).IsRequired();
            Property(x => x.ExadecimalColor).IsRequired();
            Property(x => x.Order).IsRequired();
            Property(x => x.MenuId).IsRequired();
            Property(x => x.NotificacaoDetalheStatusId).IsRequired();
        }
    }
}
