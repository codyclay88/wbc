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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}