using Test.Services.Areas.Location.Dto;

namespace Test.Services.Areas.Characters.Dto;

public class CharacterDto
{
    public string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }

    public LocationDto Origin { get; set; }
}