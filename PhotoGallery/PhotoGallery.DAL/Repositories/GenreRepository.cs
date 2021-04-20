using PhotoGallery.DAL.EF;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
            IEnumerable<Genre> genres = _db.Genres;

            foreach (var genre in genres)
            {
                _db.Entry(genre).Collection(g => g.Photos).Load();
            }
            return genres;
        }

        public IEnumerable<Genre> GetByFilter(object filter)
        {
            throw new NotImplementedException();
        }

        public Genre GetById(int id)
        {
            Genre genre = _db.Genres.Find(id);
            _db.Entry(genre).Collection(g => g.Photos).Load();
            return genre;
        }

        public void Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }
    }
}
