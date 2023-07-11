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
    public class IngredientTypeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        public IngredientTypeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<IngredientTypeViewModel>>> GetIngredientTypes(int page = 1, int pageSize = 10)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }

            var recipes = await _recipeService.GetIngredientTypes(page, pageSize);

            // Map the recipes to view models
            ICollection<IngredientTypeViewModel> recipeViewModels = _mapper.Map<ICollection<IngredientTypeViewModel>>(recipes);

            return Ok(recipeViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetIngredientTypeById(int id)
        {
            var IngredientType = _recipeService.GetIngredientTypeById(id);
            if (IngredientType == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<IngredientTypeViewModel>(IngredientType);

            return Ok(viewModel);
        }

        [HttpPost]
        public IActionResult CreateIngredientType([FromBody] CreateIngredientTypeRequestObject ingredientType)
        {
            var IngredientTypeDto = _mapper.Map<IngredientTypeDTO>(ingredientType);
            var newIngredient = _recipeService.CreateIngredientType(IngredientTypeDto);
            var viewModel = _mapper.Map<IngredientTypeViewModel>(newIngredient);

            return CreatedAtAction(nameof(CreateIngredientType), new { id = viewModel.Id }, newIngredient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIngredientType(int id, [FromBody] IngredientTypeViewModel updatedIngredientType)
        {
            var IngredientTypeDto = _mapper.Map<IngredientTypeDTO>(updatedIngredientType);
            var existingIngredientType = _recipeService.UpdateIngredientType(IngredientTypeDto);
            var viewModel = _mapper.Map<IngredientTypeViewModel>(existingIngredientType);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIngredientType(int id)
        {
            _recipeService.DeleteIngredientType(id);

            return NoContent();
        }
    }
}
