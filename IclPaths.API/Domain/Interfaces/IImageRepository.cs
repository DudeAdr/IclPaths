using IclPaths.API.Models.DTO.ImageDTOs;

namespace IclPaths.API.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<ImageUploadResponseDto> UploadAsync(ImageUploadRequestDto image);
    }
}
