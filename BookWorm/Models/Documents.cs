using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWorm.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Format Format { get; set; }
        [Key]
        public Category Categories { get; set; }
        public string Excerpt { get; set; }
        [Key]
        public Upload Uploads { get; set; }
        //public HttpPostedFile ImageFile { get; set; }
    }
}