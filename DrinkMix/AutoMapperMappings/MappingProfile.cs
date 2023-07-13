﻿using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.RequestObjects;
using DrinkMix.ViewModels;
using Microsoft.OpenApi.Writers;

namespace DrinkMix.AutoMapperMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecipeIngredientDTO, RecipeIngredientViewModel>()
                .ForMember(x => x.Quantity, opt => opt.MapFrom(y => y.Quantity))
                .ForMember(x => x.UnitOfMeasurement, opt => opt.MapFrom(y => y.UnitOfMeasurement))
                .ForMember(x => x.IngredientId, opt => opt.MapFrom(y => y.IngredientId))
                .ForMember(x => x.RecipeId, opt => opt.MapFrom(y => y.RecipeIngredientId))
                .ForMember(x => x.IngredientName, opt => opt.MapFrom(y => y.IngredientName))
                .ReverseMap();

            CreateMap<RecipeDTO, RecipeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name))
                .ForMember(x => x.GlassTypeId, opt => opt.MapFrom(y => y.GlassTypeId))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.GlassType, opt => opt.MapFrom(y => y.GlassName))
                .ForMember(x => x.RecipeIngredients, opt => opt.MapFrom(y => y.Ingredients))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(y => y.ImageUrl));
                
            CreateMap<GlassTypeDTO, GlassTypeViewModel>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ReverseMap();

            CreateMap<IngredientTypeDTO, IngredientTypeViewModel>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name));

            CreateMap<IngredientDTO, IngredientViewModel>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.Type, opt => opt.MapFrom(from => from));

            CreateMap<IngredientDTO, IngredientTypeViewModel>()
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.IngredientTypeName))
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.IngredientTypeId));

            CreateMap<CreateIngredientRequestObject, IngredientDTO>()
                .ForMember(to => to.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(to => to.IngredientTypeId, opt => opt.MapFrom(dest => dest.IngredientTypeId))
                .ForMember(to => to.IngredientTypeName, opt => opt.Ignore())
                .ForMember(to => to.Id, opt => opt.Ignore());

            CreateMap<CreateIngredientTypeRequestObject, IngredientTypeDTO>()
                .ForMember(to => to.Id, opt => opt.Ignore());

            CreateMap<CreateIngredientTypeRequestObject, IngredientTypeViewModel>()
                .ForMember(to => to.Id, opt => opt.Ignore());

            CreateMap<CreateRecipeRequestObject, RecipeDTO>()
                .ForMember(to => to.Id, opt => opt.Ignore())
                .ForMember(to => to.GlassName, opt => opt.Ignore())
                .ForMember(to => to.Description, opt => opt.MapFrom(from => from.Description))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ForMember(to => to.GlassTypeId, opt => opt.MapFrom(from => from.GlassTypeId))
                .ForMember(to => to.Ingredients, opt => opt.MapFrom(from => from.RecipeIngredients))
                .ForMember(to => to.ImageUrl, opt => opt.MapFrom(from => from.ImageUrl));
        }
    }

}
