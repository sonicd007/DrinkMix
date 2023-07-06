using DrinkMix.ViewModels;

namespace DrinkMix.RequestObjects
{
    public class UpdateRecipeRequestObject
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int GlassTypeId { get; set; }

        public virtual ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new List<RecipeIngredientViewModel>();
    }
}
