namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugPrecio2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendibles", "Precio", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendibles", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
