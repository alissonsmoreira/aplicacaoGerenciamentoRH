namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aprovacaoferias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeriasPeriodo", "DataConclusao", c => c.DateTime());
            DropColumn("dbo.Ferias", "Matricula");
            DropColumn("dbo.Ferias", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ferias", "Nome", c => c.String());
            AddColumn("dbo.Ferias", "Matricula", c => c.String(nullable: false));
            DropColumn("dbo.FeriasPeriodo", "DataConclusao");
        }
    }
}
