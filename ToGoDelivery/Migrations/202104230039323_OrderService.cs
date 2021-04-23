namespace ToGoDelivery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ServiceId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.OrderServices", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderServices", new[] { "ServiceId" });
            DropIndex("dbo.OrderServices", new[] { "OrderId" });
            DropTable("dbo.OrderServices");
        }
    }
}
