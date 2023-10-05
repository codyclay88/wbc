namespace FoodPantry.Core.Tests.DomainObjects;

public class EventInventoryRequirementTests
{
    [Fact]
    public void Has_eventId_and_productId_and_quantity()
    {
        var eventInventoryRequirement = new EventInventoryRequirement(pantryEventId: 1, productId: 2, minimumQuantity: 3);
        
        Assert.Equal(1, eventInventoryRequirement.PantryEventId);
        Assert.Equal(2, eventInventoryRequirement.ProductId);
        Assert.Equal(3, eventInventoryRequirement.MinimumQuantity);
    }

    [Fact]
    public void Can_change_the_quantity()
    {
        var eventInventoryRequirement = new EventInventoryRequirement(pantryEventId: 1, productId: 2, minimumQuantity: 3);
        eventInventoryRequirement.UpdateQuantity(5);
        
        Assert.Equal(5, eventInventoryRequirement.MinimumQuantity);
    }
}