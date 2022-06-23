namespace libreriaAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacturaDireccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Direccion_Id", c => c.Int());
            CreateIndex("dbo.Facturas", "Direccion_Id");
            AddForeignKey("dbo.Facturas", "Direccion_Id", "dbo.Direccions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Direccion_Id", "dbo.Direccions");
            DropIndex("dbo.Facturas", new[] { "Direccion_Id" });
            DropColumn("dbo.Facturas", "Direccion_Id");
        }
    }
}
