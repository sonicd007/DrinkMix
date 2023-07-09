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
                .ForMember(to => to.RecipeIngredientId, opt => opt.MapFrom(from => from.RecipeId));


            CreateMap<Recipe, RecipeDTO>()
                .ForMember(to => to.GlassName, opt => opt.MapFrom(from => from.GlassType.Name))
                .ForMember(to => to.Ingredients, opt => opt.Ignore())//.MapFrom(to => to.RecipeIngredients))
                .ReverseMap();

            CreateMap<GlassTypeDTO, GlassType>()
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Recipes, opt => opt.Ignore())
                .ReverseMap();

            //CreateMap<IngredientDTO, Ingredient>()
            //    .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
            //    .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
            //    //.ForMember(to => to.IdNavigation.Name, opt => opt.MapFrom(from => from.IngredientTypeName))
            //    //.AfterMap((x, y) =>
            //    //{
            //    //    x.IngredientTypeName = y.IdNavigation.Name;
            //    //})
            //    .ReverseMap();

            CreateMap<IngredientTypeDTO, IngredientType>()
                .ForMember(to => to.Ingredient, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
