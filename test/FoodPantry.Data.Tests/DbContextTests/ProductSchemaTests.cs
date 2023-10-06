using FoodPantry.Core;
using FoodPantry.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace FoodPantry.Data.Tests.DbContextTests;

public class ProductSchemaTests : SchemaTestsBase<FoodPantryDbContext>, IClassFixture<DatabaseFixture>
{
    public ProductSchemaTests(DatabaseFixture fixture) : base(fixture.DbContext, "products", "pantry")
    {
    }

    [Fact]
    public void Has_correct_schema()
    {
        AssertTableExists();
        AssertColumnExists("id", "integer");
        AssertColumnExists("name", "text");
    }
    
    [Fact]
    public async Task Can_manage_products()
    {
        var product = Product.New("Milk", "Dairy", "1 Gallon");
        
        await DbContext.Products.AddAsync(product);
        
        var rowsAffected = await DbContext.SaveChangesAsync();

        var persistedProduct = await DbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        
        Assert.NotNull(persistedProduct);
        
        Assert.True(rowsAffected == 1);
        Assert.Equal(1, persistedProduct.Id);
        Assert.Equal("Milk", persistedProduct.Name);
        Assert.Equal("Dairy", persistedProduct.Category);
        Assert.Equal("1 Gallon", persistedProduct.UnitSize);
    }
}