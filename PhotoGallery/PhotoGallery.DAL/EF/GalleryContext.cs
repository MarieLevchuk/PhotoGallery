using PhotoGallery.DAL.EntityModels;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace PhotoGallery.DAL.EF
{
    public class GalleryContext : DbContext
    {
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public GalleryContext()
            : base("name=GalleryContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}