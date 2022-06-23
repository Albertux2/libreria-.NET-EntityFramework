namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveVentas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vendibles", "Ventas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendibles", "Ventas", c => c.Int());
        }
    }
}
