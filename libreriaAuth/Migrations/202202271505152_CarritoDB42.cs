namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDB42 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_Id" });
            RenameColumn(table: "dbo.Productoes", name: "productoId", newName: "vendibleId");
            RenameIndex(table: "dbo.Productoes", name: "IX_productoId", newName: "IX_vendibleId");
            AddColumn("dbo.Productoes", "Carrito_Id1", c => c.Int());
            AlterColumn("dbo.Productoes", "Carrito_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Productoes", "Carrito_Id1");
            AddForeignKey("dbo.Productoes", "Carrito_Id1", "dbo.Carritoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Carrito_Id1", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_Id1" });
            AlterColumn("dbo.Productoes", "Carrito_Id", c => c.Int());
            DropColumn("dbo.Productoes", "Carrito_Id1");
            RenameIndex(table: "dbo.Productoes", name: "IX_vendibleId", newName: "IX_productoId");
            RenameColumn(table: "dbo.Productoes", name: "vendibleId", newName: "productoId");
            CreateIndex("dbo.Productoes", "Carrito_Id");
            AddForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes", "Id");
        }
    }
}
