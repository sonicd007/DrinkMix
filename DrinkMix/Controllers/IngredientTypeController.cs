using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.BusinessLogic.Services.Interfaces;
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
        public IActionResult CreateIngredientType([FromBody] IngredientTypeViewModel IngredientType)
        {
            var IngredientTypeDto = _mapper.Map<IngredientTypeDTO>(IngredientType);
            _recipeService.CreateIngredientType(IngredientTypeDto);
            var viewModel = _mapper.Map<IngredientTypeViewModel>(IngredientType);

            return CreatedAtAction(nameof(CreateIngredientType), new { id = viewModel.Id }, viewModel);
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
