namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDocumentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookAuthor = c.String(),
                        BookExcerpt = c.String(),
                        BookType_Id = c.Byte(),
                        Uploads_Id = c.Byte(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookTypes", t => t.BookType_Id)
                .ForeignKey("dbo.Uploads", t => t.Uploads_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.BookType_Id)
                .Index(t => t.Uploads_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Uploads",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ImagePath = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "Uploads_Id", "dbo.Uploads");
            DropForeignKey("dbo.Documents", "BookType_Id", "dbo.BookTypes");
            DropIndex("dbo.Documents", new[] { "User_Id" });
            DropIndex("dbo.Documents", new[] { "Uploads_Id" });
            DropIndex("dbo.Documents", new[] { "BookType_Id" });
            DropTable("dbo.Uploads");
            DropTable("dbo.Documents");
            DropTable("dbo.BookTypes");
        }
    }
}
