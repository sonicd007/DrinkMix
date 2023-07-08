﻿using DrinkMix.BusinessLogic.DTOs;
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
        GlassTypeDTO? CreateGlassType(GlassTypeDTO glassType);
        GlassTypeDTO? UpdateGlassType(GlassTypeDTO glassType);
        Task<bool> DeleteGlassType(int glassTypeId);
        IngredientDTO? GetIngredientById(int id);
        IngredientDTO? CreateIngredient(IngredientDTO ingredient);
        IngredientDTO? UpdateIngredient(IngredientDTO ingredient);
    }
}
