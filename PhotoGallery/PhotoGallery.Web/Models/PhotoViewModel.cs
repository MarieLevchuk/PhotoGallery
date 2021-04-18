using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web.Models
{
    public class PhotoViewModel
    {
        public int PhotoId { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }
    }
}