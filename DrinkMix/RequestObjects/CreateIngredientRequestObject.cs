using DrinkMix.ViewModels;

namespace DrinkMix.RequestObjects
{
    public class CreateIngredientRequestObject
    {
        public string Name { get; set; } = null!;
        public IngredientTypeViewModel Type { get; set; } = null!;
    }
}
