using AutoMapper;
using PhotoGallery.BLL.Interfaces;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System.Collections.Generic;

namespace PhotoGallery.BLL.Services
{
    public class PhotoService : IPhotoService
    {
        IUnitOfWork _database;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public PhotoDTO GetById(int id)
        {
            if(id == 0)
                throw new ValidationException("Incorrect id", "");
            var photo = _database.Photos.GetById(id);
            if (photo == null)
                throw new ValidationException("Photo not found", "");

            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<Photo, PhotoDTO>();
            }).CreateMapper();

            return mapper.Map<Photo, PhotoDTO>(_database.Photos.GetById(id));
        }

        public IEnumerable<PhotoDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Photo>, List<PhotoDTO>>(_database.Photos.GetAll());
        }
    }
}
