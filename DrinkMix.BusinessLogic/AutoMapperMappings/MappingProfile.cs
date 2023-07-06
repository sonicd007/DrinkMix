using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMix.BusinessLogic.AutoMapperMappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeIngredient, RecipeIngredientDTO>()
                .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(dest => dest.Ingredient.Id))
                .ForMember(dest => dest.IngredientType, opt => opt.MapFrom(dest => dest.Ingredient.IdNavigation.Name))
                .ForMember(dest => dest.IngredientTypeId, opt => opt.MapFrom(dest => dest.Ingredient.IngredientTypeId))
                .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(dest => dest.Ingredient.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(dest => dest.Quantity))
                .ForMember(dest => dest.UnitOfMeasurement, opt => opt.MapFrom(dest => dest.UnitOfMeasurement));


            CreateMap<Recipe, RecipeDTO>()
                .ForMember(dest => dest.GlassName, opt => opt.MapFrom(dest => dest.GlassType.Name))
                //.ForMember(dest => dest.Ingredients, opt => opt.MapFrom(dest => dest.RecipeIngredients))
                .ReverseMap();

        }
    }
}
