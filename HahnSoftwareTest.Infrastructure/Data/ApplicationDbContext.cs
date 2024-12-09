using HahnSoftwareTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnSoftwareTest.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyEntity>()
                .ToTable("MyEntities")
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}