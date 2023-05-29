using Microsoft.EntityFrameworkCore;
using VoteMicroservice.DataAccessLayer.Models;

namespace VoteMicroservice.DataAccessLayer.Data
{
    public class VoteMicroserviceDBContext : DbContext
    {
        public VoteMicroserviceDBContext(DbContextOptions<VoteMicroserviceDBContext> options)
            : base(options)
        {
        }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity mappings and relationships
            modelBuilder.Entity<Vote>()
                .HasKey(v => v.VoteId);

            modelBuilder.Entity<Vote>()
                .Property(v => v.VoteId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Post)
                .WithMany(p => p.Votes)
                .HasForeignKey(v => v.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
