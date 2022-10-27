namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustesavisoferias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvisoFerias", "EmpresaId", c => c.Int());
            AddColumn("dbo.AvisoFerias", "Ano", c => c.String(nullable: false));
            AddColumn("dbo.AvisoFerias", "CPNJ", c => c.String());
            CreateIndex("dbo.AvisoFerias", "EmpresaId");
            AddForeignKey("dbo.AvisoFerias", "EmpresaId", "dbo.Empresa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvisoFerias", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.AvisoFerias", new[] { "EmpresaId" });
            DropColumn("dbo.AvisoFerias", "CPNJ");
            DropColumn("dbo.AvisoFerias", "Ano");
            DropColumn("dbo.AvisoFerias", "EmpresaId");
        }
    }
}
