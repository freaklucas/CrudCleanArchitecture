using CrudQualidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudQualidade.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<People>? Peoples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasData(
                     new People { Id = 1, Name = "Lucas", LastName = "Oliveira", NumberPhone = "64123456879", Age = 25, City = "Rio Verde", Email = "lucas@email.com" },
                      new People { Id = 2, Name = "Márcia", LastName = "Oliveira", NumberPhone = "64123412342", Age = 44, City = "Rio Verde", Email = "marcia@email.com" }
                 );

            //modelBuilder.Entity<People>()
            //         .HasKey(p => new {p.Id });
        }
    }
}
