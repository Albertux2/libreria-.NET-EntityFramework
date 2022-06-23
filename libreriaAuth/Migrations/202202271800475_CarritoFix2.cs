namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoFix2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Vendibles", "Isbn", unique: true);
            DropColumn("dbo.Productoes", "cosa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "cosa", c => c.Int(nullable: false));
            DropIndex("dbo.Vendibles", new[] { "Isbn" });
        }
    }
}
