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
        public string DName { get; set; }
        public string DAuthor { get; set; }
        public DFormat DFormat { get; set; }
        [Key]
        public BookType BookType { get; set; }
        public string DExcerpt { get; set; }
        [Key]
        public Upload Uploads { get; set; }
        public HttpPostedFile ImageFile { get; set; }
    }
}