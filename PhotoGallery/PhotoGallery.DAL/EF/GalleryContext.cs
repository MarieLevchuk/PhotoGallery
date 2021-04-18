using PhotoGallery.DAL.EntityModels;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhotoGallery.DAL.EF
{
    public class GalleryContext : DbContext
    {
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        static GalleryContext()
        {
            //Database.SetInitializer<GalleryContext>(new GalleryDbInitializer());
        }

        public GalleryContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public class GalleryDbInitializer : DropCreateDatabaseIfModelChanges<GalleryContext>
        {
            protected override void Seed(GalleryContext db)
            {
                db.Photos.Add(new Photo {Title = "owl's eye", Author="Alex JK", Format=".jpg", Path= "/Content/photos/5t68.jpg" });
                db.SaveChanges();

                db.Genres.Add(new Genre {GenreId = 1, Name="Animals" });
                db.Genres.Add(new Genre {GenreId = 2, Name="Birds" });
                db.Genres.Add(new Genre {GenreId = 3, Name="Posters" });
                db.Genres.Add(new Genre {GenreId = 4, Name="Space" });
                db.SaveChanges();
            }
        }
    }
}