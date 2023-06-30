using System;
using System.Collections.Generic;

namespace DrinkMix.Models;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IngredientTypeId { get; set; }

    public virtual IngredientType IdNavigation { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
