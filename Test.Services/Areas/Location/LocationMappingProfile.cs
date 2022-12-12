using AutoMapper;
using Test.Services.Areas.Location.Dto;

namespace Test.Services.Areas.Location;

public class LocationMappingProfile : Profile
{
    public LocationMappingProfile()
    {
        CreateMap<Rick.Location, LocationDto>();
    }
}