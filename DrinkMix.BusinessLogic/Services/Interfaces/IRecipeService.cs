using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.Models;

namespace DrinkMix.BusinessLogic.Services.Interfaces
{
    public interface IRecipeService
    {
        RecipeDTO? GetRecipeById(int recipeId);
        RecipeDTO? CreateRecipe(RecipeDTO recipe);
        RecipeDTO? UpdateRecipe(RecipeDTO recipe);
        Task<bool> DeleteRecipe(int recipeId);
        GlassTypeDTO? GetGlassTypeById(int id);
        GlassTypeDTO? CreateGlassType(GlassTypeDTO glassType);
        GlassTypeDTO? UpdateGlassType(GlassTypeDTO glassType);
        Task<bool> DeleteGlassType(int glassTypeId);
        IngredientDTO? GetIngredientById(int id);
        IngredientDTO? CreateIngredient(IngredientDTO ingredient);
        IngredientDTO? UpdateIngredient(IngredientDTO ingredient);
        IngredientTypeDTO? GetIngredientTypeById(int id);
        IngredientTypeDTO? CreateIngredientType(IngredientTypeDTO ingredientTypeDto);
        IngredientTypeDTO? UpdateIngredientType(IngredientTypeDTO ingredientTypeDto);
        Task<bool> DeleteIngredientType(int id);
        Task<bool> DeleteIngredient(int id);
        Task<ICollection<IngredientTypeDTO>> GetIngredientTypes(int page, int pageSize);
        Task<ICollection<IngredientDTO>> GetIngredients(int page, int pageSize);
        Task<ICollection<RecipeDTO>> GetRecipes(int page, int pageSize);
        Task<ICollection<GlassTypeDTO>> GetGlassTypes(int page, int pageSize);
    }
}
