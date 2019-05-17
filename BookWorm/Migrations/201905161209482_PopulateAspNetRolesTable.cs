namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAspNetRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles(Id, Name, Discriminator) VALUES (1, 'Admin', 'ApplicationRole')");
            Sql("INSERT INTO AspNetRoles(Id, Name, Discriminator) VALUES (2, 'Registered', 'ApplicationRole')");
        }

        public override void Down()
        {
            Sql("DELETE FROM AspNetRoles WHERE Id in ('1,2')");
        }
    }
}
