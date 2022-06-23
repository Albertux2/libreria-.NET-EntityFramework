namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDB4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carritoes", "ProductoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carritoes", "ProductoId");
        }
    }
}
