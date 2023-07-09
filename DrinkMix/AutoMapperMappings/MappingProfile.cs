using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.ViewModels;

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
                .ForMember(x => x.IngredientName, opt => opt.MapFrom(y => y.IngredientName));

            CreateMap<RecipeDTO, RecipeViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name))
                .ForMember(x => x.GlassTypeId, opt => opt.MapFrom(y => y.GlassTypeId))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.GlassType, opt => opt.MapFrom(y => y.GlassName))
                .ForMember(x => x.RecipeIngredients, opt => opt.MapFrom(y => y.Ingredients));
                

            CreateMap<GlassTypeDTO, GlassTypeViewModel>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name))
                .ReverseMap();

            CreateMap<IngredientTypeDTO, IngredientTypeViewModel>()
                .ForMember(to => to.Id, opt => opt.MapFrom(from => from.Id))
                .ForMember(to => to.Name, opt => opt.MapFrom(from => from.Name));

        }
    }

}
