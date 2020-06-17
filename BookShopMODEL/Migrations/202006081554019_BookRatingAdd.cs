namespace BookShopMODEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookRatingAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Int(),
                        Comment = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Author = c.String(nullable: false, maxLength: 200),
                        PublisherId = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        ContentDescription = c.String(),
                        TOC = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Clicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.PublisherId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        PId = c.Int(),
                        SortNum = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .Index(t => t.OrderID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, storeType: "money"),
                        Address = c.String(maxLength: 150),
                        AcceptName = c.String(maxLength: 50),
                        AcceptPhone = c.String(maxLength: 20),
                        PayStyle = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReaderComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ReaderName = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Comment = c.String(nullable: false, maxLength: 300),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.RecomBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.UserId });
            
            CreateTable(
                "dbo.SearchKeywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Keyword = c.String(nullable: false, maxLength: 50),
                        SearchCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemporaryCart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Num = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Score = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginId = c.String(nullable: false, maxLength: 50),
                        LoginPwd = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 100),
                        Birthday = c.DateTime(),
                        UserRoleId = c.Int(nullable: false),
                        UserStateId = c.Int(nullable: false),
                        RegisterIp = c.String(maxLength: 50),
                        RegisterTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStates", t => t.UserStateId)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId)
                .Index(t => t.UserRoleId)
                .Index(t => t.UserStateId);
            
            CreateTable(
                "dbo.UserStates",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "UserStateId", "dbo.UserStates");
            DropForeignKey("dbo.ReaderComments", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.OrderBook", "BookID", "dbo.Books");
            DropForeignKey("dbo.OrderBook", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "UserStateId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.ReaderComments", new[] { "BookId" });
            DropIndex("dbo.OrderBook", new[] { "BookID" });
            DropIndex("dbo.OrderBook", new[] { "OrderID" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropTable("dbo.UserStates");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.TemporaryCart");
            DropTable("dbo.SearchKeywords");
            DropTable("dbo.RecomBooks");
            DropTable("dbo.ReaderComments");
            DropTable("dbo.Publishers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderBook");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.BookRatings");
        }
    }
}
