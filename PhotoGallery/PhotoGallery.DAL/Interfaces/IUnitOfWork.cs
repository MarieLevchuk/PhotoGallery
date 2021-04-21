using PhotoGallery.DAL.EntityModels;
using System;

namespace PhotoGallery.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Photo> Photos { get; }
        IRepository<Genre> Genres { get; }
        void Save();
    }
}
