using AutoMapper;

namespace Test.Services.Areas.Characters.Dto;

public class CharacterMappingProfile : Profile
{
    public CharacterMappingProfile()
    {
        CreateMap<Rick.Character, CharacterDto>();
    }
}