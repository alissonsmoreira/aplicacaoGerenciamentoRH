namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OperadoraVTBandeiraCartaoDataCadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperadoraVTBandeiraCartao", "DataCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperadoraVTBandeiraCartao", "DataCadastro");
        }
    }
}
