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
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto >().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
         //   CreateMap<ImageUploadRequestDto,Image>().ReverseMap();

        }

    }
}
 