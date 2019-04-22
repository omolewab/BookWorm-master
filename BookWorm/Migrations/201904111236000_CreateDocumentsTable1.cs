namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDocumentsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Documents", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Documents", new[] { "User_Id" });
            DropColumn("dbo.Documents", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Documents", "User_Id");
            AddForeignKey("dbo.Documents", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
