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
            
            return View(genres);
        }

        public ActionResult ToGenre(int genreId)
        {
            IEnumerable<PhotoDTO> photoDtos = _photoService.GetPhotos();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDTO, PhotoViewModel>()).CreateMapper();
            var photos = mapper.Map<IEnumerable<PhotoDTO>, List<PhotoViewModel>>(photoDtos);
            return View("Genre", photos);
        }
    }
}