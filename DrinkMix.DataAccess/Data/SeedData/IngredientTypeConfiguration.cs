using DrinkMix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IngredientTypeConfiguration : IEntityTypeConfiguration<IngredientType>
{
    public void Configure(EntityTypeBuilder<IngredientType> builder)
    {
        builder.HasData(
            new IngredientType { Id = 1, Name = "Whiskey" },
            new IngredientType { Id = 2, Name = "Vodka" },
            new IngredientType { Id = 3, Name = "Gin" },
            new IngredientType { Id = 4, Name = "Rum" },
            new IngredientType { Id = 5, Name = "Tequila" }
        );
    }
}
