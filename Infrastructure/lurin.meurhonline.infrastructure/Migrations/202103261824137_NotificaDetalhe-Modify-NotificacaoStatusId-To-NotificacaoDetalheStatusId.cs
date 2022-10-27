namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificaDetalheModifyNotificacaoStatusIdToNotificacaoDetalheStatusId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotificacaoDetalhe", "NotificacaoDetalheStatusId", c => c.Int(nullable: false));
            DropColumn("dbo.NotificacaoDetalhe", "NotificacaoStatusId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NotificacaoDetalhe", "NotificacaoStatusId", c => c.Int(nullable: false));
            DropColumn("dbo.NotificacaoDetalhe", "NotificacaoDetalheStatusId");
        }
    }
}
