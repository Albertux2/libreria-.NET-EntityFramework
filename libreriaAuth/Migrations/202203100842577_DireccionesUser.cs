namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DireccionesUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions");
            DropIndex("dbo.AspNetUsers", new[] { "DireccionID" });
            AddColumn("dbo.Direccions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Direccions", "ApplicationUser_Id");
            AddForeignKey("dbo.Direccions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "DireccionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DireccionID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Direccions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Direccions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Direccions", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "DireccionID");
            AddForeignKey("dbo.AspNetUsers", "DireccionID", "dbo.Direccions", "Id");
        }
    }
}
