using DrinkMix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkMix.Data.SeedData
{
    public class GlassTypeConfiguration : IEntityTypeConfiguration<GlassType>
    {
        public void Configure(EntityTypeBuilder<GlassType> builder)
        {
            builder.HasData(
                new GlassType { Id = 1, Name = "Red Wine Glass" },
                new GlassType { Id = 2, Name = "White Wine Glass" },
                new GlassType { Id = 3, Name = "Flute Glass" },
                new GlassType { Id = 4, Name = "Cocktail Glass" },
                new GlassType { Id = 5, Name = "Highball Glass" },
                new GlassType { Id = 6, Name = "Lowball Glass" },
                new GlassType { Id = 7, Name = "Irish Coffee Glass" },
                new GlassType { Id = 8, Name = "Hurricane Glass" },
                new GlassType { Id = 9, Name = "Martini Glass" },
                new GlassType { Id = 10, Name = "Margarita Glass" },
                new GlassType { Id = 11, Name = "The glencairn Whiskey Glass" },
                new GlassType { Id = 12, Name = "Snifter Glass" }
            );
        }
    }
}
