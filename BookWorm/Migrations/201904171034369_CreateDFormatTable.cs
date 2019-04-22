namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDFormatTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Documents", name: "BookType_Id", newName: "BookGenres_Id");
            RenameIndex(table: "dbo.Documents", name: "IX_BookType_Id", newName: "IX_BookGenres_Id");
            CreateTable(
                "dbo.DFormats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileFormat = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BookTypes", "Genre", c => c.String());
            AddColumn("dbo.Documents", "DName", c => c.String());
            AddColumn("dbo.Documents", "DAuthor", c => c.String());
            AddColumn("dbo.Documents", "DFormat_Id", c => c.Int());
            CreateIndex("dbo.Documents", "DFormat_Id");
            AddForeignKey("dbo.Documents", "DFormat_Id", "dbo.DFormats", "Id");
            DropColumn("dbo.BookTypes", "Type");
            DropColumn("dbo.Documents", "BookName");
            DropColumn("dbo.Documents", "BookAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "BookAuthor", c => c.String());
            AddColumn("dbo.Documents", "BookName", c => c.String());
            AddColumn("dbo.BookTypes", "Type", c => c.String());
            DropForeignKey("dbo.Documents", "DFormat_Id", "dbo.DFormats");
            DropIndex("dbo.Documents", new[] { "DFormat_Id" });
            DropColumn("dbo.Documents", "DFormat_Id");
            DropColumn("dbo.Documents", "DAuthor");
            DropColumn("dbo.Documents", "DName");
            DropColumn("dbo.BookTypes", "Genre");
            DropTable("dbo.DFormats");
            RenameIndex(table: "dbo.Documents", name: "IX_BookGenres_Id", newName: "IX_BookType_Id");
            RenameColumn(table: "dbo.Documents", name: "BookGenres_Id", newName: "BookType_Id");
        }
    }
}
