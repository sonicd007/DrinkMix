﻿namespace DrinkMix.ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IngredientTypeViewModel Type { get; set; } = null!;
    }
}