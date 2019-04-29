namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBookTypesTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (1,'Art')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (2,'Biography')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (3,'Business')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (4,'Chick Lit')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (5,'Childrens')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (6,'Christian')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (7,'Classics')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (8,'Comics')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (9,'Contemporary')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (10,'Cookbooks')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (11,'Crime')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (12,'Ebooks')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (13,'Fantasy')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (14,'Fiction')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (15,'Graphic Novels')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (16,'Historical Fiction')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (17,'History')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (18,'Homosexuality')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (19,'Horror')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (20,'Humor and Comedy')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (21,'Manga')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (22,'Memoir')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (23,'Music')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (24,'Mystery')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (25,'Nonfiction')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (26,'Paranormal')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (27,'Philosophy')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (28,'Poetry')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (29,'Psychology')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (30,'Religion')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (31,'Romance')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (32,'Science')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (33,'Science Fiction')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (34,'Self Help')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (35,'Suspense')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (36,'Spirituality')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (37,'Sports')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (38,'Thriller')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (39,'Travel')");
            Sql("INSERT INTO BookTypes (Id, Genre) VALUES (40,'Young Adult')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM BookTypes WHERE Id IN " +
               "(41,2,3,4,5,6,7,8,9,10" +
               ",11,12,13,14,15,16,17,18,19,20" +
               ",21,22,23,24,25,26,27,28,29,30" +
               ",31,32,33,34,35,36,37,38,39,40)");
        }
    }
}
