using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.DTOs
{
    public class RecipeDTO : BaseDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int GlassTypeId { get; set; }
        public required string GlassName { get; set; }
        public List<RecipeIngredientDTO> Ingredients { get; set; }

        public RecipeDTO()
        {
            Ingredients = new List<RecipeIngredientDTO>();
        }
    }
}
