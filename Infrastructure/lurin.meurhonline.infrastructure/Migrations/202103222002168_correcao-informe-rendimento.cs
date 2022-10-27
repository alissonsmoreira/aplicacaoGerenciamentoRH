namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoinformerendimento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InformeRendimento", "EmpresaId", c => c.Int());
            CreateIndex("dbo.InformeRendimento", "EmpresaId");
            AddForeignKey("dbo.InformeRendimento", "EmpresaId", "dbo.Empresa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InformeRendimento", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.InformeRendimento", new[] { "EmpresaId" });
            AlterColumn("dbo.InformeRendimento", "EmpresaId", c => c.Int(nullable: false));
        }
    }
}
