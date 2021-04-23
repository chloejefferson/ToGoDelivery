namespace ToGoDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Name");
        }
    }
}
