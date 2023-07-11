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
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<RecipeIngredient, RecipeIngredientDTO>()
                .ForMember(to => to.IngredientId, opt => opt.MapFrom(from => from.Ingredient.Id))
                .ForMember(to => to.IngredientType, opt => opt.MapFrom(from => from.Ingredient.IdNavigation.Name))
                .ForMember(to => to.IngredientTypeId, opt => opt.MapFrom(from => from.Ingredient.IngredientTypeId))
                .ForMember(to => to.IngredientName, opt => opt.MapFrom(from => from.Ingredient.Name))
                .ForMember(to => to.Quantity, opt => opt.MapFrom(from => from.Quantity))
                .ForMember(to => to.UnitOfMeasurement, opt => opt.MapFrom(from => from.UnitOfMeasurement))
                .ForMember(to => to.RecipeIngredientId, opt => opt.MapFrom(from => from.RecipeId))
                .ReverseMap();

            CreateMap<Recipe, RecipeDTO>()
                .ForMember(to => to.GlassName, opt => opt.MapFrom(from => from.GlassType.Name))
                .ForMember(to => to.GlassTypeId, opt => opt.MapFrom(from => from.GlassType.Id))
                .ForMember(to => to.Ingredients, opt => opt.MapFrom(to => to.RecipeIngredients))
                .ReverseMap();

            CreateMap<GlassTypeDTO, GlassType>()
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Recipes, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Ingredient, IngredientDTO>()
                .ForMember(to => to.IngredientTypeName, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.IngredientTypeId, opt => opt.MapFrom(from => from.IngredientTypeId));

            CreateMap<IngredientDTO, Ingredient>()
                .ForMember(to => to.IdNavigation, opt => opt.Ignore())
                .ForMember(to => to.RecipeIngredients, opt => opt.Ignore());

            CreateMap<IngredientTypeDTO, IngredientType>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.Ingredient, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
