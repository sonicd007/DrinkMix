using DrinkMix.BusinessLogic.DTOs;

namespace DrinkMix.ViewModels
{
    public class CreateRecipeRequestObject
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int GlassTypeId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new List<RecipeIngredientViewModel>();
    }
}
