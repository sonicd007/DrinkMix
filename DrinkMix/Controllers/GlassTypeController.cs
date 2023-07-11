using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.BusinessLogic.Services.Interfaces;
using DrinkMix.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkMix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlassTypeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        public GlassTypeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetGlassTypeById(int id)
        {
            var glassType = _recipeService.GetGlassTypeById(id);
            if (glassType == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<GlassTypeViewModel>(glassType);

            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GlassTypeViewModel>>> GetGlassTypes(int page = 1, int pageSize = 10)
        {
            if (null == _recipeService)
            {
                return NotFound();
            }

            var glassTypes = await _recipeService.GetGlassTypes(page, pageSize);

            // Map the recipes to view models
            ICollection<GlassTypeViewModel> glassTypeViewModel = _mapper.Map<ICollection<GlassTypeViewModel>>(glassTypes);

            return Ok(glassTypeViewModel);
        }

        [HttpPost]
        public IActionResult CreateGlassType([FromBody] GlassTypeViewModel glassType)
        {
            var glassTypeDto = _mapper.Map<GlassTypeDTO>(glassType);
            _recipeService.CreateGlassType(glassTypeDto);
            var viewModel = _mapper.Map<GlassTypeViewModel>(glassType);

            return CreatedAtAction(nameof(CreateGlassType), new { id = viewModel.Id }, viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGlassType(int id, [FromBody] GlassTypeViewModel updatedGlassType)
        {
            var glassTypeDto = _mapper.Map<GlassTypeDTO>(updatedGlassType);
            var existingGlassType = _recipeService.UpdateGlassType(glassTypeDto);
            var viewModel = _mapper.Map<GlassTypeViewModel>(existingGlassType);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGlassType(int id)
        {
            _recipeService.DeleteGlassType(id);

            return NoContent();
        }
    }
}
