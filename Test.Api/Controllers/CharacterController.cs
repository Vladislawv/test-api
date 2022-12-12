using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Test.Services.Areas.Characters;
using Test.Services.Areas.Characters.Dto;

namespace TestApi.Controllers;

[ApiController]
[Route("api/v1")]
[Produces(MediaTypeNames.Application.Json)]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    /// <summary>
    /// Get Character by Name
    /// </summary>
    /// <param name="characterInput"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(CharacterDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAsync([FromQuery] CharacterDtoInput characterInput)
    {
        var character = await _characterService.GetAsync(characterInput);

        return Ok(character);
    }

    /// <summary>
    /// Check if Character is in Episode
    /// </summary>
    /// <param name="characterInput"></param>
    /// <returns></returns>
    [HttpPost("check-person")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> CheckAsync([FromBody] CharacterDtoInput characterInput)
    {
        var isCharacterInEpisode = await _characterService.CheckAsync(characterInput);

        return Ok(isCharacterInEpisode);
    }
}