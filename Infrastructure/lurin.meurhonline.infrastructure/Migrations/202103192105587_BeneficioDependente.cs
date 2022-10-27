namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeneficioDependente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeneficioDependente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DependenteId = c.Int(nullable: false),
                        BeneficioId = c.Int(nullable: false),
                        SolicitacaoStatusId = c.Int(nullable: false),
                        DataSolicitacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beneficio", t => t.BeneficioId, cascadeDelete: true)
                .ForeignKey("dbo.Dependente", t => t.DependenteId, cascadeDelete: true)
                .Index(t => t.DependenteId)
                .Index(t => t.BeneficioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeneficioDependente", "DependenteId", "dbo.Dependente");
            DropForeignKey("dbo.BeneficioDependente", "BeneficioId", "dbo.Beneficio");
            DropIndex("dbo.BeneficioDependente", new[] { "BeneficioId" });
            DropIndex("dbo.BeneficioDependente", new[] { "DependenteId" });
            DropTable("dbo.BeneficioDependente");
        }
    }
}
