using AutoMapper;
using SwaggerTesting.Dto;
using SwaggerTesting.Models;

namespace SwaggerTesting.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
