using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace DrinkMix.Models;

public partial class Ingredient : BaseDomainModel
{
    public string Name { get; set; } = null!;

    public int IngredientTypeId { get; set; }

    public virtual IngredientType IngredientType { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
