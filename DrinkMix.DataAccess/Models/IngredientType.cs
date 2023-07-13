using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DrinkMix.DataAccess.Models;

public partial class IngredientType : BaseDomainModel
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
