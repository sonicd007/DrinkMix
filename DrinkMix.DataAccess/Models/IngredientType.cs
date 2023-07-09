using System;
using System.Collections.Generic;

namespace DrinkMix.Models;

public partial class IngredientType : BaseDomainModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Ingredient? Ingredient { get; set; }
}
