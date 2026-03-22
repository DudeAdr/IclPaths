using AutoMapper;
using IclPaths.API.Models.Domain;
using IclPaths.API.Models.DTO.DifficultyDTOs;

namespace IclPaths.API.Mappings
{
    public class DifficultyMapper : Profile
    {
        public DifficultyMapper()
        {
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
