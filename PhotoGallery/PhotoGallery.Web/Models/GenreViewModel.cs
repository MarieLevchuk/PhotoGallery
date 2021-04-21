using System.Collections.Generic;

namespace PhotoGallery.Web.Models
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<PhotoViewModel> Photos { get; set; }
    }
}