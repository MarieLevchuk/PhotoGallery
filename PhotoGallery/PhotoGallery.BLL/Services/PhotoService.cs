using AutoMapper;
using PhotoGallery.BLL.Interfaces;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.BLL.Services
{
    class PhotoService : IPhotoService
    {
        IUnitOfWork _database;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public PhotoDTO GetPhoto(int id)
        {
            if(id == null)
                throw new ValidationException("Incorrect id", "");
            var photo = _database.Photos.GetById(id);
            if (photo == null)
                throw new ValidationException("Photo not found", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDTO>()).CreateMapper();
            return mapper.Map<Photo, PhotoDTO>(_database.Photos.GetById(id));
            //return new PhotoDTO { PhotoId = photo.PhotoId, Author = photo.Author, Format=photo.Format, Path = photo.Path, Title = photo.Title };
        }

        public IEnumerable<PhotoDTO> GetPhotos()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Photo>, List<PhotoDTO>>(_database.Photos.GetAll());
        }
    }
}
