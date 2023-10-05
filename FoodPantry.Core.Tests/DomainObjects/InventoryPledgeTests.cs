namespace FoodPantry.Core.Tests.DomainObjects;

public class InventoryPledgeTests
{
    [Fact]
    public void Requires_memberId_and_productId_and_quantity_and_pledgedOn()
    {
        var pledgedOn = DateTimeOffset.Now;
        var pledge = new InventoryPledge(memberId: 1, productId: 2, quantity: 3, pledgedOn);
        
        Assert.Equal(1, pledge.MemberId);
        Assert.Equal(2, pledge.ProductId);
        Assert.Equal(3, pledge.Quantity);
        Assert.Equal(pledgedOn, pledge.PledgedOn);
    }

    [Fact]
    public void FulfilledOn_defaults_to_null()
    {
        var pledge = new InventoryPledge(memberId: 1, productId: 2, quantity: 3, DateTimeOffset.Now.AddDays(-7));
        
        Assert.Null(pledge.FulfilledOn);
    }
    
    [Fact]
    public void FulfilledOn_can_be_updated()
    {
        var pledge = new InventoryPledge(memberId: 1, productId: 2, quantity: 3, DateTimeOffset.Now.AddDays(-7));
        var fulfilledDate = DateTimeOffset.Now;
        
        pledge.Fulfill(fulfilledDate);
        
        Assert.Null(pledge.FulfilledOn);
    }
}