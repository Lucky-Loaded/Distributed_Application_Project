namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Crew = c.String(),
                        Publishment = c.DateTime(),
                        Sales = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        TimeOrder = c.DateTime(nullable: false),
                        DeliveryPrice = c.Single(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FilmId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Budget = c.Double(nullable: false),
                        Phone = c.Int(nullable: false),
                        Favorites = c.String(),
                        Description = c.String(),
                        Buyed = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "FilmId", "dbo.Films");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "FilmId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Films");
        }
    }
}
