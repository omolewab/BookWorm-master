using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWorm.ViewModels
{
    public class FileViewModel
    {
        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase FileAttach { get; set; }

        /// Gets or sets Image file list.  
        public List<Upload> Uploads { get; set; }
    }
}