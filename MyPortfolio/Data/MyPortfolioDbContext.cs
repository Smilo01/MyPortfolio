using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;
using MyPortfolio.Models.ViewModels;

namespace MyPortfolio.Data
{

    public class MyPortfolioDbContext : IdentityDbContext<IdentityUser>
    {
        public MyPortfolioDbContext(DbContextOptions<MyPortfolioDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<ExperienceHighlight> ExperienceHighlights { get; set; }
        // You can customize the Identity model relationships here if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This adds the Identity model configuration

            // You can also customize Identity tables if needed
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users"); // Optional: rename the table
        }
    }
}
