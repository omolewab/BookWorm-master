namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Categories) VALUES (1,'Art')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (2,'Biography')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (3,'Business')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (4,'Chick Lit')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (5,'Childrens')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (6,'Christian')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (7,'Classics')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (8,'Comics')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (9,'Contemporary')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (10,'Cookbooks')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (11,'Crime')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (12,'Ebooks')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (13,'Fantasy')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (14,'Fiction')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (15,'Graphic Novels')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (16,'Historical Fiction')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (17,'History')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (18,'Homosexuality')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (19,'Horror')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (20,'Humor and Comedy')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (21,'Manga')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (22,'Memoir')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (23,'Music')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (24,'Mystery')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (25,'Nonfiction')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (26,'Paranormal')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (27,'Philosophy')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (28,'Poetry')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (29,'Psychology')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (30,'Religion')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (31,'Romance')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (32,'Science')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (33,'Science Fiction')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (34,'Self Help')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (35,'Suspense')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (36,'Spirituality')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (37,'Sports')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (38,'Thriller')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (39,'Travel')");
            Sql("INSERT INTO Categories (Id, Categories) VALUES (40,'Young Adult')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN " +
               "(41,2,3,4,5,6,7,8,9,10" +
               ",11,12,13,14,15,16,17,18,19,20" +
               ",21,22,23,24,25,26,27,28,29,30" +
               ",31,32,33,34,35,36,37,38,39,40)");
        }
    }
}
