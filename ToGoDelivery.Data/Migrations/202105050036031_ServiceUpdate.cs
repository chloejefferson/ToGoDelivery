namespace ToGoDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Service", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Service", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Service", "CreatedDate");
            DropColumn("dbo.Service", "IsActive");
        }
    }
}
