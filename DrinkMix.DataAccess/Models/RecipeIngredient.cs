using System;
using System.Collections.Generic;

namespace DrinkMix.Models;

public partial class RecipeIngredient : BaseDomainModel
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    /// <summary>
    /// The amount of said ingredient to use in recipe
    /// </summary>
    public double Quantity { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
