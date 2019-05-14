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
       // [Required]
        public string Name { get; set; }
       // [Required]
        public string Author { get; set; }
        public int FormatId { get; set; }
        //public IEnumerable<Format> Formats { get; set; }
        public string Excerpt { get; set; }
        public int CategoryId { get; set; }
        public byte ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
         //public IEnumerable<Category> Categories { get; set; }
        //public int UploadId { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }

    }
}