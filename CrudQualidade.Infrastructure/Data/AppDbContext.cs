using CrudQualidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudQualidade.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().HasData(
                     new People { Id = 1, Name = "Lucas", LastName = "Oliveira", NumberPhone = "64123456879", Age = 25, City = "Rio Verde", Email = "lucas@email.com" },
                      new People { Id = 2, Name = "Márcia", LastName = "Oliveira", NumberPhone = "64123412342", Age = 44, City = "Rio Verde", Email = "marcia@email.com" }
                 );
            
            modelBuilder.Entity<Friendship>().HasKey(
                f => new {f.PersonId1, f.PersonId2}
            );
            modelBuilder.Entity<Friendship>().HasData(
                new Friendship { PersonId1 = 1, PersonId2 = 2 }
            );

            
            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.People1)
                .WithMany(p => p.FriendshipsInitialized)
                .HasForeignKey(c => c.PersonId1)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.People2)
                .WithMany(p => p.FriendshipsAccepted)
                .HasForeignKey(c => c.PersonId2)
                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<People>()
            //         .HasKey(p => new {p.Id });
        }
    }
}
