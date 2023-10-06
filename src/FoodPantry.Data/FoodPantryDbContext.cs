using FoodPantry.Core;
using Microsoft.EntityFrameworkCore;

namespace FoodPantry.Data;

public class FoodPantryDbContext : DbContext
{
    private readonly string _connectionString;

    public FoodPantryDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<PantryEvent> PantryEvents => Set<PantryEvent>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Go ahead and use whatever `IEntityTypeConfigurations` are in the same assembly as this class.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodPantryDbContext).Assembly);
    }
}