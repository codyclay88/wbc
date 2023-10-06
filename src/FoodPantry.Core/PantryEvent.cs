namespace FoodPantry.Core;

public class PantryEvent
{
    private PantryEvent() { }
    
    public static PantryEvent New(DateTimeOffset startsAt, DateTimeOffset endsAt)
    {
        return new PantryEvent
        {
            StartsAt = startsAt,
            EndsAt = endsAt,
        };
    }

    // This field is required for EF Core to be able to map the object to a database table.
    // It will be set by EF Core on creation, and managed entirely by EF Core, but we can use it to link to other data in the app. 
    public int Id { get; init; }
    public required DateTimeOffset StartsAt { get; init; }
    public required DateTimeOffset EndsAt { get; init; }
}