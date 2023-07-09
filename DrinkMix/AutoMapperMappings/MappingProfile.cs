using AutoMapper;
using DrinkMix.BusinessLogic.DTOs;
using DrinkMix.Models;
using DrinkMix.ViewModels;

namespace DrinkMix.AutoMapperMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
        }
    }

}
