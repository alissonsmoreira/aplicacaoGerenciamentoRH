namespace lurin.meurhonline.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValeTransporteDiasSemana : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ValeTransporte", "DiasSemana", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ValeTransporte", "DiasSemana");
        }
    }
}
