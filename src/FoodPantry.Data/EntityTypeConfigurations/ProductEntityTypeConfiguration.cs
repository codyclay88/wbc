using FoodPantry.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodPantry.Data.EntityTypeConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products", schema: "pantry");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("id");
        builder.Property(i => i.Name).HasColumnName("name").HasColumnType("text");
    }
}

public class PantryEventEntityTypeConfiguration : IEntityTypeConfiguration<PantryEvent>
{
    public void Configure(EntityTypeBuilder<PantryEvent> builder)
    {
        builder.ToTable("pantry_events", schema: "pantry");
    }
}