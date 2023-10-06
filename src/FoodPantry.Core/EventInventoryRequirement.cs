namespace FoodPantry.Core;

public class EventInventoryRequirement
{
    public EventInventoryRequirement(int pantryEventId, int productId, int minimumQuantity)
    {
        PantryEventId = pantryEventId;
        ProductId = productId;
        MinimumQuantity = minimumQuantity;
    }

    // This field is required for EF Core to be able to map the object to a database table.
    public int Id { get; init; }
    public int PantryEventId { get; }
    public int ProductId { get; }
    public int MinimumQuantity { get; private set; }

    public void UpdateQuantity(int newQuantity)
    {
        MinimumQuantity = newQuantity;
    }
}