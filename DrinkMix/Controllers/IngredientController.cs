﻿using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.BusinessLogic.Services.Interfaces;
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

        [HttpPost]
        public IActionResult CreateIngredient([FromBody] IngredientViewModel Ingredient)
        {
            var IngredientDto = _mapper.Map<IngredientDTO>(Ingredient);
            _recipeService.CreateIngredient(IngredientDto);
            var viewModel = _mapper.Map<IngredientViewModel>(Ingredient);

            return CreatedAtAction(nameof(CreateIngredient), new { id = viewModel.Id }, viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIngredient(int id, [FromBody] IngredientViewModel updatedIngredient)
        {
            var IngredientDto = _mapper.Map<IngredientDTO>(updatedIngredient);
            var existingIngredient = _recipeService.UpdateIngredient(IngredientDto);
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
