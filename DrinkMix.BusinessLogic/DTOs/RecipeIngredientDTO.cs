using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.DTOs
{
    public class RecipeIngredientDTO
    {
        public int RecipeIngredientId { get; set; }
        public int IngredientId { get; set; }
        public string? IngredientName { get; set; }
        public string? IngredientType { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public double Quantity { get; set; }
        public int IngredientTypeId { get; set; }
    }
}
