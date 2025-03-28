using Microsoft.EntityFrameworkCore;

namespace Inmemory_Collection.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
            
        }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<CategoryModel> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>()
                .HasOne<CategoryModel>()
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

        }
    }
}
