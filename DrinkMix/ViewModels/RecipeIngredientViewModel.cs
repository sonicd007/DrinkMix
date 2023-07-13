
namespace DrinkMix.ViewModels
{
    public class RecipeIngredientViewModel
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        /// <summary>
        /// The measurement used i.e. oz, g, ml, etc.
        /// </summary>
        public string UnitOfMeasurement { get; set; } = null!;

        /// <summary>
        /// The amount of said ingredient to use in recipe
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// The name of the ingredient
        /// </summary>
        public string? IngredientName { get; set; }

        /// <summary>
        /// The type of ingredient
        /// </summary>
        public string? IngredientType { get; set; }

    }
}
