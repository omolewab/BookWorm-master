using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Format Format { get; set; }
        public Category Category { get; set; }
        public string Excerpt { get; set; }
        public Upload Uploads { get; set; }
        //public string ImageName { get; set; }
        //public  string ImagePath { get; set; }
    }
}