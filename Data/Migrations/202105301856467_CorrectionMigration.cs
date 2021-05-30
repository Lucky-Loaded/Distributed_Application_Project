namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Publishment = c.DateTime(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sales = c.Int(nullable: false),
                        Crew = c.String(),
                        Comment = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Film_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Address = c.String(),
                        Time_Order = c.DateTime(nullable: false),
                        Delivery_Price = c.Single(nullable: false),
                        Order_Price = c.Double(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Film_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.Film_Id1)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Budget = c.Double(nullable: false),
                        Buyed = c.Int(nullable: false),
                        Favorites = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Orders", "Film_Id1", "dbo.Films");
            DropIndex("dbo.Orders", new[] { "User_Id1" });
            DropIndex("dbo.Orders", new[] { "Film_Id1" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Films");
        }
    }
}
