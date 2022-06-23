namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles");
            DropForeignKey("dbo.Vendibles", "AutorId", "dbo.Autors");
            DropForeignKey("dbo.Vendibles", "EditorialId", "dbo.Editorials");
            DropForeignKey("dbo.Vendibles", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Vendibles", "FormatoId", "dbo.Formatoes");
            DropForeignKey("dbo.Vendibles", "GeneroId", "dbo.Tematicas");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            AddForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles", "Id");
            AddForeignKey("dbo.Vendibles", "AutorId", "dbo.Autors", "id");
            AddForeignKey("dbo.Vendibles", "EditorialId", "dbo.Editorials", "id");
            AddForeignKey("dbo.Vendibles", "EstadoId", "dbo.Estadoes", "id");
            AddForeignKey("dbo.Vendibles", "FormatoId", "dbo.Formatoes", "id");
            AddForeignKey("dbo.Vendibles", "GeneroId", "dbo.Tematicas", "id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vendibles", "GeneroId", "dbo.Tematicas");
            DropForeignKey("dbo.Vendibles", "FormatoId", "dbo.Formatoes");
            DropForeignKey("dbo.Vendibles", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Vendibles", "EditorialId", "dbo.Editorials");
            DropForeignKey("dbo.Vendibles", "AutorId", "dbo.Autors");
            DropForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vendibles", "GeneroId", "dbo.Tematicas", "id", cascadeDelete: true);
            AddForeignKey("dbo.Vendibles", "FormatoId", "dbo.Formatoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Vendibles", "EstadoId", "dbo.Estadoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Vendibles", "EditorialId", "dbo.Editorials", "id", cascadeDelete: true);
            AddForeignKey("dbo.Vendibles", "AutorId", "dbo.Autors", "id", cascadeDelete: true);
            AddForeignKey("dbo.Productoes", "articuloId", "dbo.Vendibles", "Id", cascadeDelete: true);
        }
    }
}
