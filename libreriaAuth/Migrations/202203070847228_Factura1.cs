namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factura1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Facturas", new[] { "carrito_Id" });
            AlterColumn("dbo.Facturas", "Carrito_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "Carrito_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Facturas", new[] { "Carrito_Id" });
            AlterColumn("dbo.Facturas", "Carrito_Id", c => c.Int());
            CreateIndex("dbo.Facturas", "carrito_Id");
        }
    }
}
