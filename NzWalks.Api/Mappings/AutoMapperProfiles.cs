using AutoMapper;
using NzWalks.Api.Models.Domain;
using NzWalks.Api.Models.DTO;

namespace NzWalks.Api.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
                CreateMap<Region,RegionDto>().ReverseMap();
        }
    }
}
