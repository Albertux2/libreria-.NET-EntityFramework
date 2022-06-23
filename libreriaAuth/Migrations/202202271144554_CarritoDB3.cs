namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carritoes", "producto_Id", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "productoId", "dbo.Vendibles");
            DropIndex("dbo.Carritoes", new[] { "producto_Id" });
            DropPrimaryKey("dbo.Vendibles");
            AddColumn("dbo.Productoes", "Carrito_Id", c => c.Int());
            AddPrimaryKey("dbo.Vendibles", "Id");
            CreateIndex("dbo.Productoes", "Carrito_Id");
            AddForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes", "Id");
            AddForeignKey("dbo.Productoes", "productoId", "dbo.Vendibles", "Id", cascadeDelete: true);
            DropColumn("dbo.Carritoes", "producto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carritoes", "producto_Id", c => c.Int());
            DropForeignKey("dbo.Productoes", "productoId", "dbo.Vendibles");
            DropForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes");
            DropIndex("dbo.Productoes", new[] { "Carrito_Id" });
            DropPrimaryKey("dbo.Vendibles");
            AlterColumn("dbo.Vendibles", "id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Productoes", "Carrito_Id");
            AddPrimaryKey("dbo.Vendibles", "Id");
            CreateIndex("dbo.Carritoes", "producto_Id");
            AddForeignKey("dbo.Productoes", "productoId", "dbo.Vendibles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carritoes", "producto_Id", "dbo.Productoes", "Id");
        }
    }
}
