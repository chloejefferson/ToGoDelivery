namespace ToGoDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableOrderDateFinalized : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "DateFinalized", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "DateFinalized", c => c.DateTime(nullable: false));
        }
    }
}
