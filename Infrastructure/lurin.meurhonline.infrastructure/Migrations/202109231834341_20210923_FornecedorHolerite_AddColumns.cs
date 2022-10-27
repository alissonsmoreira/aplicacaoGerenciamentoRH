namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20210923_FornecedorHolerite_AddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresa", "FornecedorHolerite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empresa", "FornecedorHolerite");
        }
    }
}
