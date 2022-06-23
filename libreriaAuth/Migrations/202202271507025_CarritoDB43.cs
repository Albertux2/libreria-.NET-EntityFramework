namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDB43 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Productoes", new[] { "Carrito_Id1" });
            DropColumn("dbo.Productoes", "Carrito_Id");
            RenameColumn(table: "dbo.Productoes", name: "Carrito_Id1", newName: "Carrito_Id");
            AlterColumn("dbo.Productoes", "Carrito_Id", c => c.Int());
            CreateIndex("dbo.Productoes", "Carrito_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Productoes", new[] { "Carrito_Id" });
            AlterColumn("dbo.Productoes", "Carrito_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Productoes", name: "Carrito_Id", newName: "Carrito_Id1");
            AddColumn("dbo.Productoes", "Carrito_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Productoes", "Carrito_Id1");
        }
    }
}
