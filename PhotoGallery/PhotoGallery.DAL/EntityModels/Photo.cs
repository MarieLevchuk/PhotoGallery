using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.DAL.EntityModels
{
    [Table("Photo")]
    public class Photo
    {
        public int PhotoId { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }
        public string Format { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
