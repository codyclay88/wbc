namespace FoodPantry.Core;

public class InventoryDonation
{
    public InventoryDonation(int memberId, int productId, int quantity, DateTimeOffset donatedOn)
    {
        MemberId = memberId;
        ProductId = productId;
        Quantity = quantity;
        DonatedOn = donatedOn;
    }
    
    // This is required for EF Core to be able to map the object to a database table.
    public int Id { get; init; }
    public int MemberId { get; }
    public int ProductId { get; }
    public int Quantity { get; }
    public DateTimeOffset DonatedOn { get; }
}