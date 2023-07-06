using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.BusinessLogic.Services.Interfaces;
using DrinkMix.Data;
using DrinkMix.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DrinkMix.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly DrinkMixDbContext _dbContext;
        private readonly IMapper _mapper;
        public RecipeService(DrinkMixDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a recipe by it's Id.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>The Recipe modle object or null if not found</returns>
        public RecipeDTO? GetRecipeById(int recipeId)
        {
            var recipe = _dbContext.Recipes.Find(recipeId);
            if (null == recipe)
            {
                return null;
            }

            return _mapper.Map<RecipeDTO>(recipe);
        }

        public RecipeDTO CreateRecipe(RecipeDTO recipe)
        {
            Recipe newRecipe = _mapper.Map<Recipe>(recipe);
            _dbContext.Recipes.Add(newRecipe);
            _dbContext.SaveChanges();
            return _mapper.Map<RecipeDTO>(newRecipe);
        }

        public RecipeDTO? UpdateRecipe(RecipeDTO recipe)
        {
            Recipe updatedRecipe= _mapper.Map<Recipe>(recipe);
            // Retrieve the existing recipe from the service
            RecipeDTO? existingRecipe = this.GetRecipeById(recipe.Id);
            if (null == existingRecipe)
            {
                return null;
            }

            GlassTypeDTO? glassType = this.GetGlassTypeById(recipe.GlassTypeId);
            if (null == glassType)
            {
                return null;
            }

            // Update the properties of the existing recipe with the values from the request object
            existingRecipe.Name = recipe.Name;
            existingRecipe.Description = recipe.Description;
            existingRecipe.GlassTypeId = recipe.GlassTypeId;

            // Update or add ingredients
            foreach (var ingredientDto in recipe.Ingredients)
            {
                IngredientDTO? ingredient = this.GetIngredientById(ingredientDto.IngredientId);
                if (null == ingredient)
                {
                    return null;
                }

                var existingIngredient = existingRecipe.Ingredients
                    .SingleOrDefault(x => x.IngredientId == ingredientDto.IngredientId);

                if (existingIngredient == null)
                {
                    // Ingredient not found, add a new one
                    var newIngredient = new RecipeIngredientDTO
                    {
                        IngredientId = ingredientDto.IngredientId,
                        UnitOfMeasurement = ingredientDto.UnitOfMeasurement,
                        Quantity = ingredientDto.Quantity
                    };

                    existingRecipe.Ingredients.Add(newIngredient);
                }
                else
                {
                    // Ingredient found, update its properties
                    existingIngredient.UnitOfMeasurement = ingredientDto.UnitOfMeasurement;
                    existingIngredient.Quantity = ingredientDto.Quantity;
                }
            }

            // Remove ingredients
            var ingredientIdsToRemove = existingRecipe.Ingredients
                .Select(ri => ri.IngredientId)
                .Except(recipe.Ingredients.Select(ivm => ivm.IngredientId))
                .ToList();

            existingRecipe.Ingredients.ToList().RemoveAll(ri => ingredientIdsToRemove.Contains(ri.IngredientId));
            _dbContext.SaveChanges();

            return existingRecipe;
        }

        public async Task<bool> DeleteRecipe(int recipeId)
        {
            var recipe = await _dbContext.Recipes.FindAsync(recipeId);
            if (null == recipe)
            {
                return false;
            }

            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public GlassTypeDTO? GetGlassTypeById(int id)
        {
            GlassTypeDTO? glassTypeDto = null;
            GlassType? glassType = _dbContext.GlassTypes.Find(id);

            if (null != glassType)
            {
                glassTypeDto = _mapper.Map<GlassTypeDTO>(glassType);
            }

            return glassTypeDto;
        }

        public IngredientDTO? GetIngredientById(int id)
        {
            IngredientDTO? ingredientDto = null;
            Ingredient? ingredient = _dbContext.Ingredients.Find(id);

            if (null != ingredient)
            {
                ingredientDto= _mapper.Map<IngredientDTO>(ingredient);
            }

            return ingredientDto;
        }

        public async Task<List<RecipeDTO?>> GetRecipes(int page, int pageSize)
        {
            // Calculate the number of items to skip based on the page and pageSize
            int skipCount = (page - 1) * pageSize;

            // Retrieve the recipes asynchronously with pagination
            List<Recipe> recipes = await _dbContext.Recipes.AsQueryable()
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            List<RecipeDTO?> foundRecipes = _mapper.Map<List<RecipeDTO?>>(recipes);

            return foundRecipes;
        }
    }

}
