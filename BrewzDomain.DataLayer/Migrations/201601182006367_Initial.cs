namespace BrewzDomain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brewers",
                c => new
                    {
                        brewer_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description_nl = c.String(),
                        description_en = c.String(),
                        opening_times_nl = c.String(),
                        opening_times_en = c.String(),
                        individuals_join_groups_nl = c.Boolean(nullable: false),
                        individuals_join_groups_en = c.Boolean(nullable: false),
                        images_url = c.String(),
                        video_url = c.String(),
                        top_fermentation = c.Int(nullable: false),
                        bottom_fermentation = c.Int(nullable: false),
                        spontaneous_fermentation = c.Int(nullable: false),
                        mixed_fermentation = c.Int(nullable: false),
                        address_addressId = c.Int(nullable: false),
                        communication_communicationsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.brewer_id)
                .ForeignKey("dbo.Addresses", t => t.address_addressId, cascadeDelete: true)
                .ForeignKey("dbo.Communications", t => t.communication_communicationsId, cascadeDelete: true)
                .Index(t => t.address_addressId)
                .Index(t => t.communication_communicationsId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        address_id = c.Int(nullable: false, identity: true),
                        street = c.String(),
                        house_number = c.String(),
                        city = c.String(),
                        province = c.String(),
                        postal_code = c.String(),
                    })
                .PrimaryKey(t => t.address_id);
            
            CreateTable(
                "dbo.Communications",
                c => new
                    {
                        communications_id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        phone = c.String(),
                        mobile = c.String(),
                        fax = c.String(),
                        website = c.String(),
                    })
                .PrimaryKey(t => t.communications_id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        review_id = c.Int(nullable: false, identity: true),
                        review_date = c.DateTime(nullable: false),
                        review_score = c.Int(nullable: false),
                        review_comment = c.String(),
                        Brewer_brewerId = c.Int(),
                        User_userId = c.Int(),
                    })
                .PrimaryKey(t => t.review_id)
                .ForeignKey("dbo.Brewers", t => t.Brewer_brewerId)
                .ForeignKey("dbo.Users", t => t.User_userId)
                .Index(t => t.Brewer_brewerId)
                .Index(t => t.User_userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        login = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "User_userId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Brewer_brewerId", "dbo.Brewers");
            DropForeignKey("dbo.Brewers", "communication_communicationsId", "dbo.Communications");
            DropForeignKey("dbo.Brewers", "address_addressId", "dbo.Addresses");
            DropIndex("dbo.Reviews", new[] { "User_userId" });
            DropIndex("dbo.Reviews", new[] { "Brewer_brewerId" });
            DropIndex("dbo.Brewers", new[] { "communication_communicationsId" });
            DropIndex("dbo.Brewers", new[] { "address_addressId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Communications");
            DropTable("dbo.Addresses");
            DropTable("dbo.Brewers");
        }
    }
}
