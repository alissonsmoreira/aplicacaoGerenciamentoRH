namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SindicatoalteracaoDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sindicato", "DataBaseMes", c => c.String(nullable: false));
            AddColumn("dbo.Sindicato", "DataBaseAno", c => c.String(nullable: false));
            DropColumn("dbo.Sindicato", "DataBase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sindicato", "DataBase", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sindicato", "DataBaseAno");
            DropColumn("dbo.Sindicato", "DataBaseMes");
        }
    }
}
