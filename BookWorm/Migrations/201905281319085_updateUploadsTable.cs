namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUploadsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uploads", "ThumbnailPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uploads", "ThumbnailPath");
        }
    }
}
