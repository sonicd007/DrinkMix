using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrinkMix.Data;
using DrinkMix.ViewModels;
using DrinkMix.BusinessLogic.Services.Interfaces;
using AutoMapper;
using DrinkMix.Services;
using DrinkMix.RequestObjects;
using DrinkMix.BusinessLogic.DTOs;

namespace DrinkMix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeViewModel>>> GetRecipes(int page = 1, int pageSize = 10)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }

            var recipes = await _recipeService.GetRecipes(page, pageSize);

            // Map the recipes to view models
            IEnumerable<RecipeViewModel> recipeViewModels = _mapper.Map<IEnumerable<RecipeViewModel>>(recipes);

            return Ok(recipeViewModels);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public ActionResult<RecipeViewModel> GetRecipe(int id)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }
            var recipe = _recipeService.GetRecipeById(id);

            if (null == recipe)
            {
                return NotFound();
            }

            RecipeViewModel recipeViewModel = _mapper.Map<RecipeViewModel>(recipe);

            return recipeViewModel;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{recipeId}")]
        public IActionResult UpdateRecipe(int recipeId, UpdateRecipeRequestObject updateRecipeRequestObject)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }

            var updateRecipeDto = _mapper.Map<RecipeDTO>(updateRecipeRequestObject);
            updateRecipeDto = _recipeService.UpdateRecipe(updateRecipeDto);
            var recipeViewmodel = _mapper.Map<RecipeIngredientViewModel>(updateRecipeDto);

            return Ok(recipeViewmodel);
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RecipeViewModel> CreateRecipe(CreateRecipeRequestObject recipe)
        {
            var createRecipeDto = _mapper.Map<RecipeDTO>(recipe);
            createRecipeDto = _recipeService.CreateRecipe(createRecipeDto);
            var viewModel = _mapper.Map<RecipeViewModel>(createRecipeDto);
            return CreatedAtAction("CreateRecipe", new { id = viewModel.Id }, viewModel);
        }

        private bool RecipeExists(int id)
        {
            return _recipeService.GetRecipeById(id) != null;
        }
    }
}
