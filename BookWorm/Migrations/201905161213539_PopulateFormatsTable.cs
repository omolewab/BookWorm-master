namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFormatsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('JPEG')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('PNG')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('GIF')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('TIFF')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('VOB')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('LXF')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('WAV')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('MPEG-2 PS')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('MPEG-TS')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('MXF ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('HDV')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('QuickTime')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('AVI')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('FLV')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('WEBM ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('WMV ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('OGG ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('3GP ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('MP4 ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('DOC')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('DOCX')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('HTML')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('HTM')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('ODT')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('PDF')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('XLS ')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('XLSX')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('ODS')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('PPT')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('PPTX')");
            Sql("INSERT INTO Formats (FileFormat) VALUES  ('TXT')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Formats WHERE DocumentsID IN " +
                           "(1,2,3,4,5,6,7,8,9,10" +
                           ",11,12,13,14,15,16,17,18,19,20" +
                           ",21,22,23,24,25,26,27,28,29,30,31");
        }

    }
}
