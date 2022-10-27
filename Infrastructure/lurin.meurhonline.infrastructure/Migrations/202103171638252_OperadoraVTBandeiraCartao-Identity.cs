namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OperadoraVTBandeiraCartaoIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OperadoraVT", "OperadoraVTBandeiraCartaoId", "dbo.OperadoraVTBandeiraCartao");
            DropPrimaryKey("dbo.OperadoraVTBandeiraCartao");
            AlterColumn("dbo.OperadoraVTBandeiraCartao", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OperadoraVTBandeiraCartao", "Id");
            AddForeignKey("dbo.OperadoraVT", "OperadoraVTBandeiraCartaoId", "dbo.OperadoraVTBandeiraCartao", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperadoraVT", "OperadoraVTBandeiraCartaoId", "dbo.OperadoraVTBandeiraCartao");
            DropPrimaryKey("dbo.OperadoraVTBandeiraCartao");
            AlterColumn("dbo.OperadoraVTBandeiraCartao", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OperadoraVTBandeiraCartao", "Id");
            AddForeignKey("dbo.OperadoraVT", "OperadoraVTBandeiraCartaoId", "dbo.OperadoraVTBandeiraCartao", "Id", cascadeDelete: true);
        }
    }
}
