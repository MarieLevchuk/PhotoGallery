using PhotoGallery.BLL.Models;
using System.Collections.Generic;

namespace PhotoGallery.BLL.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<PhotoDTO> GetAll();
        PhotoDTO GetById(int id);
    }
}
