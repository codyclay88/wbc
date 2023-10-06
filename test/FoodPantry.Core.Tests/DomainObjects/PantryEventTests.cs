namespace FoodPantry.Core.Tests.DomainObjects;

public class PantryEventTests
{
    [Fact]
    public void Pantry_event_must_define_start_and_end_time()
    {
        var startsAt = new DateTimeOffset(2023, 10, 4, 16, 0, 0, TimeSpan.Zero);
        var endsAt = new DateTimeOffset(2023, 10, 4, 18, 0, 0, TimeSpan.Zero);
        var pantryEvent = PantryEvent.New(startsAt, endsAt);
        
        Assert.Equal(startsAt, pantryEvent.StartsAt);
        Assert.Equal(endsAt, pantryEvent.EndsAt);
    }
}