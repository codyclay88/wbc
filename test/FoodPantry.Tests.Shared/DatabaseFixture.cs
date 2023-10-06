using FoodPantry.Data;
using Testcontainers.PostgreSql;
using Xunit;

namespace FoodPantry.Tests.Shared;

public class DatabaseFixture : IAsyncLifetime
{
    private PostgreSqlContainer? DbContainer { get; set; }
    public FoodPantryDbContext? DbContext { get; private set; }

    public async Task InitializeAsync()
    {
        DbContainer = new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .WithDatabase("foodpantry")
            .WithUsername("postgres")
            .WithPassword("postgres")
            .Build();
        
        await DbContainer.StartAsync();
        
        var connectionString = DbContainer.GetConnectionString();
        DbContext = new FoodPantryDbContext(connectionString);
        
        await DbContext.Database.EnsureCreatedAsync();
    }

    public Task DisposeAsync()
    {
        // Do I need to dispose anything here?

        return Task.CompletedTask;
    }
}