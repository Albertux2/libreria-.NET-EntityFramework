namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cantidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendibles", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendibles", "Cantidad");
        }
    }
}
