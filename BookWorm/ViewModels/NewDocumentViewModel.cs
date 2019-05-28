using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookWorm.ViewModels
{
    public class NewDocumentViewModel
    {
       // [Required]
        public string Name { get; set; }
       // [Required]
        public string Author { get; set; }
        public int FormatID { get; set; }
        public int SelectedFormatID { get; set; }
        public IEnumerable<Format> Formats { get; set; }
        public string Excerpt { get; set; }
        public int CategoryID { get; set; }
        public byte ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string ThumbnailPath { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        //public int UploadId { get; set; }
        public IEnumerable <HttpPostedFileBase> docs { get; set; }
        public IEnumerable<HttpPostedFileBase> thumbnails { get; set; }

    }
}