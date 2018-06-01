using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NilamHutAPI.Models;

namespace NilamHutAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<SoldHistory> SoldHistories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Bid> Bid { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductTag>().HasKey( k => new {k.ProductId, k.TagId});
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
