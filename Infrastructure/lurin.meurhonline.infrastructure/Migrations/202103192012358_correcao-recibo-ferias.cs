namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoreciboferias : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReciboFerias", "CPF");
            DropColumn("dbo.ReciboFerias", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReciboFerias", "Nome", c => c.String());
            AddColumn("dbo.ReciboFerias", "CPF", c => c.String(nullable: false));
        }
    }
}
