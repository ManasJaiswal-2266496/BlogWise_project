using BlogWise_project.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWise_project.DataAccessLayer.Data
{
    public class BlogWiseDBContext : DbContext
    {
        public BlogWiseDBContext(DbContextOptions<BlogWiseDBContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Content).IsRequired();
                entity.Property(p => p.Author).IsRequired();
                
            });

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
