namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartaoPontoaddaprovacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartaoPonto", "MotivoReprovacao", c => c.String());
            AddColumn("dbo.CartaoPonto", "SolicitacaoStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.CartaoPonto", "DataConclusao", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartaoPonto", "DataConclusao");
            DropColumn("dbo.CartaoPonto", "SolicitacaoStatusId");
            DropColumn("dbo.CartaoPonto", "MotivoReprovacao");
        }
    }
}
