namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoColunaTabelaDocumentos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentoAdmissional", "PermiteVisualizar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentoAdmissional", "PermiteVisualizar");
        }
    }
}
