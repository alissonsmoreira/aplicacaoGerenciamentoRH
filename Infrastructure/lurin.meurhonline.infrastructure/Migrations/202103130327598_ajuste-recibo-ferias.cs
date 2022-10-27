namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustereciboferias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReciboFerias", "Ano", c => c.String(nullable: false));
            AddColumn("dbo.ReciboFerias", "EmpresaId", c => c.Int());
            AddColumn("dbo.ReciboFerias", "ColaboradorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReciboFerias", "EmpresaId");
            CreateIndex("dbo.ReciboFerias", "ColaboradorId");
            AddForeignKey("dbo.ReciboFerias", "ColaboradorId", "dbo.Colaborador", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReciboFerias", "EmpresaId", "dbo.Empresa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReciboFerias", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.ReciboFerias", "ColaboradorId", "dbo.Colaborador");
            DropIndex("dbo.ReciboFerias", new[] { "ColaboradorId" });
            DropIndex("dbo.ReciboFerias", new[] { "EmpresaId" });
            DropColumn("dbo.ReciboFerias", "ColaboradorId");
            DropColumn("dbo.ReciboFerias", "EmpresaId");
            DropColumn("dbo.ReciboFerias", "Ano");
        }
    }
}
