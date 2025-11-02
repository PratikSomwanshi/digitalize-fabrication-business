using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Utilities.Enumes;
using Microsoft.EntityFrameworkCore;

namespace DigitalizeFabricationBussiness.ApplicationDBContext;

public class DigitalizeFabricationBusinessDBContext : DbContext
{

    public DigitalizeFabricationBusinessDBContext(DbContextOptions<DigitalizeFabricationBusinessDBContext> options) :
        base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity(j => j.ToTable("user_roles"));

        modelBuilder.Entity<User>()
            .HasOne(u => u.Address)
            .WithOne()
            .HasForeignKey<Address>(a => a.UserId);

        modelBuilder.Entity<Product>()
            .Property(p => p.ProductImages)
            .HasColumnType("text[]");
        
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"), RoleName = nameof(RolesEnum.ADMIN) },
            new Role { RoleId = Guid.Parse("00000000-0000-0000-0000-000000000002"), RoleName = nameof(RolesEnum.CUSTOMER) }
        );
        
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }
}