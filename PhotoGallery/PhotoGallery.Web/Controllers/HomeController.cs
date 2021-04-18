using AutoMapper;
using PhotoGallery.BLL.Interfaces;
using PhotoGallery.BLL.Models;
using PhotoGallery.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Web.Controllers
{
    public class HomeController : Controller
    {
        IGenreService _genreService;
        
        IPhotoService _photoService;
        public HomeController(IGenreService genreService, IPhotoService photoService)
        {
            _genreService = genreService;
            _photoService = photoService;
        }

        public ActionResult Index()
        {
            IEnumerable<GenreDTO> genreDtos = _genreService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>()).CreateMapper();
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genreDtos);

            //IEnumerable<PhotoDTO> photosDtos = _photoService.GetPhotos();

            return View(genres);
        }
        
        public ActionResult ToGenre(int genreId)
        {
            GenreDTO genreDto = _genreService.GetById(genreId);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>()).CreateMapper();
            var genre = mapper.Map<GenreDTO, GenreViewModel>(genreDto);
            //var photos = mapper.Map<IEnumerable<PhotoDTO>, List<PhotoViewModel>>(photoDtos);
            //IEnumerable<PhotoDTO> photoDtos = _photoService.GetPhotos();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDTO, PhotoViewModel>()).CreateMapper();
            //var photos = mapper.Map<IEnumerable<PhotoDTO>, List<PhotoViewModel>>(photoDtos);
            return View("Genre", genre);
        }
    }
}