using System;
using System.Collections.Generic;

namespace DrinkMix.Models;

public partial class Recipe : BaseDomainModel
{

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int GlassTypeId { get; set; }

    public virtual GlassType GlassType { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
