using System;
using System.Collections.Generic;

namespace DrinkMix.DataAccess.Models;

public partial class Recipe : BaseDomainModel
{
    public int Name { get; set; }

    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int GlassTypeId { get; set; }

    public virtual GlassType GlassType { get; set; } = null!;
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = null!;
}
