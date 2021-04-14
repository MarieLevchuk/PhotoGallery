using Ninject.Modules;
using PhotoGallery.DAL.Interfaces;
using PhotoGallery.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
