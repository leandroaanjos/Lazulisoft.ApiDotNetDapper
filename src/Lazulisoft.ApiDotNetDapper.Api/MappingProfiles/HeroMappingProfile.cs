using AutoMapper;
using Lazulisoft.ApiDotNetDapper.Api.Models;
using Lazulisoft.ApiDotNetDapper.Api.ViewModels;

namespace Lazulisoft.ApiDotNetDapper.Api.MappingProfiles
{
    public class HeroMappingProfile : Profile
    {
        public HeroMappingProfile()
        {
            CreateMap<Hero, HeroViewModel>().ReverseMap();
        }
    }
}
