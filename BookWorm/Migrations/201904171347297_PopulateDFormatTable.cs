namespace BookWorm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDFormatTable : DbMigration
    {

        public override void Up()
        {
            Sql("INSERT INTO DFormats ( FileFormat) VALUES ('JPEG')");
            Sql("INSERT INTO DFormats ( FileFormat) VALUES ('PNG')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('GIF')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('TIFF')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('VOB')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('LXF')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('WAV')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('MPEG-2 PS')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('MPEG-TS')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('MXF ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('HDV')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('QuickTime')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('AVI')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('FLV')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('WEBM ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('WMV ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('OGG ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('3GP ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('MP4 ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.DOC')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.DOCX')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.HTML')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.HTM')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.ODT')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.PDF')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.XLS ')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.XLSX')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.ODS')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.PPT')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.PPTX')");
            Sql("INSERT INTO DFormats (FileFormat) VALUES ('.TXT')");


        }

        public override void Down()
        {
            Sql("DELETE FROM DFormats WHERE Id IN " +
                            "(1,2,3,4,5,6,7,8,9,10" +
                            ",11,12,13,14,15,16,17,18,19,20" +
                            ",21,22,23,24,25,26,27,28,29,30,31");
        }
    }
}
