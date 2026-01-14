using AutoMapper;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.RegionDTOs;

namespace IclPaths.API.Mappings
{
    public class RegionMapper : Profile
    {
        public RegionMapper()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
            CreateMap<AddRegionDto, Region>();
        }
        }
}
