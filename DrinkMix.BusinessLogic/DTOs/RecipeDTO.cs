using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.DTOs
{
    public class RecipeDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GlassTypeId { get; set; }
        public string GlassName { get; set; }
        public string ImageUrl { get; set; }
        public List<RecipeIngredientDTO> Ingredients { get; set; }

        public RecipeDTO()
        {
            Ingredients = new List<RecipeIngredientDTO>();
        }
    }
}
