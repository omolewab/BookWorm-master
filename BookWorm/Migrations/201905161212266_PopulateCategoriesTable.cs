namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories ( Categories) VALUES ('Art')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Biography')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Business')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Chick Lit')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Childrens')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Christian')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Classics')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Comics')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Contemporary')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Cookbooks')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Crime')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Ebooks')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Fantasy')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Fiction')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Graphic Novels')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Historical Fiction')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('History')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Homosexuality')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Horror')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Humor and Comedy')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Manga')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Memoir')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Music')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Mystery')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Nonfiction')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Paranormal')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Philosophy')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Poetry')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Psychology')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Religion')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Romance')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Science')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Science Fiction')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Self Help')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Suspense')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Spirituality')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Sports')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Thriller')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Travel')");
            Sql("INSERT INTO Categories ( Categories) VALUES ('Young Adult')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE DocumentsID IN " +
                 "(1,2,3,4,5,6,7,8,9,10" +
                 ",11,12,13,14,15,16,17,18,19,20" +
                 ",21,22,23,24,25,26,27,28,29,30" +
                 ",31,32,33,34,35,36,37,38,39,40)");
        }
    }
}
