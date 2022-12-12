using Test.Services.Areas.Characters.Dto;

namespace Test.Services.Areas.Characters;

public interface ICharacterService
{
    public Task<CharacterDto> GetAsync(CharacterDtoInput characterInput);
    public Task<bool> CheckAsync(CharacterDtoInput characterInput);
}