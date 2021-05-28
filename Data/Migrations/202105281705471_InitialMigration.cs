namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publishment = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Sales = c.Int(nullable: false),
                        Crew = c.String(),
                        Comment = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CteatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Film = c.Int(nullable: false),
                        Id_User = c.Int(nullable: false),
                        Adress = c.String(),
                        Time_Order = c.DateTime(nullable: false),
                        Delivery_Price = c.Single(nullable: false),
                        Order_Price = c.Double(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CteatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Film_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Film_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Byte(nullable: false),
                        Budget = c.Double(nullable: false),
                        Buyed = c.Int(nullable: false),
                        Favorites = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CteatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Film_Id", "dbo.Films");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Film_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Films");
        }
    }
}
