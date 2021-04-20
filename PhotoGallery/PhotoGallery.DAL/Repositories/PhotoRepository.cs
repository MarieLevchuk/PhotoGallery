using PhotoGallery.DAL.EF;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PhotoGallery.DAL.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
        GalleryContext _db;

        public PhotoRepository(GalleryContext context)
        {
            _db = context;
        }
        public void Create(Photo photo)
        {
            _db.Photos.Add(photo);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Photo photo = _db.Photos.Find(id);
            if (photo != null)
            {
                _db.Photos.Remove(photo);
                _db.SaveChanges();
            }                
        }

        public IEnumerable<Photo> GetAll()
        {            
            return _db.Photos;
        }

        public IEnumerable<Photo> GetItemsByGenre(object photoFilter, Genre genre)
        {
            if (photoFilter != null)
            {
                return _db.Photos.OrderByDescending(i => i.PhotoId).Where(i => i.Genres.Contains(genre)).Take((int)photoFilter);
            }                
            else
                return _db.Photos;
        }

        public Photo GetById(int id)
        {            
            Photo photo = _db.Photos.Find(id);
            _db.Entry(photo).Collection(g => g.Genres).Load();
            return photo;
        }

        public void Update(Photo photo)
        {
            _db.Entry(photo).State = EntityState.Modified;
        }

        public IEnumerable<Photo> GetByFilter(object filter)
        {
            throw new NotImplementedException();
        }
    }
}
