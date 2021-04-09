using PhotoGallery.DAL.EF;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        GalleryContext _db;

        public GenreRepository(GalleryContext context)
        {
            _db = context;
        }
        public void Create(Genre genre)
        {
            _db.Genres.Add(genre);
        }

        public void Delete(int id)
        {            
            Genre genre = _db.Genres.Find(id);
            if (genre != null)
                _db.Genres.Remove(genre);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _db.Genres;
        }

        public Genre GetById(int id)
        {
            return _db.Genres.Find(id);
        }

        public void Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }
    }
}
