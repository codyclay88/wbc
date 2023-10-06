namespace FoodPantry.Core;

public class PantryEvent
{
    public PantryEvent(DateTimeOffset startsAt, DateTimeOffset endsAt)
    {
        StartsAt = startsAt;
        EndsAt = endsAt;
    }

    // This field is required for EF Core to be able to map the object to a database table.
    // It will be set by EF Core on creation, and managed entirely by EF Core, but we can use it to link to other data in the app. 
    public int Id { get; init; }
    public DateTimeOffset StartsAt { get; }
    public DateTimeOffset EndsAt { get; }
}