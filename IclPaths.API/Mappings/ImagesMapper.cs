using AutoMapper;
using IclPaths.API.Models.DomainModels.IclPathsDbModels;
using IclPaths.API.Models.DTO.ImageDTOs;

namespace IclPaths.API.Mappings
{
    public class ImagesMapper : Profile
    {
        public ImagesMapper()
        {
            CreateMap<ImageUploadRequestDto, Image>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File))
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => Path.GetExtension(src.File.FileName)))
                .ForMember(dest => dest.FileSize, opt => opt.MapFrom(src => src.File.Length))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FileDescription, opt => opt.MapFrom(src => src.FileDescription));

            CreateMap<Image, ImageUploadResponseDto>();
        }
    }
}
