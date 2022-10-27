namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusterelatoriodivergencia : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Divergencia", "Matricula");
            DropColumn("dbo.Divergencia", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divergencia", "Nome", c => c.String());
            AddColumn("dbo.Divergencia", "Matricula", c => c.String());
        }
    }
}
