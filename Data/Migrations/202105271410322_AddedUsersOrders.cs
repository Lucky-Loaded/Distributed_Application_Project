namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsers : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Films", "Sales", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "Crew", c => c.String());
            AddColumn("dbo.Films", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Comment");
            DropColumn("dbo.Films", "Crew");
            DropColumn("dbo.Films", "Sales");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}
