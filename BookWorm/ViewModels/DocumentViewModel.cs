using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorm.ViewModels
{
    public class DocumentViewModel
    {
        public int DocumentsID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Excerpt { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DownloadUrl { get; set; }

    }
}