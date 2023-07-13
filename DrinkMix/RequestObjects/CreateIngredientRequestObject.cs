using DrinkMix.ViewModels;

namespace DrinkMix.RequestObjects
{
    public class CreateIngredientRequestObject
    {
        public string Name { get; set; } = null!;
        public int IngredientTypeId { get; set; }
    }
}
