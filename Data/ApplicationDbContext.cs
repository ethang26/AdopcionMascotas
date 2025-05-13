using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Pet>()
        .HasOne(p => p.Adoption)
        .WithOne(a => a.Pet)
        .HasForeignKey<Adoption>(a => a.PetId)
        .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Adoption>()
        .HasOne(a => a.Adopter)
        .WithMany(ad => ad.Adoptions)
        .HasForeignKey(a => a.AdopterId);
}

public DbSet<Pet> Pets { get; set; }
public DbSet<Adopter> Adopters { get; set; }
public DbSet<Adoption> Adoptions { get; set; }

}

