using FoodPantry.Core;
using FoodPantry.Tests.Shared;
using Microsoft.EntityFrameworkCore;

namespace FoodPantry.Data.Tests.DbContextTests;

public class PantryEventSchemaTests : SchemaTestsBase<FoodPantryDbContext>, IClassFixture<DatabaseFixture>
{
    public PantryEventSchemaTests(DatabaseFixture fixture) : base(fixture.DbContext, "pantry_events", "pantry")
    {
    }
    
    [Fact]
    public async Task Can_manage_pantryEvents()
    {
        var startsAt = new DateTimeOffset(2023, 10, 4, 16, 0, 0, TimeSpan.Zero);
        var endsAt = new DateTimeOffset(2023, 10, 4, 18, 0, 0, TimeSpan.Zero);
        var pantryEvent = PantryEvent.New(startsAt, endsAt);
        
        await DbContext.PantryEvents.AddAsync(pantryEvent);
        
        var rowsAffected = await DbContext.SaveChangesAsync();
        
        var persistedPantryEvent = await DbContext.PantryEvents.FirstOrDefaultAsync(p => p.Id == pantryEvent.Id);
        
        Assert.NotNull(persistedPantryEvent);
        
        Assert.True(rowsAffected == 1);
        Assert.Equal(1, persistedPantryEvent.Id);
        Assert.Equal(startsAt, persistedPantryEvent.StartsAt);
        Assert.Equal(endsAt, persistedPantryEvent.EndsAt);
    }
}