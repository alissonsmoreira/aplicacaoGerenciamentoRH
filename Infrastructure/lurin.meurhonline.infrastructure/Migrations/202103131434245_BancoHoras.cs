namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoHoras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BancoHoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        ColaboradorId = c.Int(nullable: false),
                        HorasPositivas = c.String(nullable: false),
                        HorasNegativas = c.String(nullable: false),
                        HorasSaldo = c.String(nullable: false),
                        DataImportacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId, cascadeDelete: true)
                .Index(t => t.ColaboradorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BancoHoras", "ColaboradorId", "dbo.Colaborador");
            DropIndex("dbo.BancoHoras", new[] { "ColaboradorId" });
            DropTable("dbo.BancoHoras");
        }
    }
}
