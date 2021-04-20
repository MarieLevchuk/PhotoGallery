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
        IEnumerable<PhotoDTO> GetAll();
        IEnumerable<PhotoDTO> GetByFilter(object filter);
        PhotoDTO GetById(int id);
    }
}
