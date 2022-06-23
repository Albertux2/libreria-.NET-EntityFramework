namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDB41 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carritoes", "ProductoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "ProductoId", c => c.Int(nullable: false));
        }
    }
}
