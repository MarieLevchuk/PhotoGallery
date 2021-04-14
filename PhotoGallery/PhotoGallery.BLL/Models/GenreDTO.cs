using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.Models
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; }
    }
}
