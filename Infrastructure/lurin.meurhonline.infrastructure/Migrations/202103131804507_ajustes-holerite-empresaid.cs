namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustesholeriteempresaid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Holerite", "EmpresaId", c => c.Int());
            CreateIndex("dbo.Holerite", "EmpresaId");
            AddForeignKey("dbo.Holerite", "EmpresaId", "dbo.Empresa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Holerite", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.Holerite", new[] { "EmpresaId" });
            AlterColumn("dbo.Holerite", "EmpresaId", c => c.Int(nullable: false));
        }
    }
}
