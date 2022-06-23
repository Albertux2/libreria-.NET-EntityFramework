namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Direccions", "Poblacion", c => c.String());
            AlterColumn("dbo.Direccions", "CodigoPostal", c => c.String());
            AlterColumn("dbo.Direccions", "Numero", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Direccions", "Numero", c => c.Int(nullable: false));
            AlterColumn("dbo.Direccions", "CodigoPostal", c => c.Int(nullable: false));
            DropColumn("dbo.Direccions", "Poblacion");
        }
    }
}
