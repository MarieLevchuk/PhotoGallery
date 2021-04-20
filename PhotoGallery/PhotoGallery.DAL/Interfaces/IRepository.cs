using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFilter(object filter);
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
