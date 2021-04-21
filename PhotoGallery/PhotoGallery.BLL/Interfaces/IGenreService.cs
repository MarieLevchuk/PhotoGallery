using PhotoGallery.BLL.Models;
using System.Collections.Generic;

namespace PhotoGallery.BLL.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreDTO> GetAll();
        GenreDTO GetById(int id);
    }
}
