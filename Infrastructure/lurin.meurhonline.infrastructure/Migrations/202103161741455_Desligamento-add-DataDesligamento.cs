namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesligamentoaddDataDesligamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Desligamento", "DataDesligamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Desligamento", "DataDesligamento");
        }
    }
}
