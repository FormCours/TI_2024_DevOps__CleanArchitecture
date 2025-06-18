using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoCleanArchitecture.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Member> Member { get; set; }


        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
