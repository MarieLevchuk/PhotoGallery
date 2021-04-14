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
    public class GenreService : IGenreService
    {
        IUnitOfWork _database;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork;
        }
        public IEnumerable<GenreDTO> GetGenres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Genre>, List<GenreDTO>>(_database.Genres.GetAll());
        }

        public GenreDTO GetGenres(int id)
        {
            if (id == null)
                throw new ValidationException("Incorrect id", "");
            var genre = _database.Genres.GetById(id);
            if (genre == null)
                throw new ValidationException("Photo not found", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Photo, PhotoDTO>()).CreateMapper();
            return mapper.Map<Genre, GenreDTO>(_database.Genres.GetById(id));
        }
    }
}
