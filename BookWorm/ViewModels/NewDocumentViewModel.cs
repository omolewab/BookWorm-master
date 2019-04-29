using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWorm.ViewModels
{
    public class NewDocumentViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public int FormatId { get; set; }
        public IEnumerable<DFormat> DFormats { get; set; }
        public string Excerpt { get; set; }
        public int BookTypeId { get; set; }
        public IEnumerable<BookType> BookTypes { get; set; }
        public int UploadId { get; set; }
        public HttpPostedFile ImageFile { get; set; }

    }
}