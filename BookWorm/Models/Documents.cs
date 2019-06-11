using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWorm.Models
{
    public class Documents
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DocumentsID { get; set; }
        public string Name { get; set; }
        public string Excerpt { get; set; }
        public string Author { get; set; }
        public int FormatID { get; set; }
        public virtual Format Format { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int UploadID { get; set; }
        public virtual Upload Uploads { get; set; }
    }
}

