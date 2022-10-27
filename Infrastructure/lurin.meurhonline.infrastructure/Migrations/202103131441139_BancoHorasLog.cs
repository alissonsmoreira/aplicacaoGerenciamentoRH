namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoHorasLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BancoHorasLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        ColaboradorNome = c.String(nullable: false),
                        Matricula = c.String(nullable: false),
                        Erro = c.String(nullable: false),
                        DataImportacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BancoHorasLog", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.BancoHorasLog", new[] { "EmpresaId" });
            DropTable("dbo.BancoHorasLog");
        }
    }
}
