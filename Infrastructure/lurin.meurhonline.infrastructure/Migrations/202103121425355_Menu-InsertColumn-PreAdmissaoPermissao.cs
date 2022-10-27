namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuInsertColumnPreAdmissaoPermissao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "PreAdmissaoPermissao", c => c.String(nullable: false, maxLength: 1, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menu", "PreAdmissaoPermissao");
        }
    }
}
