using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.BusinessLogic.Services.Interfaces;
using DrinkMix.RequestObjects;
using DrinkMix.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkMix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        public IngredientController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetIngredientById(int id)
        {
            var Ingredient = _recipeService.GetIngredientById(id);
            if (Ingredient == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<IngredientViewModel>(Ingredient);

            return Ok(viewModel);
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<IngredientViewModel>>> GetIngredients(int page = 1, int pageSize = 10)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }

            var recipes = await _recipeService.GetIngredients(page, pageSize);

            // Map the recipes to view models
            ICollection<IngredientViewModel> ingredients = _mapper.Map<ICollection<IngredientViewModel>>(recipes);

            return Ok(ingredients);
        }
        [HttpPost]
        public IActionResult CreateIngredient([FromBody] CreateIngredientRequestObject createIngredientRequestObj)
        {
            var IngredientDto = _mapper.Map<IngredientDTO>(createIngredientRequestObj);
            var createdIngredient = _recipeService.CreateIngredient(IngredientDto);
            var viewModel = _mapper.Map<IngredientViewModel>(createdIngredient);

            return CreatedAtAction(nameof(CreateIngredient), new { id = viewModel.Id }, viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIngredient(int id, [FromBody] CreateIngredientRequestObject updatedIngredient)
        {
            var ingredientDto = _mapper.Map<IngredientDTO>(updatedIngredient);
            ingredientDto.Id = id;
            var existingIngredient = _recipeService.UpdateIngredient(ingredientDto);
            var viewModel = _mapper.Map<IngredientViewModel>(existingIngredient);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            _recipeService.DeleteIngredient(id);

            return NoContent();
        }
    }
}
