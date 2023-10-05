namespace FoodPantry.Core;

public class Product(string name, string category, string unitSize)
{
    // This field is required for EF Core to be able to map the object to a database table.
    public int Id { get; init; }
    public string Name { get; } = name;
    public string Category { get; } = category;
    public string UnitSize { get; } = unitSize;
}