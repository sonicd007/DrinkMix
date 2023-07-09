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
            Recipe updatedRecipe = _mapper.Map<Recipe>(recipe);
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
                ingredientDto = _mapper.Map<IngredientDTO>(ingredient);
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

        public GlassTypeDTO? CreateGlassType(GlassTypeDTO glassTypeDto)
        {
            var glassType = _mapper.Map<GlassType>(glassTypeDto);

            _dbContext.GlassTypes.Add(glassType);
            var createdGlassTypeDto = _mapper.Map<GlassTypeDTO>(glassType);

            return createdGlassTypeDto;
        }

        public GlassTypeDTO? UpdateGlassType(GlassTypeDTO glassType)
        {
            var existingGlassType = _dbContext.GlassTypes.Find(glassType.Id);
            if (existingGlassType == null)
            {
                return null;
            }

            // Update the properties of the existing glass type
            existingGlassType.Name = glassType.Name;

            // Save the changes to the database
            _dbContext.SaveChanges();

            // Map the updated glass type to DTO and return it
            return new GlassTypeDTO
            {
                Id = existingGlassType.Id,
                Name = existingGlassType.Name
            };
        }

        public async Task<bool> DeleteGlassType(int glassTypeId)
        {
            var existingGlassType = await _dbContext.GlassTypes.FindAsync(glassTypeId);
            if (existingGlassType == null)
            {
                return false;
            }

            // Remove the glass type from the DbSet
            _dbContext.GlassTypes.Remove(existingGlassType);

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IngredientDTO? CreateIngredient(IngredientDTO ingredient)
        {
            var newIngredient = _mapper.Map<Ingredient>(ingredient);

            // Add the new ingredient to the DbSet
            _dbContext.Ingredients.Add(newIngredient);

            // Save the changes to the database
            _dbContext.SaveChanges();

            // Map the new ingredient to DTO and return it
            return _mapper.Map<IngredientDTO>(newIngredient);
        }

        public IngredientDTO? UpdateIngredient(IngredientDTO ingredient)
        {
            var existingIngredient = _dbContext.Ingredients.Find(ingredient.Id);
            if (existingIngredient == null)
            {
                return null;
            }

            // Update the properties of the existing ingredient
            existingIngredient.Name = ingredient.Name;

            // Save the changes to the database
            _dbContext.SaveChanges();

            // Map the updated ingredient to DTO and return it
            return _mapper.Map<IngredientDTO>(existingIngredient);
        }

        public IngredientTypeDTO? GetIngredientTypeById(int id)
        {
            IngredientTypeDTO? glassTypeDto = null;
            IngredientType? ingredientType = _dbContext.IngredientTypes.Find(id);

            if (null != ingredientType)
            {
                glassTypeDto = _mapper.Map<IngredientTypeDTO>(ingredientType);
            }

            return glassTypeDto;
        }

        public IngredientTypeDTO? CreateIngredientType(IngredientTypeDTO ingredientTypeDto)
        {
            throw new NotImplementedException();
        }

        public IngredientTypeDTO? UpdateIngredientType(IngredientTypeDTO ingredientTypeDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIngredientType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<IngredientTypeDTO?>> GetIngredientTypes(int page, int pageSize)
        {
            // Calculate the number of items to skip based on the page and pageSize
            int skipCount = (page - 1) * pageSize;

            // Retrieve the recipes asynchronously with pagination
            List<IngredientType> ingredientTypes = await _dbContext.IngredientTypes.AsQueryable()
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();

            var foundIngredientsTypes = _mapper.Map<ICollection<IngredientTypeDTO?>>(ingredientTypes);

            return foundIngredientsTypes;
        }
    }

}


