using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.Models
{
    public class PhotoDTO
    {
        public int PhotoId { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public ICollection<GenreDTO> Genres { get; set; }
    }
}
