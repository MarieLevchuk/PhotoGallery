using AutoMapper;
using PhotoGallery.BLL.Interfaces;
using PhotoGallery.BLL.Models;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System.Collections.Generic;

namespace PhotoGallery.BLL.Services
{
    public class GenreService : IGenreService
    {
        IUnitOfWork _database;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }

        public IEnumerable<GenreDTO> GetAll()
        {            
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Photo, PhotoDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(_database.Genres.GetAll());
        }

        public GenreDTO GetById(int id)
        {
            if (id == 0)
                throw new ValidationException("Incorrect id", "");

            Genre genre = _database.Genres.GetById(id);
            if (genre == null)
                throw new ValidationException("Genre not found", "");

            
            var mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<Photo, PhotoDTO>();
                cfg.CreateMap<IEnumerable<Photo>, List<PhotoDTO>>();
            }).CreateMapper();

            return mapper.Map<Genre, GenreDTO>(genre);
        }
    }
}
