namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustecartaoponto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartaoPonto", "Mes", c => c.String(nullable: false));
            AddColumn("dbo.CartaoPonto", "Ano", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartaoPonto", "Ano");
            DropColumn("dbo.CartaoPonto", "Mes");
        }
    }
}
