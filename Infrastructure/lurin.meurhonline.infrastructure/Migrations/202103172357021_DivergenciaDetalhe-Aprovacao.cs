namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivergenciaDetalheAprovacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DivergenciaDetalhe", "MotivoAprovacao", c => c.String());
            AddColumn("dbo.DivergenciaDetalhe", "SolicitacaoStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.DivergenciaDetalhe", "DataConclusao", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DivergenciaDetalhe", "DataConclusao");
            DropColumn("dbo.DivergenciaDetalhe", "SolicitacaoStatusId");
            DropColumn("dbo.DivergenciaDetalhe", "MotivoAprovacao");
        }
    }
}
