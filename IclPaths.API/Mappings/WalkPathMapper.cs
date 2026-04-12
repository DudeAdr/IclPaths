using AutoMapper;
using IclPaths.API.Models.DomainModels.IclPathsDbModels;
using IclPaths.API.Models.DTO.WalkDTOs;
using IclPaths.API.Models.DTO.WalkPathDTOs;

namespace IclPaths.API.Mappings
{
    public class WalkPathMapper : Profile
    {
        public WalkPathMapper()
        {
            CreateMap<AddWalkPathDto, WalkPath>().ReverseMap();
            CreateMap<WalkPath, WalkPathDto>().ReverseMap();
            CreateMap<UpdateWalkPathDto, WalkPath>()
                .ForMember(dest => dest.Region, opt => opt.Ignore())
                .ForMember(dest => dest.Difficulty, opt => opt.Ignore());
        }
    }
}
