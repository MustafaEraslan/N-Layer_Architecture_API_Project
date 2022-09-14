using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        //DbContextOptions veritabanı yolunu startup dosyasından
        //verebilmek için yazıyoruz.
        //Bu dbcontext'te yaptığımız standart bir ctor

        //Her bir etitity'e karşılık dbset oluşturulur
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //model oluşurken çalıcak methodum
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
