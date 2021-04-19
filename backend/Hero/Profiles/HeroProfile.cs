using AutoMapper;
using HeroProject.Dtos;
using HeroProject.Models;

namespace HeroProject.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<Hero, HeroDto>();
        }
    }
}
