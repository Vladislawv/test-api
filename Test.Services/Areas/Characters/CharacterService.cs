using AutoMapper;
using Rick;
using Test.Services.Areas.Characters.Dto;

namespace Test.Services.Areas.Characters;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<CharacterDto> GetAsync(CharacterDtoInput characterInput)
    {
        var character = Search
            .GetAllCharactersAsync()
            .Result
            .Results
            .FirstOrDefault(
                c => characterInput.CharacterName != null && c.Name.Contains(characterInput.CharacterName))
                    ?? throw new Exception($"Character with name: {characterInput.CharacterName} is not found!");

        var characterDto = _mapper.Map<CharacterDto>(character);

        return Task.FromResult(characterDto);
    }

    public Task<bool> CheckAsync(CharacterDtoInput characterInput)
    {
        var result = false;

        var character = Search
            .GetAllCharactersAsync()
            .Result
            .Results
            .FirstOrDefault(
                c => characterInput.CharacterName != null && c.Name.Contains(characterInput.CharacterName))
                    ?? throw new Exception($"Character with name: {characterInput.CharacterName} is not found!");

        var episodes = Search
            .GetAllEpisodesAsync()
            .Result
            .Results;

        var ifCharacterExist = episodes
            .FirstOrDefault(e => e.Name == characterInput.EpisodeName)
                ?? throw new Exception($"Episode with name: {characterInput.EpisodeName} is not found!");

        foreach (var episode in character.Episodes)
        {
            var matchEpisode = episodes.FirstOrDefault(e => e.URL == episode);

            if (matchEpisode?.Name == characterInput.EpisodeName) result = true;
        }

        return Task.FromResult(result);
    }
}