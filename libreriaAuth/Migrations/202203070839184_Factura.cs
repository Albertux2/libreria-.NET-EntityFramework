namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        importeTotal = c.Single(nullable: false),
                        carrito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carritoes", t => t.carrito_Id)
                .Index(t => t.carrito_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "carrito_Id", "dbo.Carritoes");
            DropIndex("dbo.Facturas", new[] { "carrito_Id" });
            DropTable("dbo.Facturas");
        }
    }
}
