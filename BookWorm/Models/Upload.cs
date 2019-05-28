using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BookWorm.Models
{
    public class Upload
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UploadID { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string ThumbnailPath { get; set; }
        }


    }