namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropriedadeNavegacaoJustificativaDivergenciaDetalhe : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DivergenciaDetalhe", "JustificativaDivergenciaId");
            AddForeignKey("dbo.DivergenciaDetalhe", "JustificativaDivergenciaId", "dbo.JustificativaDivergencia", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DivergenciaDetalhe", "JustificativaDivergenciaId", "dbo.JustificativaDivergencia");
            DropIndex("dbo.DivergenciaDetalhe", new[] { "JustificativaDivergenciaId" });
        }
    }
}
