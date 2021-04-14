using PhotoGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<PhotoDTO> GetPhotos();
        PhotoDTO GetPhoto(int id);
    }
}
