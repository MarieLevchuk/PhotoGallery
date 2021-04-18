
using Ninject.Modules;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Repositories;

namespace PhotoGallery.BLL.Models
{
    public class ServiceModule : NinjectModule
    {
        string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
