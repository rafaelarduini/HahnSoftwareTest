using HahnSoftwareTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnSoftwareTest.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<AdviceSlip> AdviceSlips => Set<AdviceSlip>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AdviceSlip>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Advice).IsRequired().HasMaxLength(500);
        });
    }
}