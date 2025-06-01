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
    }
}
