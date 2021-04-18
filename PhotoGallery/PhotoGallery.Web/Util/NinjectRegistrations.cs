using Ninject.Modules;
using PhotoGallery.BLL.Interfaces;
using PhotoGallery.BLL.Services;

namespace PhotoGallery.Web.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenreService>().To<GenreService>();
            Bind<IPhotoService>().To<PhotoService>();
        }
    }
}