using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.DTOs
{
    public class IngredientDTO : BaseDTO
    {
        public string Name { get; set; } = null!;

        public int IngredientTypeId { get; set; }
        public required string IngredientTypeName { get; set; }
    }
}
