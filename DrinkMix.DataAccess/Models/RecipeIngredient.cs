using System;
using System.Collections.Generic;

namespace DrinkMix.DataAccess.Models;

public partial class RecipeIngredient
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    public decimal Quantity { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
