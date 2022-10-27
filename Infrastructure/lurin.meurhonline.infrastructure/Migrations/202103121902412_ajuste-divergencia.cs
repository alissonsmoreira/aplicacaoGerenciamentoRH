namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustedivergencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divergencia", "EmpresaId", c => c.Int());
            AddColumn("dbo.Divergencia", "ColaboradorId", c => c.Int(nullable: false));
            AddColumn("dbo.Divergencia", "Motivo", c => c.String());
            AlterColumn("dbo.DivergenciaDetalhe", "Dia", c => c.DateTime());
            CreateIndex("dbo.Divergencia", "EmpresaId");
            CreateIndex("dbo.Divergencia", "ColaboradorId");
            AddForeignKey("dbo.Divergencia", "ColaboradorId", "dbo.Colaborador", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Divergencia", "EmpresaId", "dbo.Empresa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Divergencia", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Divergencia", "ColaboradorId", "dbo.Colaborador");
            DropIndex("dbo.Divergencia", new[] { "ColaboradorId" });
            DropIndex("dbo.Divergencia", new[] { "EmpresaId" });
            AlterColumn("dbo.DivergenciaDetalhe", "Dia", c => c.String());
            DropColumn("dbo.Divergencia", "Motivo");
            DropColumn("dbo.Divergencia", "ColaboradorId");
            DropColumn("dbo.Divergencia", "EmpresaId");
        }
    }
}
