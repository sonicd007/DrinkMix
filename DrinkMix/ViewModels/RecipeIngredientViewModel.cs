
namespace DrinkMix.ViewModels
{
    public class RecipeIngredientViewModel
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public string UnitOfMeasurement { get; set; } = null!;

        /// <summary>
        /// The amount of said ingredient to use in recipe
        /// </summary>
        public double Quantity { get; set; }
        public string? IngredientName { get; set; }
        public string? IngredientType { get; set; }

    }
}
