using AutoMapper;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.RegionDTOs;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;

namespace IclPaths.API.Mappings
{
    public class RegionMapper : Profile
    {
        public RegionMapper()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
            CreateMap<AddRegionDto, Region>();
            CreateMap<AddWalkPathDto, WalkPath>().ReverseMap();
            CreateMap<WalkPath, WalkPathDto>().ReverseMap();
        }
    }
}
