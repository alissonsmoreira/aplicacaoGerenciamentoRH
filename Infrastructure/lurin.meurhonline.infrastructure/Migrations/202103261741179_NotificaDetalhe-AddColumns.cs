namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificaDetalheAddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotificacaoDetalhe", "UsuarioPermissao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            AddColumn("dbo.NotificacaoDetalhe", "GestorPermissao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            AddColumn("dbo.NotificacaoDetalhe", "FuncionarioPermissao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            AddColumn("dbo.NotificacaoDetalhe", "PreAdmissaoPermissao", c => c.String(nullable: false, maxLength: 1, unicode: false));
            AddColumn("dbo.NotificacaoDetalhe", "IconeClass", c => c.String(nullable: false));
            AddColumn("dbo.NotificacaoDetalhe", "ExadecimalColor", c => c.String(nullable: false));
            AddColumn("dbo.NotificacaoDetalhe", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.NotificacaoDetalhe", "MenuId", c => c.Int(nullable: false));
            AddColumn("dbo.NotificacaoDetalhe", "NotificacaoStatusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NotificacaoDetalhe", "NotificacaoStatusId");
            DropColumn("dbo.NotificacaoDetalhe", "MenuId");
            DropColumn("dbo.NotificacaoDetalhe", "Order");
            DropColumn("dbo.NotificacaoDetalhe", "ExadecimalColor");
            DropColumn("dbo.NotificacaoDetalhe", "IconeClass");
            DropColumn("dbo.NotificacaoDetalhe", "PreAdmissaoPermissao");
            DropColumn("dbo.NotificacaoDetalhe", "FuncionarioPermissao");
            DropColumn("dbo.NotificacaoDetalhe", "GestorPermissao");
            DropColumn("dbo.NotificacaoDetalhe", "UsuarioPermissao");
        }
    }
}
