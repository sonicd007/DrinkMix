using DrinkMix.BusinessLogic.DTOs;

namespace DrinkMix.ViewModels
{
    /// <summary>
    /// Request object that represents the creation of a new recipe
    /// </summary>
    public class CreateRecipeRequestObject
    {
        /// <summary>
        /// The name of the recipe
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// A description of the recipe
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The glass type recommended for this recipe to be served.
        /// </summary>
        public int GlassTypeId { get; set; }

        /// <summary>
        /// A sample image of the recipe
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// A list of ingredients required to make this recipe
        /// </summary>
        public virtual ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new List<RecipeIngredientViewModel>();
    }
}
