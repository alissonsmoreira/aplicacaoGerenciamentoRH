namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solicitacaoferias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ferias", "ColaboradorId", c => c.Int());
            AddColumn("dbo.FeriasPeriodo", "SolicitacaoStatusId", c => c.Int());
            AddColumn("dbo.FeriasPeriodo", "DataSolicitacao", c => c.DateTime());
            CreateIndex("dbo.Ferias", "ColaboradorId");
            AddForeignKey("dbo.Ferias", "ColaboradorId", "dbo.Colaborador", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ferias", "ColaboradorId", "dbo.Colaborador");
            DropIndex("dbo.Ferias", new[] { "ColaboradorId" });
            DropColumn("dbo.FeriasPeriodo", "DataSolicitacao");
            DropColumn("dbo.FeriasPeriodo", "SolicitacaoStatusId");
            DropColumn("dbo.Ferias", "ColaboradorId");
        }
    }
}
