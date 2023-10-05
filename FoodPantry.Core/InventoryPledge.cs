namespace FoodPantry.Core;

public class InventoryPledge
{
    public InventoryPledge(int memberId, int productId, int quantity, DateTimeOffset pledgedOn)
    {
        MemberId = memberId;
        ProductId = productId;
        Quantity = quantity;
        PledgedOn = pledgedOn;   
    }

    // This field is required for EF Core to be able to map the object to a database table.
    public int Id { get; init; }
    public int MemberId { get; }
    public int ProductId { get; }
    public int Quantity { get; }
    public DateTimeOffset PledgedOn { get; }
    public DateTimeOffset? FulfilledOn { get; private set; }

    public void Fulfill(DateTimeOffset fulfilledDate)
    {
        FulfilledOn = fulfilledDate;
    }
}