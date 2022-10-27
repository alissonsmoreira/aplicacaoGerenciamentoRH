namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20211014_DivergenciaDetalhe_AddColumns_JustificativaDivergenciaID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DivergenciaDetalhe", "JustificativaDivergenciaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DivergenciaDetalhe", "JustificativaDivergenciaId");
        }
    }
}
