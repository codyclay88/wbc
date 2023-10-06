using FoodPantry.Core;

namespace FoodPantry.Data.Tests;

public class FoodPantryDbContextTests : IClassFixture<DatabaseFixture>
{
    private readonly FoodPantryDbContext _dbContext;
    
    public FoodPantryDbContextTests(DatabaseFixture fixture)
    {
        _dbContext = fixture.DbContext ?? throw new ArgumentNullException(nameof(fixture.DbContext));
    }
    
    [Fact]
    public async Task Can_create_instance()
    {
        var product = Product.New("Milk", "Dairy", "1 Gallon");
        
        await _dbContext.Products.AddAsync(product);
        
        var rowsAffected = await _dbContext.SaveChangesAsync();
        
        Assert.True(rowsAffected == 1);
        Assert.Equal(1, product.Id);
    }
}