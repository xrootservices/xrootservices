using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using xRootServices.Models;

namespace xRootServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        //public DbSet<BlogCategory> BlogCategory { get; set; }
        //public DbSet<BlogCategoryMap> BlogCategoryMap { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Blog entity
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blogs");

                // Map author_id column properly
                entity.Property(b => b.author_id).HasColumnName("author_id");

                // Define foreign key relationship with Author
                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Blogs) // assuming Author has ICollection<Blog> Blogs property
                      .HasForeignKey(b => b.author_id)
                      .OnDelete(DeleteBehavior.SetNull); // or your preferred delete behavior
            });

            // Configure Author entity if needed
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors");
                // Any additional config if needed
            });
        }
    }
}
