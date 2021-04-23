namespace ToGoDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProduct3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProducts", "ProductCount", c => c.Int(nullable: false));
            AddColumn("dbo.OrderProducts", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProducts", "IsActive");
            DropColumn("dbo.OrderProducts", "ProductCount");
        }
    }
}
