namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteferias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ferias", "EmpresaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ferias", "EmpresaId");
            AddForeignKey("dbo.Ferias", "EmpresaId", "dbo.Empresa", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ferias", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Ferias", new[] { "EmpresaId" });
            DropColumn("dbo.Ferias", "EmpresaId");
        }
    }
}
