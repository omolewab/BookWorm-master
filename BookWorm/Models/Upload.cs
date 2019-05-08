using System.Web;

namespace BookWorm.Models
{
    public class Upload
    {
        public byte Id { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        }


    }