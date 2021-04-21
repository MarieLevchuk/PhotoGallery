using PhotoGallery.DAL.EntityModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhotoGallery.DAL.EF
{
    public class GalleryContext : DbContext
    {
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        public GalleryContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}