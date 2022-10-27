using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class MenuMap : EntityTypeConfiguration<MenuModel>
    {
        public MenuMap()
        {
            ToTable("Menu");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            Property(x => x.Titulo).IsRequired();
            Property(x => x.SubTitulo).IsRequired();
            Property(x => x.SubTituloNivel1).IsOptional();
            Property(x => x.UsuarioPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.GestorPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.FuncionarioPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.PreAdmissaoPermissao).IsRequired().HasColumnType("varchar").HasMaxLength(1);
            Property(x => x.Order).IsRequired();
            Property(x => x.MenuStatusId).IsRequired();
        }
    }
}