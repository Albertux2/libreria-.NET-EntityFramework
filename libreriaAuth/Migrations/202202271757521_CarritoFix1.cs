namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoFix1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Libroes", newName: "Vendibles");
            DropIndex("dbo.Vendibles", new[] { "AutorId" });
            DropIndex("dbo.Vendibles", new[] { "GeneroId" });
            DropIndex("dbo.Vendibles", new[] { "FormatoId" });
            DropIndex("dbo.Vendibles", new[] { "EstadoId" });
            DropIndex("dbo.Vendibles", new[] { "EditorialId" });
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendibles", t => t.articuloId, cascadeDelete: true)
                .ForeignKey("dbo.Carritoes", t => t.Carrito_Id)
                .Index(t => t.articuloId)
                .Index(t => t.Carrito_Id);
            
            AddColumn("dbo.Vendibles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Vendibles", "Isbn", c => c.String(maxLength: 13));
            AlterColumn("dbo.Vendibles", "AutorId", c => c.Int());
            AlterColumn("dbo.Vendibles", "Ventas", c => c.Int());
            AlterColumn("dbo.Vendibles", "GeneroId", c => c.Int());
            AlterColumn("dbo.Vendibles", "FormatoId", c => c.Int());
            AlterColumn("dbo.Vendibles", "EstadoId", c => c.Int());
            AlterColumn("dbo.Vendibles", "EditorialId", c => c.Int());
            CreateIndex("dbo.Vendibles", "AutorId");
            CreateIndex("dbo.Vendibles", "GeneroId");
            CreateIndex("dbo.Vendibles", "FormatoId");
            CreateIndex("dbo.Vendibles", "EstadoId");
            CreateIndex("dbo.Vendibles", "EditorialId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carritoes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Productoes", "Carrito_Id", "dbo.Carritoes");
            DropForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles");
            DropIndex("dbo.Vendibles", new[] { "EditorialId" });
            DropIndex("dbo.Vendibles", new[] { "EstadoId" });
            DropIndex("dbo.Vendibles", new[] { "FormatoId" });
            DropIndex("dbo.Vendibles", new[] { "GeneroId" });
            DropIndex("dbo.Vendibles", new[] { "AutorId" });
            DropIndex("dbo.Productoes", new[] { "Carrito_Id" });
            DropIndex("dbo.Productoes", new[] { "articuloId" });
            DropIndex("dbo.Carritoes", new[] { "UserId" });
            AlterColumn("dbo.Vendibles", "EditorialId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "FormatoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "GeneroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "Ventas", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "AutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vendibles", "Isbn", c => c.String(nullable: false, maxLength: 13));
            DropColumn("dbo.Vendibles", "Discriminator");
            DropTable("dbo.Productoes");
            DropTable("dbo.Carritoes");
            CreateIndex("dbo.Vendibles", "EditorialId");
            CreateIndex("dbo.Vendibles", "EstadoId");
            CreateIndex("dbo.Vendibles", "FormatoId");
            CreateIndex("dbo.Vendibles", "GeneroId");
            CreateIndex("dbo.Vendibles", "AutorId");
            RenameTable(name: "dbo.Vendibles", newName: "Libroes");
        }
    }
}
