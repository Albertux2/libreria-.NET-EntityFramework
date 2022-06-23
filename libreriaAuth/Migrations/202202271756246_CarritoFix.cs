namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Vendibles", newName: "Libroes");
            DropForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles");
            DropForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes");
            DropForeignKey("dbo.Carritoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Carritoes", new[] { "UserId" });
            DropIndex("dbo.Productoes", new[] { "articuloId" });
            DropIndex("dbo.Productoes", new[] { "Carrito_Id" });
            DropIndex("dbo.Libroes", new[] { "AutorId" });
            DropIndex("dbo.Libroes", new[] { "GeneroId" });
            DropIndex("dbo.Libroes", new[] { "FormatoId" });
            DropIndex("dbo.Libroes", new[] { "EstadoId" });
            DropIndex("dbo.Libroes", new[] { "EditorialId" });
            AlterColumn("dbo.Libroes", "Isbn", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Libroes", "AutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Libroes", "Ventas", c => c.Int(nullable: false));
            AlterColumn("dbo.Libroes", "GeneroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Libroes", "FormatoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Libroes", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Libroes", "EditorialId", c => c.Int(nullable: false));
            CreateIndex("dbo.Libroes", "AutorId");
            CreateIndex("dbo.Libroes", "GeneroId");
            CreateIndex("dbo.Libroes", "FormatoId");
            CreateIndex("dbo.Libroes", "EstadoId");
            CreateIndex("dbo.Libroes", "EditorialId");
            DropColumn("dbo.Libroes", "Discriminator");
            DropTable("dbo.Carritoes");
            //DropTable("dbo.Productoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        articuloId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        cosa = c.Int(nullable: false),
                        Carrito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Libroes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropIndex("dbo.Libroes", new[] { "EditorialId" });
            DropIndex("dbo.Libroes", new[] { "EstadoId" });
            DropIndex("dbo.Libroes", new[] { "FormatoId" });
            DropIndex("dbo.Libroes", new[] { "GeneroId" });
            DropIndex("dbo.Libroes", new[] { "AutorId" });
            AlterColumn("dbo.Libroes", "EditorialId", c => c.Int());
            AlterColumn("dbo.Libroes", "EstadoId", c => c.Int());
            AlterColumn("dbo.Libroes", "FormatoId", c => c.Int());
            AlterColumn("dbo.Libroes", "GeneroId", c => c.Int());
            AlterColumn("dbo.Libroes", "Ventas", c => c.Int());
            AlterColumn("dbo.Libroes", "AutorId", c => c.Int());
            AlterColumn("dbo.Libroes", "Isbn", c => c.String(maxLength: 13));
            CreateIndex("dbo.Libroes", "EditorialId");
            CreateIndex("dbo.Libroes", "EstadoId");
            CreateIndex("dbo.Libroes", "FormatoId");
            CreateIndex("dbo.Libroes", "GeneroId");
            CreateIndex("dbo.Libroes", "AutorId");
            CreateIndex("dbo.Productoes", "Carrito_Id");
            CreateIndex("dbo.Productoes", "articuloId");
            CreateIndex("dbo.Carritoes", "UserId");
            AddForeignKey("dbo.Carritoes", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes", "Id");
            AddForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Libroes", newName: "Vendibles");
        }
    }
}
