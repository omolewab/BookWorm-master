namespace BookWorm.Models
{
    public class Format
    {
        public int Id { get; set; }
        public string FileFormat { get; set; }

        public Format(int id, string FileFormat)
        {
            this.Id = id;
            this.FileFormat = FileFormat;
        }
        public Format()
        {
        }
    }
}