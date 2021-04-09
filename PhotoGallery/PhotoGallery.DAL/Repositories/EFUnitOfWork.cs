using PhotoGallery.DAL.EF;
using PhotoGallery.DAL.EntityModels;
using PhotoGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        GalleryContext _db;
        PhotoRepository _photoRepository;
        GenreRepository _genreRepository;

        public EFUnitOfWork(GalleryContext context)
        {
            _db = context;
        }

        public IRepository<Photo> Photos
        {
            get
            {
                if (_photoRepository == null)
                    _photoRepository = new PhotoRepository(_db);
                return _photoRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(_db);
                return _genreRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
