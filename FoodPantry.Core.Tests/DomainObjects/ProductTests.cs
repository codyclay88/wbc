namespace FoodPantry.Core.Tests.DomainObjects;

public class ProductTests
{
    [Fact]
    public void Products_have_name_category_and_unit_size()
    {
        var product = new Product("Milk", "Dairy", "Gallon");

        Assert.Equal("Milk", product.Name);
        Assert.Equal("Dairy", product.Category);
        Assert.Equal("Gallon", product.UnitSize);
    }
}