using FrogFraternityBeta.Models;
using Microsoft.EntityFrameworkCore;

namespace FrogFraternityBeta.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
         public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<User>().ToTable("Users"); 
        }

        public DbSet<FrogFraternityBeta.Models.LoginViewModel> LoginViewModel { get; set; }

        public DbSet<FrogFraternityBeta.Models.RegisterViewModel> RegisterViewModel { get; set; }
    }
}