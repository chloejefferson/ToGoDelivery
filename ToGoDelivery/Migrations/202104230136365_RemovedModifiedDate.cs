namespace ToGoDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedModifiedDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
