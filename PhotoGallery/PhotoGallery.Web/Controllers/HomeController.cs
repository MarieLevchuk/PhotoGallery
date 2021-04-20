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
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<PhotoDTO, PhotoViewModel>();
            }).CreateMapper();
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(genreDtos);

            return View(genres);
        }
        
        public ActionResult ToGenre(int genreId)
        {
            GenreDTO genreDto = _genreService.GetById(genreId);
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<PhotoDTO, PhotoViewModel>();
            }).CreateMapper();
            var genre = mapper.Map<GenreDTO, GenreViewModel>(genreDto);

            return View("Genre", genre);
        }

        public ActionResult ToInfo(int photoId)
        {
            PhotoDTO photoDTO = _photoService.GetById(photoId);
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<PhotoDTO, PhotoViewModel>();
            }).CreateMapper();
            var photo = mapper.Map<PhotoDTO, PhotoViewModel>(photoDTO);
            return View("Info", photo);
        }

        [HttpPost]
        public ActionResult Edit(PhotoViewModel photoViewModel)
        {
            PhotoDTO photoDTO = _photoService.GetById(photoViewModel.PhotoId);
            photoDTO.Title = photoViewModel.Title;
            photoDTO.Author = photoViewModel.Author;

            return RedirectToAction("Index");
        }
    }
}