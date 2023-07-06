using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.Models;

namespace DrinkMix.BusinessLogic.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeDTO?>> GetRecipes(int page, int pageSize);
        RecipeDTO? GetRecipeById(int recipeId);
        RecipeDTO? CreateRecipe(RecipeDTO recipe);
        RecipeDTO? UpdateRecipe(RecipeDTO recipe);
        Task<bool> DeleteRecipe(int recipeId);
        GlassTypeDTO? GetGlassTypeById(int id);
        IngredientDTO? GetIngredientById(int id);
    }
}
