namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolicitacaoHoraExtra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SolicitacaoHoraExtra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GestorId = c.Int(nullable: false),
                        EmpresaId = c.Int(),
                        Data = c.DateTime(nullable: false),
                        HoraInicio = c.Time(nullable: false, precision: 7),
                        HoraFim = c.Time(nullable: false, precision: 7),
                        Motivo = c.String(),
                        TemCafeManha = c.Boolean(nullable: false),
                        TemRefeicao = c.Boolean(nullable: false),
                        TemMarmitex = c.Boolean(nullable: false),
                        MarmitexId = c.Int(),
                        DataSolicitacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.Colaborador", t => t.GestorId, cascadeDelete: true)
                .ForeignKey("dbo.Marmitex", t => t.MarmitexId)
                .Index(t => t.GestorId)
                .Index(t => t.EmpresaId)
                .Index(t => t.MarmitexId);
            
            CreateTable(
                "dbo.SolicitacaoHoraExtraColaborador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SolicitacaoHoraExtraId = c.Int(nullable: false),
                        ColaboradorId = c.Int(),
                        SolicitacaoStatusId = c.Int(),
                        DataConclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborador", t => t.ColaboradorId)
                .ForeignKey("dbo.SolicitacaoHoraExtra", t => t.SolicitacaoHoraExtraId, cascadeDelete: true)
                .Index(t => t.SolicitacaoHoraExtraId)
                .Index(t => t.ColaboradorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitacaoHoraExtraColaborador", "SolicitacaoHoraExtraId", "dbo.SolicitacaoHoraExtra");
            DropForeignKey("dbo.SolicitacaoHoraExtraColaborador", "ColaboradorId", "dbo.Colaborador");
            DropForeignKey("dbo.SolicitacaoHoraExtra", "MarmitexId", "dbo.Marmitex");
            DropForeignKey("dbo.SolicitacaoHoraExtra", "GestorId", "dbo.Colaborador");
            DropForeignKey("dbo.SolicitacaoHoraExtra", "EmpresaId", "dbo.Empresa");
            DropIndex("dbo.SolicitacaoHoraExtraColaborador", new[] { "ColaboradorId" });
            DropIndex("dbo.SolicitacaoHoraExtraColaborador", new[] { "SolicitacaoHoraExtraId" });
            DropIndex("dbo.SolicitacaoHoraExtra", new[] { "MarmitexId" });
            DropIndex("dbo.SolicitacaoHoraExtra", new[] { "EmpresaId" });
            DropIndex("dbo.SolicitacaoHoraExtra", new[] { "GestorId" });
            DropTable("dbo.SolicitacaoHoraExtraColaborador");
            DropTable("dbo.SolicitacaoHoraExtra");
        }
    }
}
