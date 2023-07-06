using DrinkMix.Models;

namespace DrinkMix.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int GlassTypeId { get; set; }

        public string GlassType { get; set; } = null!;

        public virtual ICollection<RecipeIngredientViewModel> RecipeIngredients { get; set; } = new List<RecipeIngredientViewModel>();
    }
}
