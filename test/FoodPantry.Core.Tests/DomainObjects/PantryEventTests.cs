namespace FoodPantry.Core.Tests.DomainObjects;

public class PantryEventTests
{
    [Fact]
    public void Pantry_event_must_define_start_and_end_time()
    {
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var offset = timeZoneInfo.BaseUtcOffset;
        var startsAt = new DateTimeOffset(2023, 10, 4, 16, 0, 0, offset);
        var endsAt = new DateTimeOffset(2023, 10, 4, 18, 0, 0, offset);
        var pantryEvent = new PantryEvent(startsAt, endsAt);
        
        Assert.Equal(startsAt, pantryEvent.StartsAt);
        Assert.Equal(endsAt, pantryEvent.EndsAt);
    }
}