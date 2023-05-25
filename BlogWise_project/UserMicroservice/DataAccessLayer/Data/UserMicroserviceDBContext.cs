using Microsoft.EntityFrameworkCore;
using UserMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.DataAccessLayer.Data
{
    public class UserMicroserviceDBContext : DbContext
    {
        public UserMicroserviceDBContext(DbContextOptions<UserMicroserviceDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
