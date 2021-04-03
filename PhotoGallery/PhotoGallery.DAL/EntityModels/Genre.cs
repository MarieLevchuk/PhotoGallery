using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.DAL.EntityModels
{
    [Table("Genre")]
    public class Genre
    {
        public int GenreId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
