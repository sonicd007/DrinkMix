using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DrinkMix.DataAccess.Models;

public partial class GlassType : BaseDomainModel
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
