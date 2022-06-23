namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "active");
        }
    }
}
