namespace FoodPantry.Core;

public class Product
{
    // This is only used for EF Core
    private Product() {}
    
    public static Product New(string name, string category, string unitSize)
    {
        return new Product
        {
            Name = name,
            Category = category,
            UnitSize = unitSize,
        };
    }

    // This field is required for EF Core to be able to map the object to a database table.
    public int Id { get; init; }
    public required string Name { get; init;  }
    public required string Category { get; init; }
    public required string UnitSize { get; init; }
}